using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using System.Net.Mail;
using System.Net;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private IOrderManager OrderManager { get; }
        private ICustomerManager CustomerManager { get; }

        private IStaffManager StaffManager { get; }

        private IRestaurantManager RestaurantManager { get; }

        public LoginController(IOrderManager orderManager, ICustomerManager customerManager , IStaffManager staffManager, IRestaurantManager restaurantManager)
        {
            OrderManager = orderManager;
            CustomerManager = customerManager;
            StaffManager = staffManager;
            RestaurantManager = restaurantManager;
        }

        public IActionResult Index()
        {
            //by default, the login is for customers
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserModel userModel)
        {
            if(ModelState.IsValid)
            {
                // try to log the customer in
                var customer = CustomerManager.loginCustomer(userModel.UserName, userModel.Password);
                //if log in is successful
                if(customer!=null)
                {

                    //set session customer id 
                    HttpContext.Session.SetInt32("ID_CUSTOMER", customer.ID_CUSTOMER);
                    return RedirectToAction("Index", "Customer");

                }
                ModelState.AddModelError(string.Empty, "Invalid username or password");

            }
            return View(userModel);
        }

        //view to create an account for a new customer
        public IActionResult createAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult createAccount(Customer newCustomer)
        {
            if (ModelState.IsValid)
            {

                //try to login the customer to see if the user/password combinaison is available
                var customer = CustomerManager.loginCustomer(newCustomer.USERNAME, newCustomer.PASSWORD);
                if (customer == null)
                {
                    //add the new customer to the database
                    newCustomer = CustomerManager.AddCustomer(newCustomer);

                    //send an email to the user to confirm his account
                    ConfirmationsController.sendEmailCustomer(newCustomer);

                    //redirects him to the customer login
                    return RedirectToAction("Index", "Login");
                    

                }
                //if the combinaison isn't available, add an error to the view
                ModelState.AddModelError(string.Empty, "this username is already used");

            }
            return View(newCustomer);
        }



        public IActionResult LoginStaff()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginStaff(UserModel userModel)
        {
            if (ModelState.IsValid)
            {

                //try to login the staff to see if the user/password combinaison is right

                var staff = StaffManager.loginStaff(userModel.UserName, userModel.Password);
                //if log in is successful

                if (staff != null)
                {
                    //set the session  ID_customer 
                    HttpContext.Session.SetInt32("ID_STAFF", staff.ID_STAFF);
                    return RedirectToAction("Index", "Staff");

                }
                ModelState.AddModelError(string.Empty, "Invalid username or password");

            }
            return View(userModel);
        }

        public IActionResult CreateStaff()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStaff(Staff newStaff)
        {
            if (ModelState.IsValid)
            {

                //try to login the customer to see if the user/password combinaison is available
                var staff = StaffManager.loginStaff(newStaff.USERNAME, newStaff.PASSWORD);
                if (staff == null)
                {
                    //add the new staff to the database
                    StaffManager.AddStaff(newStaff);

                    //redirects him to the customer login
                    return RedirectToAction("LoginStaff", "Login");


                }
                ModelState.AddModelError(string.Empty, "this username is already used");

            }
            return View(newStaff);
        }






        public IActionResult LoginRestaurant()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginRestaurant(UserModel userModel)
        {
            if (ModelState.IsValid)
            {

                // try to login the restaurant to see if username/password combinaison is correct
                var restaurant = RestaurantManager.loginRestaurant(userModel.UserName, userModel.Password);
                //if log in is successful

                if (restaurant != null)
                {
                    //set the session  ID restaurant 

                    HttpContext.Session.SetInt32("ID_RESTAURANT", restaurant.ID_RESTAURANT);
                    return RedirectToAction("Index", "Resto");

                }
                ModelState.AddModelError(string.Empty, "Invalid username or password");

            }
            return View(userModel);
        }

        public IActionResult CreateRestaurant()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRestaurant(Restaurant newRestaurant)
        {
            if (ModelState.IsValid)
            {
                //try to login the customer to see if the user/password combinaison is available

                var staff = RestaurantManager.loginRestaurant(newRestaurant.USERNAME, newRestaurant.PASSWORD);
                if (staff == null)
                {
                    //add the new staff to the database
                    RestaurantManager.AddRestaurant(newRestaurant);

                    //redirects him to the customer login
                    return RedirectToAction("LoginRestaurant", "Login");


                }
                ModelState.AddModelError(string.Empty, "this username is already used");

            }
            return View(newRestaurant);
        }





        public IActionResult Details(Customer newCustomer)
        {
            return View(newCustomer);
        }


    }
}
