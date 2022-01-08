using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RestoController : Controller
    {
        private IRestaurantManager RestaurantManager { get; }
        private IOrderManager OrderManager { get; }
        private ICityManager CityManager { get; }

        private IOrderDetailsManager OrderDetailsManager { get; }
        private IDishManager DishManager { get; }

        public RestoController(IRestaurantManager restaurantManager, IOrderManager orderManager, ICityManager cityManager , IOrderDetailsManager orderDetailsManager , IDishManager dishManager)
        {
            RestaurantManager = restaurantManager;
            OrderManager = orderManager;
            CityManager = cityManager;
            OrderDetailsManager = orderDetailsManager;
            DishManager = dishManager;
        }

        public IActionResult Index()
        {
            //if no user logged in , redirect to login page

            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("LoginRestaurant", "Login");
            }

            //get the restaurant infos
            var myResto = RestaurantManager.GetRestaurant((int)HttpContext.Session.GetInt32("ID_RESTAURANT"));
            return View(myResto);
        }

        public IActionResult OrderHistory()
        {
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("LoginRestaurant", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_RESTAURANT");
            //get orders linked to this restaurant
            var myOrders = OrderManager.GetOrdersByRestaurant(id);

            //convert orders list to vm list. more user friendly data
            var orders_vm = new List<Models.OrderVM>();
            if (myOrders != null)
            {
                foreach (var order in myOrders)
                {

                    var resto = RestaurantManager.GetRestaurant(order.ID_RESTAURANT);
                    var restaurant_name = resto.NAME;

                    var cityName = CityManager.GetCity(resto.IDCITY).CITYNAME;

                    Models.OrderVM myOrderVM = new Models.OrderVM
                    {
                        order = order,
                        restaurantName = restaurant_name,
                        cityName = cityName


                    };

                    orders_vm.Add(myOrderVM);
                }
            }

            return View(orders_vm);


        }

        public IActionResult OrderDetails(int id)
        {
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("RestaurantLogin", "Login");
            }

            //get the order details specific to the asked order
            var orderDetails = OrderDetailsManager.GetOrderDetailsByOrder(id);
            var orderDetails_vm = new List<Models.OrderDetailsVM>();

            //convert orderderails list to vm list. more user friendly data
            foreach (var orderDetail in orderDetails)
            {
                var myDish = DishManager.GetDish(orderDetail.ID_DISH);

                var myOrder = OrderManager.GetOrder(id);
                myDish.PRICE = myDish.PRICE * ((decimal)1 - ((decimal)myOrder.DISCOUNT / 100));
                var totalPrice = myDish.PRICE * orderDetail.quantity;
                Models.OrderDetailsVM myOrderDetail = new Models.OrderDetailsVM
                {
                    orderDate = myOrder.ORDERDATE,
                    orderDetail = orderDetail,
                    dish = myDish,
                    totalPrice = totalPrice,
                    restaurantname = RestaurantManager.GetRestaurant(myDish.ID_RESTAURANT).NAME


                };

                orderDetails_vm.Add(myOrderDetail);
            }
            return View(orderDetails_vm);
        }


        public IActionResult OrderInbound()
        {
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("LoginRestaurant", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_RESTAURANT");
            //get during order list
            var myOrders = OrderManager.GetDuringOrdersForRestaurant(id);
            var orders_vm = new List<Models.OrderVM>();
            //convert orders list to vm list. more user friendly data
            if (myOrders != null)
            {
                foreach (var order in myOrders)
                {
                    var dish_id = OrderDetailsManager.GetOrderDetailsByOrder(order.ID_ORDER).First().ID_DISH;
                    var restaurant_id = DishManager.GetDish(dish_id).ID_RESTAURANT;
                    var resto = RestaurantManager.GetRestaurant(restaurant_id);
                    var restaurant_name = resto.NAME;

                    var cityName = CityManager.GetCity(resto.IDCITY).CITYNAME;

                    Models.OrderVM myOrderVM = new Models.OrderVM
                    {
                        order = order,
                        restaurantName = restaurant_name,
                        cityName = cityName


                    };

                    orders_vm.Add(myOrderVM);
                }
            }


            return View(orders_vm);
        }



        public IActionResult Statistics()
        {
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("LoginRestaurant", "Login");
            }
            //get the dishes produced by this restaurant
            var dishes = DishManager.GetDishes((int)HttpContext.Session.GetInt32("ID_RESTAURANT"));

            var myList = new List<Models.OrderQuantityVM>();
            foreach (var myDish in dishes)
            {
                int somme = 0;
                decimal CA = 0;
                var ordersDetails = OrderDetailsManager.GetOrderDetailsByDish(myDish.ID_DISH);
                //get orderderails linked to this dish
                if(ordersDetails!=null)
                {
                    foreach (var or in ordersDetails)
                    {
                        //for each orderdetails, increment the quantity buyed, and how much money was made
                        somme += or.quantity;
                        CA += or.quantity * ((100 - OrderManager.GetOrder(or.ID_ORDER).DISCOUNT) / 100) * myDish.PRICE;
                    }
                }

                Models.OrderQuantityVM myOrderQuantity = new Models.OrderQuantityVM
                {
                    dish = myDish,
                    quantity = somme,
                    CA = CA

                };

                myList.Add(myOrderQuantity);
            }



            return View(myList);
        }

        public IActionResult Profile()
        {
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("LoginRestaurant", "Login");
            }
            //get the restaurant infos
            int id = (int)HttpContext.Session.GetInt32("ID_RESTAURANT");
            var resto = RestaurantManager.GetRestaurant(id);
            return View(resto);

        }

        public IActionResult EditMenu()
        {
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("LoginRestaurant", "Login");
            }

            int id = (int)HttpContext.Session.GetInt32("ID_RESTAURANT");
            //get the dishes list of this restaurant
            var dishes = DishManager.GetDishes(id);
            var dishes_vm = new List<Models.DishVM>();
            //convert dishes list to vm list. more userfriendly data
            if (dishes != null)
            {
                foreach (var dish in dishes)
                {
                    var myCityID = RestaurantManager.GetRestaurant(id).IDCITY;

                    Models.DishVM myDishVM = new Models.DishVM
                    {
                        dish = dish,
                        restaurantName = RestaurantManager.GetRestaurant(id).NAME,
                        cityName = CityManager.GetCity(myCityID).CITYNAME


                    };

                    dishes_vm.Add(myDishVM);
                }
            }
            return View(dishes_vm);
        }


        public IActionResult EditDish(int id)
        {
            //get the dish infos
            var dish = DishManager.GetDish(id);
            return View(dish);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                //update the dish
                DishManager.UpdateDish(newDish.ID_DISH, newDish);
                return RedirectToAction("EditMenu", "Resto");


            }
            ModelState.AddModelError(string.Empty, "unvalid model");

            return View(newDish);
        }

        public IActionResult CreateDish()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                //add the new dish to the database
                newDish.ID_RESTAURANT = (int)HttpContext.Session.GetInt32("ID_RESTAURANT");
                DishManager.AddDish(newDish);
                return RedirectToAction("EditMenu", "Resto");


            }
            ModelState.AddModelError(string.Empty, "unvalid model");

            return View(newDish);
        }


        public IActionResult EditPassword()
        {
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("LoginRestaurant", "Login");
            }

            // get the restaurant infos
            int id = (int)HttpContext.Session.GetInt32("ID_RESTAURANT");
            var resto = RestaurantManager.GetRestaurant(id);
            return View(resto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPassword(Restaurant newResto)
        {
            if (ModelState.IsValid)
            {
                //try to see if the combinaison is already taken
                var staff = RestaurantManager.loginRestaurant(newResto.USERNAME, newResto.PASSWORD);
                // if it is not ( no password changed)
                if (staff == null)
                {
                    //update the restaurant in database
                    RestaurantManager.UpdateRestaurant(newResto.ID_RESTAURANT, newResto);
                    return RedirectToAction("Profile", "Resto");

                }
                ModelState.AddModelError(string.Empty, "password unchanged");

            }
            return View(newResto);
        }





    }
}

