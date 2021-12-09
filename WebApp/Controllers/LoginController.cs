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


namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private IOrderManager OrderManager { get; }
        private ICustomerManager CustomerManager { get; }

        public LoginController(IOrderManager orderManager, ICustomerManager customerManager)
        {
            OrderManager = orderManager;
            CustomerManager = customerManager;
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
                    CustomerManager.AddCustomer(newCustomer);

                    return RedirectToAction("Index", "Login");
                    

                }
                ModelState.AddModelError(string.Empty, "this username is already used");

            }
            return View(newCustomer);
        }

        public IActionResult Details(Customer newCustomer)
        {
            return View(newCustomer);
        }


    }
}
