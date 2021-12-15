using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;

namespace WebApp.Controllers
{
    public class ConfirmationsController : Controller
    {
        private ICustomerManager CustomerManager { get; set; }
        private IStaffManager StaffManager { get; set; }
        private IRestaurantManager RestaurantManager { get; set; }


        public ConfirmationsController(ICustomerManager customerManager,IStaffManager staffManager, IRestaurantManager restaurantManager)
        {
            CustomerManager = customerManager;
            StaffManager = staffManager;
            RestaurantManager = restaurantManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConfirmCustomer(int id)
        {

            return View();
        }

        public IActionResult ConfirmStaff(int id)
        {
            return View();
        }

        public IActionResult ConfirmRestaurant(int id)
        {
            return View();
        }
    }
}
