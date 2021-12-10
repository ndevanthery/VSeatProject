using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using WebApp.Models;
using DTO;

namespace WebApp.Controllers
{
    public class RestaurantController : Controller
    {

        private IRestaurantManager RestaurantManager { get; }
        private ICityManager CityManager { get; }

        private IDishManager DishManager { get; }

        private IRestoTypeManager RestoTypeManager { get; }

        private IOrderManager OrderManager { get; }

        private IOrderDetailsManager OrderDetailsManager { get; }

        public RestaurantController(IRestaurantManager restaurantManager, ICityManager cityManager , IDishManager dishManager, IRestoTypeManager restoTypeManager, IOrderManager orderManager , IOrderDetailsManager orderDetailsManager)
        {
            RestaurantManager = restaurantManager;
            CityManager = cityManager;
            DishManager = dishManager;
            RestoTypeManager = restoTypeManager;
            OrderManager = orderManager;
            OrderDetailsManager = orderDetailsManager;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var citys = CityManager.GetCities();
            foreach(var city in citys)
            {
                Console.WriteLine(city.ToString());
            }
            return View(citys);
        }

        public IActionResult RestaurantsList(int idCity)
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var restaurants = RestaurantManager.GetRestaurantsByCity(idCity);
            var restaurants_vm = new List<Models.RestaurantVM>();
            if(restaurants!=null)
            {
                foreach (var resto in restaurants)
                {
                    Models.RestaurantVM myRestoVM = new Models.RestaurantVM
                    {
                        CITYNAME = CityManager.GetCity(resto.IDCITY).CITYNAME,
                        RESTAURANTNAME = resto.NAME,
                        TYPENAME = RestoTypeManager.GetRestoType(resto.IDTYPE).TYPENAME,
                        restaurant = resto


                    };

                    restaurants_vm.Add(myRestoVM);
                }
            }


            
            return View(restaurants_vm);
        }

        public IActionResult DishesList(int idRestaurant)
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var dishes = DishManager.GetDishes(idRestaurant);
            var dishes_vm = new List<Models.DishVM>();
            if (dishes != null)
            {
                foreach (var dish in dishes)
                {
                    var myCityID = RestaurantManager.GetRestaurant(idRestaurant).IDCITY;

                    Models.DishVM myDishVM = new Models.DishVM
                    {
                        dish = dish,
                        restaurantName = RestaurantManager.GetRestaurant(idRestaurant).NAME,
                        cityName = CityManager.GetCity(myCityID).CITYNAME


                    };

                    dishes_vm.Add(myDishVM);
                }
            }
            return View(dishes_vm);
        }

        public IActionResult CommandPage(int idRestaurant)
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var dishes = DishManager.GetDishes(idRestaurant);
            var dishes_vm = new List<Models.OrderDishVM>();
            if (dishes != null)
            {
                foreach (var dish in dishes)
                {
                    var myCityID = RestaurantManager.GetRestaurant(idRestaurant).IDCITY;

                    Models.OrderDishVM myDishVM = new Models.OrderDishVM
                    {
                        dish = dish,
                        restaurantName = RestaurantManager.GetRestaurant(idRestaurant).NAME,
                        cityname = CityManager.GetCity(myCityID).CITYNAME,
                        quantity = 0


                    };

                    dishes_vm.Add(myDishVM);
                }
            }
            return View(dishes_vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CommandPage(IEnumerable<OrderDishVM> myOrders)
        {
            if (ModelState.IsValid)
            {
     
                if (myOrders != null)
                {
                    decimal somme = 0;
                    foreach(var order in myOrders)
                    {
                        somme += order.dish.PRICE * order.quantity;
                    }
                    //create one order 
                    Order myNewOrder = new Order
                    {
                        ID_CUSTOMER = (int)HttpContext.Session.GetInt32("ID_CUSTOMER"),
                        ORDERDATE = DateTime.Now,
                        DISCOUNT = 0,
                        TOTALPRICE = somme

                    };
                    Order myOrder_added = OrderManager.AddOrder(myNewOrder);

                    foreach(var order in myOrders)
                    {
                        if(order.quantity > 0)
                        {
                            OrderDetails myNewOrderDetail = new OrderDetails
                            {
                                ID_DISH = order.dish.ID_DISH,
                                ID_ORDER = myOrder_added.ID_ORDER,
                                quantity = order.quantity
                            };

                            OrderDetailsManager.AddOrderDetails(myNewOrderDetail);
                        }

                    }

                    // create multiple orderDetails with the same order ID
                    // when the quantity == 0 , no order details created

                    return View("~/Views/Restaurant/CommandConfirmation.cshtml" , myOrders);

                }
                ModelState.AddModelError(string.Empty, "Invalid username or password");

            }
            return View(myOrders);
        }











    }
}
