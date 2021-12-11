using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class RestoController : Controller
    {
        private IRestaurantManager RestaurantManager { get; }

        public RestoController(IRestaurantManager restaurantManager)
        {
            RestaurantManager = restaurantManager;
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


    }
}
