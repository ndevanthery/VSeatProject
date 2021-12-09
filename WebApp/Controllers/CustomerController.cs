using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;

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
            var myCustomer = CustomerManager.GetCustomer((int)HttpContext.Session.GetInt32("ID_CUSTOMER"));
            return View(myCustomer);
        }

        public IActionResult OrderInbound()
        {
            int id = (int)HttpContext.Session.GetInt32("ID_CUSTOMER");
            var myOrders = OrderManager.GetOrdersByCustomer(id);
            var orders_vm = new List<Models.OrderVM>();
            foreach(var order in myOrders)
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
            return View(orders_vm);
        }


        public IActionResult OrderDetails(int id)
        {
            var orderDetails = OrderDetailsManager.GetOrderDetailsByOrder(id);
            var orderDetails_vm = new List<Models.OrderDetailsVM>();
            foreach(var orderDetail in orderDetails)
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
        public IActionResult OrderHistory()
        {
            return View();
        }

    }
}
