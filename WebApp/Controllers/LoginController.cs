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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserModel userModel)
        {
            if(ModelState.IsValid)
            {
                var customer = CustomerManager.loginCustomer(userModel.UserName, userModel.Password);
                if(customer!=null)
                {
                    HttpContext.Session.SetInt32("ID_CUSTOMER", customer.ID_CUSTOMER);
                    return RedirectToAction("Index", "Customer");

                }
                ModelState.AddModelError(string.Empty, "Invalid username or password");

            }
            return View(userModel);
        }

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
                var customer = CustomerManager.loginCustomer(newCustomer.USERNAME, newCustomer.PASSWORD);
                if (customer == null)
                {
                    newCustomer = CustomerManager.AddCustomer(newCustomer);
                    sendEmail(newCustomer);
                    return RedirectToAction("Index", "Login");
                    

                }
                ModelState.AddModelError(string.Empty, "this username is already used");

            }
            return View(newCustomer);
        }

        public void sendEmail(Customer receiver)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("vseat.noreply@gmail.com", "AdminHevs01"),
                EnableSsl = true,
            };

            ///////////////////////////////////////////////////////
            ///add a link to confirm EMAIL
            ///////////////////////////////////////////////////////



            smtpClient.Send("vseat.noreply@gmail.com", receiver.EMAIL, "Confirmation of account creation", "Bonjour " + receiver.FIRSTNAME + " " + receiver.LASTNAME + "\n Merci de confirmer votre adresse e - mail en appuyant sur le lien ci - dessous.");
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
                var staff = StaffManager.loginStaff(userModel.UserName, userModel.Password);
                if (staff != null)
                {
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
                var staff = StaffManager.loginStaff(newStaff.USERNAME, newStaff.PASSWORD);
                if (staff == null)
                {
                    StaffManager.AddStaff(newStaff);

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
                var restaurant = RestaurantManager.loginRestaurant(userModel.UserName, userModel.Password);
                if (restaurant != null)
                {
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
                var staff = RestaurantManager.loginRestaurant(newRestaurant.USERNAME, newRestaurant.PASSWORD);
                if (staff == null)
                {
                    RestaurantManager.AddRestaurant(newRestaurant);

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
