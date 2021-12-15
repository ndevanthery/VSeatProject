﻿using BLL;
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
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("LoginRestaurant", "Login");
            }
            var myResto = RestaurantManager.GetRestaurant((int)HttpContext.Session.GetInt32("ID_RESTAURANT"));
            return View(myResto);
        }

        public IActionResult OrderHistory()
        {
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("LoginRestaurant", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_RESTAURANT");
            var myOrders = OrderManager.GetOrdersByRestaurant(id);
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
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("RestaurantLogin", "Login");
            }
            var orderDetails = OrderDetailsManager.GetOrderDetailsByOrder(id);
            var orderDetails_vm = new List<Models.OrderDetailsVM>();
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
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("LoginRestaurant", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_RESTAURANT");
            var myOrders = OrderManager.GetDuringOrdersForRestaurant(id);
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



        public IActionResult Statistics()
        {
            var dishes = DishManager.GetDishes((int)HttpContext.Session.GetInt32("ID_RESTAURANT"));

            var myList = new List<Models.OrderQuantityVM>();
            foreach (var myDish in dishes)
            {
                int somme = 0;
                decimal CA = 0;
                var ordersDetails = OrderDetailsManager.GetOrderDetailsByDish(myDish.ID_DISH);
                foreach(var or in ordersDetails)
                {
                    somme += or.quantity;
                    CA += or.quantity*((100 - OrderManager.GetOrder(or.ID_ORDER).DISCOUNT) / 100 )* myDish.PRICE;
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
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_RESTAURANT");
            var customer = RestaurantManager.GetRestaurant(id);
            return View(customer);

        }

        public IActionResult EditMenu()
        {
            if (HttpContext.Session.GetInt32("ID_RESTAURANT") == null)
            {
                return RedirectToAction("LoginRestaurant", "Login");
            }
            int id = (int)HttpContext.Session.GetInt32("ID_RESTAURANT");
            var dishes = DishManager.GetDishes(id);
            var dishes_vm = new List<Models.DishVM>();
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
            var dish = DishManager.GetDish(id);
            return View(dish);
        }




    }
}

