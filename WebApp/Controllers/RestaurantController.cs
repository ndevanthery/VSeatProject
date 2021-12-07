using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;

namespace WebApp.Controllers
{
    public class RestaurantController : Controller
    {

        private IRestaurantManager RestaurantManager { get; }
        private ICityManager CityManager { get; }

        private IDishManager DishManager { get; }

        private IRestoTypeManager RestoTypeManager { get; }

        public RestaurantController(IRestaurantManager restaurantManager, ICityManager cityManager , IDishManager dishManager, IRestoTypeManager restoTypeManager)
        {
            RestaurantManager = restaurantManager;
            CityManager = cityManager;
            DishManager = dishManager;
            RestoTypeManager = restoTypeManager;
        }

        public IActionResult Index()
        {
            var citys = CityManager.GetCities();
            foreach(var city in citys)
            {
                Console.WriteLine(city.ToString());
            }
            return View(citys);
        }

        public IActionResult RestaurantsList(int idCity)
        {

            var restaurants = RestaurantManager.GetRestaurantsByCity(idCity);
            var restaurants_vm = new List<Models.RestaurantVM>();

            foreach(var resto in restaurants)
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
            return View(restaurants_vm);
        }

        public IActionResult DishesList(int idRestaurant)
        {
            var dishes = DishManager.GetDishes(idRestaurant);
            
            return View(dishes);
        }
    }
}
