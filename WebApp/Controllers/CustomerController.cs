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
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //get the informations of the logged customer
            var myCustomer = CustomerManager.GetCustomer((int)HttpContext.Session.GetInt32("ID_CUSTOMER"));
            return View(myCustomer);
        }

        public IActionResult OrderInbound()
        {
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //get the id of the logged customer
            int id = (int)HttpContext.Session.GetInt32("ID_CUSTOMER");

            //get his during order list
            var myOrders = OrderManager.GetDuringOrdersForCustomer(id) ;
            var orders_vm = new List<Models.OrderVM>();
            //transform the Order list to OrderVM list , more user friendly data
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
            //if no user logged in , redirect to login page

            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //get the orderDetails linked to an order
            var orderDetails = OrderDetailsManager.GetOrderDetailsByOrder(id);
            var orderDetails_vm = new List<Models.OrderDetailsVM>();

            //transform order details list to order details VM list. more user friendly data
            foreach(var orderDetail in orderDetails)
            {
                var myDish = DishManager.GetDish(orderDetail.ID_DISH);
                
                var myOrder = OrderManager.GetOrder(id);
                myDish.PRICE = myDish.PRICE * ((decimal)1 - ((decimal)myOrder.DISCOUNT / 100));//apply the discount to the unit price
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
            //if no user logged in , redirect to login page

            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // get the id of the logged customer
            int id = (int)HttpContext.Session.GetInt32("ID_CUSTOMER");

            //get his orders list
            var myOrders = OrderManager.GetOrdersByCustomer(id);
            var orders_vm = new List<Models.OrderVM>();

            //transform orders list to order VM list. more user friendly data
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
            //if no user logged in , redirect to login page

            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            
            //get the id of the logged user
            int id = (int)HttpContext.Session.GetInt32("ID_CUSTOMER");

            //get the infos of the logged customer
            var customer = CustomerManager.GetCustomer(id);
            return View(customer);

        }


        public IActionResult EditPassword()
        {
            //if no user logged in , redirect to login page
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            //get the logged customer id and his infos
            int id = (int)HttpContext.Session.GetInt32("ID_CUSTOMER");
            var customer = CustomerManager.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //return of the edit password view
        public IActionResult EditPassword(Customer newPasswordCustomer)
        {
            if (ModelState.IsValid)
            {

                //try to login the customer to see if the password changed or not
                var customer = CustomerManager.loginCustomer(newPasswordCustomer.USERNAME, newPasswordCustomer.PASSWORD);
                
                if (customer == null)
                {
                    //if it did change, update the password in the database and redirect to the profile page
                    CustomerManager.UpdateCustomer(newPasswordCustomer.ID_CUSTOMER, newPasswordCustomer);
                    return RedirectToAction("Profile", "Customer");

                }
                //else, add a error message to the view
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
        //return of the order annulation view
        public IActionResult OrderAnnulation(AnnulationVM annulationVM)
        {
            //get the order linked to the ID the user wrote
            var order = OrderManager.GetOrder(annulationVM.orderId);
            //if the order with this ID exists
            if(order!=null)
            {
                //create a new date in three hours to see if the order is still cancelable
                var date3h = DateTime.Now.AddHours(3);
                //if order isn't already delivered
                if (order.isDelivered == false)
                {

                    //if the order is still cancelable
                    if (order.ORDERDATE.CompareTo(date3h) > 0)
                    {

                        //see if the customer the client wrote is the owner of this order
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

                                //redirect to cancel confirmation view
                                return View("~/Views/Customer/CancelConfirmation.cshtml", order.ID_ORDER);


                            }
                        }
                        ModelState.AddModelError(string.Empty, "you are not the good person to delete this");
                        return View();

                    }
                    //if the order isn't cancelable anymore
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
