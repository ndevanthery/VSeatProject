using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private IOrderManager OrderManager { get; }
        private ICustomerManager CustomerManager { get; }

        private IOrderDetailsManager OrderDetailsManager { get; }

        private IDishManager DishManager { get; }

        private IRestaurantManager RestaurantManager { get; }

        private ICityManager CityManager { get; }

        public CustomerController(IOrderManager orderManager,ICustomerManager customerManager, IOrderDetailsManager orderDetailsManager , IDishManager dishManager , IRestaurantManager restaurantManager , ICityManager cityManager)
        {
            OrderManager = orderManager;
            CustomerManager = customerManager;
            OrderDetailsManager = orderDetailsManager;
            DishManager = dishManager;
            RestaurantManager = restaurantManager;
            CityManager = cityManager;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var myCustomer = CustomerManager.GetCustomer((int)HttpContext.Session.GetInt32("ID_CUSTOMER"));
            return View(myCustomer);
        }

        public IActionResult OrderInbound()
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_CUSTOMER");
            var myOrders = OrderManager.GetDuringOrdersForCustomer(id) ;
            var orders_vm = new List<Models.OrderVM>();

            if (myOrders!=null)
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


        public IActionResult OrderDetails(int id)
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var orderDetails = OrderDetailsManager.GetOrderDetailsByOrder(id);
            var orderDetails_vm = new List<Models.OrderDetailsVM>();
            foreach(var orderDetail in orderDetails)
            {
                var myDish = DishManager.GetDish(orderDetail.ID_DISH);
                
                var myOrder = OrderManager.GetOrder(id);
                myDish.PRICE = myDish.PRICE * ((decimal)1 - ((decimal)myOrder.DISCOUNT / 100));
                var totalPrice = myDish.PRICE * orderDetail.quantity ;
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
        public IActionResult OrderHistory()
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_CUSTOMER");
            var myOrders = OrderManager.GetOrdersByCustomer(id);
            var orders_vm = new List<Models.OrderVM>();
            if(myOrders!=null)
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

        public IActionResult Profile()
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_CUSTOMER");
            var customer = CustomerManager.GetCustomer(id);
            return View(customer);

        }


        public IActionResult EditPassword()
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_CUSTOMER");
            var customer = CustomerManager.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPassword(Customer newPasswordCustomer)
        {
            if (ModelState.IsValid)
            {
                var customer = CustomerManager.loginCustomer(newPasswordCustomer.USERNAME, newPasswordCustomer.PASSWORD);
                if (customer == null)
                {
                    CustomerManager.UpdateCustomer(newPasswordCustomer.ID_CUSTOMER, newPasswordCustomer);
                    return RedirectToAction("Profile", "Customer");

                }
                ModelState.AddModelError(string.Empty, "password unchanged");

            }
            return View(newPasswordCustomer);
        }

        public IActionResult OrderAnnulation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderAnnulation(AnnulationVM annulationVM)
        {
            var order = OrderManager.GetOrder(annulationVM.orderId);
            if(order!=null)
            {
                var date3h = DateTime.Now.AddHours(3);
                if (order.isDelivered == false)
                {


                    if (order.ORDERDATE.CompareTo(date3h) > 0)
                    {
                        var customer = CustomerManager.GetCustomer(order.ID_CUSTOMER);
                        if (customer.FIRSTNAME.ToLower() == annulationVM.firstName.ToLower())
                        {
                            if (customer.LASTNAME.ToLower() == annulationVM.lastName.ToLower())
                            {
                                //3 hours before, first name correct, lastname correct, order id exists

                                //delete orderDetails and order
                                var orderDetails = OrderDetailsManager.GetOrderDetailsByOrder(order.ID_ORDER);

                                OrderDetailsManager.DeleteOrderDetails(order.ID_ORDER);
                                OrderManager.DeleteOrder(order.ID_ORDER);


                                //map to annulation confirmation
                                //List<OrderDishVM> myOrders = new List<OrderDishVM>();

                                //foreach(var orderDetail in orderDetails)
                                //{
                                //    var dish = DishManager.GetDish(orderDetail.ID_DISH);
                                //    var restaurant = RestaurantManager.GetRestaurant(dish.ID_RESTAURANT);
                                //    var city = CityManager.GetCity(restaurant.IDCITY);
                                //    var myOrder = new OrderDishVM
                                //    {
                                //        dish = dish,
                                //        restaurantName = restaurant.NAME,
                                //        cityname = city.CITYNAME,
                                //        quantity = orderDetail.quantity
                                //    };
                                //    myOrders.Add(myOrder);
                                //}

                                return View("~/Views/Customer/CancelConfirmation.cshtml", order.ID_ORDER);


                            }
                        }
                        ModelState.AddModelError(string.Empty, "you are not the good person to delete this");
                        return View();

                    }
                    else
                    {
                        if (order.ORDERDATE < DateTime.Now)
                        {
                            ModelState.AddModelError(string.Empty, "this order has already been delivered!!!");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "this is too late to cancel. you have to do it 3 hours before delivery time");
                        }
                        return View();
                    }
                }
                ModelState.AddModelError(string.Empty, "this order is already delivered");
                return View();


            }
            ModelState.AddModelError(string.Empty, "this order doesn't exist");

            return View();
        }


    }
}
