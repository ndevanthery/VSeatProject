using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;

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
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var citys = CityManager.GetCities();
            foreach(var city in citys)
            {
                Console.WriteLine(city.ToString());
            }
            return View(citys);
        }

        public IActionResult RestaurantsList(int idCity)
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var restaurants = RestaurantManager.GetRestaurantsByCity(idCity);
            var restaurants_vm = new List<Models.RestaurantVM>();
            if(restaurants!=null)
            {
                foreach (var resto in restaurants)
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
            }


            
            return View(restaurants_vm);
        }

        public IActionResult DishesList(int idRestaurant)
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var dishes = DishManager.GetDishes(idRestaurant);
            var dishes_vm = new List<Models.DishVM>();
            if (dishes != null)
            {
                foreach (var dish in dishes)
                {
                    var myCityID = RestaurantManager.GetRestaurant(idRestaurant).IDCITY;

                    Models.DishVM myDishVM = new Models.DishVM
                    {
                        dish = dish,
                        restaurantName = RestaurantManager.GetRestaurant(idRestaurant).NAME,
                        cityName = CityManager.GetCity(myCityID).CITYNAME


                    };

                    dishes_vm.Add(myDishVM);
                }
            }
            return View(dishes_vm);
        }

        public IActionResult CommandPage(int idRestaurant)
        {
            if (HttpContext.Session.GetInt32("ID_CUSTOMER") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var dishes = DishManager.GetDishes(idRestaurant);
            var dishes_vm = new List<Models.DishVM>();
            if (dishes != null)
            {
                foreach (var dish in dishes)
                {
                    var myCityID = RestaurantManager.GetRestaurant(idRestaurant).IDCITY;

                    Models.DishVM myDishVM = new Models.DishVM
                    {
                        dish = dish,
                        restaurantName = RestaurantManager.GetRestaurant(idRestaurant).NAME,
                        cityName = CityManager.GetCity(myCityID).CITYNAME


                    };

                    dishes_vm.Add(myDishVM);
                }
            }
            return View(dishes_vm);
        }




    }
}
