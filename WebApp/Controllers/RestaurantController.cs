﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using WebApp.Models;
using DTO;
using System.Web.Helpers;

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

        private IStaffManager StaffManager { get; }
        private ICodePromoManager CodePromoManager { get; }

        public RestaurantController(IRestaurantManager restaurantManager, ICityManager cityManager , IDishManager dishManager, IRestoTypeManager restoTypeManager, IOrderManager orderManager , IOrderDetailsManager orderDetailsManager, IStaffManager staffManager , ICodePromoManager codePromoManager)
        {
            RestaurantManager = restaurantManager;
            CityManager = cityManager;
            DishManager = dishManager;
            RestoTypeManager = restoTypeManager;
            OrderManager = orderManager;
            OrderDetailsManager = orderDetailsManager;
            StaffManager = staffManager;
            CodePromoManager = codePromoManager;
        }

        public IActionResult Index()
        {
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            //get list of cities
            var citys = CityManager.GetCities();
            

            return View(citys);
        }

        public IActionResult RestaurantsList(int idCity)
        {
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //get list of restaurants in a city
            var restaurants = RestaurantManager.GetRestaurantsByCity(idCity);
            var restaurants_vm = new List<Models.RestaurantVM>();

            //convert the list of restaurant to vm list. more user friendly data
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
            //if no user logged in , redirect to login page

            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //get list of dishes
            var dishes = DishManager.GetDishes(idRestaurant);
            var dishes_vm = new List<Models.DishVM>();
            //convert list of dishes to vm list. more user friendly data
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
            //if no user logged in , redirect to login page

            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //get list of dishes
            var dishes = DishManager.GetDishes(idRestaurant);
            var myModel = new OrderDishCodePromo();
            myModel.orderDishes = new List<OrderDishVM>();
            myModel.codePromo = "";
            myModel.discount = 0;
            myModel.hour = "11:30" ;

            //get the list of dishes and converts it to vm list. more user friendly data
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
                        quantity = 0,
                        



                    };


                    myModel.orderDishes.Add(myDishVM);
                }
            }
            return View(myModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CommandPage(OrderDishCodePromo myOrders)
        {

            if (ModelState.IsValid)
            {
                
                if (myOrders != null)
                {

                    ///////////////////////////////////////////////////////////
                    ///             ERRORS MANAGMENT                        ///
                    ///////////////////////////////////////////////////////////
                   
                    var codePromo = CodePromoManager.GetCode(myOrders.codePromo);
                    //if the code promo the user tried to use doesn't exist, add error to view
                    if(codePromo==null && myOrders.codePromo !=null)
                    {
                        ModelState.AddModelError(string.Empty, "the used promo code doesn't exist :(");
                        return View(myOrders);
                    }
                    else
                    {
                        //if the code promo exists, but not for this restaurant , add error to view
                        if(myOrders.codePromo != null)
                        {
                            if (codePromo.ID_RESTAURANT != myOrders.orderDishes.First().dish.ID_RESTAURANT)
                            {
                                ModelState.AddModelError(string.Empty, "the used promo code isn't available for this restaurant :(");
                                return View(myOrders);
                            }
                        }
                        
                    }
                    
                    
                    decimal somme = 0;

                    var discountToDo = 0;
                    //the code promo is correct if the code arrived here
                    //if code promo is null, no discount
                    if(codePromo!=null)
                    {
                        discountToDo = codePromo.DISCOUNT;
                        myOrders.discount = discountToDo;

                    }
                    //calculate sum of the order
                    foreach (var order in myOrders.orderDishes)
                    {
                        somme += order.dish.PRICE * order.quantity * ((decimal)1-((decimal)discountToDo/100));
                    }
                    //create one order 
                    var idCity = CityManager.GetCity(myOrders.orderDishes.First().cityname).IDCITY;
                    var staffDispo = StaffManager.GetStaffs(idCity);

                    DateTime datetimeNow = DateTime.Now;
                    var hour = int.Parse(myOrders.hour.Split(":")[0]);
                    var minute = int.Parse(myOrders.hour.Split(":")[1]);
                    DateTime deliveryTime = new DateTime(datetimeNow.Year, datetimeNow.Month, datetimeNow.Day, hour, minute, 0);


                    var idStaff = 0;
                    if(staffDispo!=null)
                    {
                        foreach (var staff in staffDispo)
                        {
                            if(OrderManager.nbOrderAtTimeForStaff(staff.ID_STAFF,deliveryTime)<5)
                            {
                                idStaff = staff.ID_STAFF;
                                break;
                            }
                            
                        }
                    }
                    
                    if (idStaff == 0)
                    {
                        ModelState.AddModelError(string.Empty, "no deliverer Disponible anymore");
                        return View(myOrders);

                    }

                    if(somme>0)
                    {
                        
                        if(deliveryTime<datetimeNow)
                        {
                            ModelState.AddModelError(string.Empty, "you're delivery time is already passed. please select another");
                            return View(myOrders);
                        }
                        
                        Order myNewOrder = new Order
                        {
                            ID_CUSTOMER = (int)HttpContext.Session.GetInt32("ID_CUSTOMER"),
                            ORDERDATE = deliveryTime,
                            DISCOUNT = discountToDo,
                            TOTALPRICE = somme,
                            ID_RESTAURANT = myOrders.orderDishes.First().dish.ID_RESTAURANT,
                            ID_STAFF = idStaff




                        };
                        //add the order to database
                        Order myOrder_added = OrderManager.AddOrder(myNewOrder);
                        myOrders.orderId = myOrder_added.ID_ORDER;
                        // create multiple orderDetails with the same order ID
                        // when the quantity == 0 , no order details created
                        foreach (var order in myOrders.orderDishes)
                        {
                            if (order.quantity > 0)
                            {
                                OrderDetails myNewOrderDetail = new OrderDetails
                                {
                                    ID_DISH = order.dish.ID_DISH,
                                    ID_ORDER = myOrder_added.ID_ORDER,
                                    quantity = order.quantity
                                };
                                //add order detail to database

                                OrderDetailsManager.AddOrderDetails(myNewOrderDetail);
                            }

                        }

                        

                        return View("~/Views/Restaurant/CommandConfirmation.cshtml", myOrders);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "command something please");
                        return View(myOrders);
                    }
                    

                }
                ModelState.AddModelError(string.Empty, "Invalid username or password");

            }
            return View(myOrders);
        }











    }
}
