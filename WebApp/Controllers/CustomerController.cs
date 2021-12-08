using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private IOrderManager OrderManager { get; }
        private ICustomerManager CustomerManager { get; }

        public CustomerController(IOrderManager orderManager,ICustomerManager customerManager)
        {
            OrderManager = orderManager;
            CustomerManager = customerManager;
        }
     
        public IActionResult OrderInbound()
        {
            return View(OrderManager.GetOrders());
        }
        public IActionResult OrderHistory()
        {
            return View();
        }

    }
}
