using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class StaffController : Controller
    {
        private IStaffManager StaffManager { get; }

        private IOrderManager OrderManager { get; }

        private IOrderDetailsManager OrderDetailsManager { get; }

        private IDishManager DishManager { get; }

        private IRestaurantManager RestaurantManager { get; }

        private ICityManager CityManager { get; }


        public StaffController(IStaffManager staffManager , IOrderManager orderManager , IOrderDetailsManager orderDetailsManager, IDishManager dishManager, IRestaurantManager restaurantManager, ICityManager cityManager)
        {
            StaffManager = staffManager;
            OrderManager = orderManager;
            OrderDetailsManager = orderDetailsManager;
            DishManager = dishManager;
            RestaurantManager = restaurantManager;
            CityManager = cityManager;


        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("ID_STAFF") == null)
            {
                return RedirectToAction("LoginStaff", "Login");
            }
            var myStaff = StaffManager.GetStaff((int)HttpContext.Session.GetInt32("ID_STAFF"));
            return View(myStaff);
        }


        public IActionResult DeliveryHistory()
        {
            if (HttpContext.Session.GetInt32("ID_STAFF") == null)
            {
                return RedirectToAction("LoginStaff", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_STAFF");
            var myOrders = OrderManager.GetOrdersByStaff(id);
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
            if (HttpContext.Session.GetInt32("ID_STAFF") == null)
            {
                return RedirectToAction("StaffLogin", "Login");
            }
            var orderDetails = OrderDetailsManager.GetOrderDetailsByOrder(id);
            var orderDetails_vm = new List<Models.OrderDetailsVM>();
            foreach (var orderDetail in orderDetails)
            {
                var myDish = DishManager.GetDish(orderDetail.ID_DISH);
                var totalPrice = myDish.PRICE * orderDetail.quantity;
                Models.OrderDetailsVM myOrderDetail = new Models.OrderDetailsVM
                {
                    orderDate = OrderManager.GetOrder(id).ORDERDATE,
                    orderDetail = orderDetail,
                    dish = myDish,
                    totalPrice = totalPrice,
                    restaurantname = RestaurantManager.GetRestaurant(myDish.ID_RESTAURANT).NAME


                };

                orderDetails_vm.Add(myOrderDetail);
            }
            return View(orderDetails_vm);
        }

        public IActionResult ToDeliver()
        {
            if (HttpContext.Session.GetInt32("ID_STAFF") == null)
            {
                return RedirectToAction("LoginStaff", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_STAFF");
            var myOrders = OrderManager.GetDuringOrdersForStaff(id);
            var orders_vm = new List<Models.OrderVM>();

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


    }
}
