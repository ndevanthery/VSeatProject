using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApp.Models;

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
       

        //this Action result will be called when the user press the button "login"
        //After putting his username and password 
        public IActionResult ProcessLogin(UserModel userModel)
        {
            var customers = CustomerManager.GetCustomers();
            foreach (var customer in customers)
            {
                if (customer.USERNAME == userModel.UserName && customer.PASSWORD == userModel.Password)
                {
                    return View("LoginSuccess", userModel);
                }
               
            }
            return View("Loginfailure", userModel);
        }
    }
}
