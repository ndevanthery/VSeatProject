using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using BLL;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApp.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantManager RestaurantManager { get; }
        private IDishManager DishManager { get; }

        public RestaurantController(IRestaurantManager restaurantManager , IDishManager dishManager)
        {
            RestaurantManager = restaurantManager;
            DishManager = dishManager;
        }

        public IActionResult Index()
        {

            var restos = RestaurantManager.GetRestaurants();
            return View(restos);
        }

        public IActionResult Details(int id)
        {
            var dishes = DishManager.GetDishes(id);

            return View(dishes);
        }
    }
}
