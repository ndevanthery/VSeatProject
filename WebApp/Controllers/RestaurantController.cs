using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class RestaurantController : Controller
    {


        public static List<Models.Restaurant> myRestos = new List<Models.Restaurant>
        {
            new Models.Restaurant {ID_RESTAURANT = 1 , IDCITY =5 , IDTYPE =1 , NAME="jet pizza",ADRESS="", PHONENUMBER ="01234" , USERNAME = "jetPizza" , PASSWORD="askfdn"},
            new Models.Restaurant {ID_RESTAURANT = 2 , IDCITY =4 , IDTYPE =5 , NAME="jet za",ADRESS="", PHONENUMBER ="567" , USERNAME = "saifnasf" , PASSWORD="askfdn"},
            new Models.Restaurant {ID_RESTAURANT = 3 , IDCITY =3 , IDTYPE =4 , NAME="holy cow",ADRESS="", PHONENUMBER ="89" , USERNAME = "jsafneaf" , PASSWORD="askfdn"},
            new Models.Restaurant {ID_RESTAURANT = 4 , IDCITY =2 , IDTYPE =3 , NAME="jet",ADRESS="", PHONENUMBER ="1" , USERNAME = "jeifewfeetPizza" , PASSWORD="askfdn"},
            new Models.Restaurant {ID_RESTAURANT = 5 , IDCITY =1 , IDTYPE =1 , NAME="piza",ADRESS="", PHONENUMBER ="28412348" , USERNAME = "eaifjw c " , PASSWORD="askfdn"},

        };

        public static List<Models.Dish> myDishes = new List<Models.Dish>
        {
            new Models.Dish { ID_DISH = 1 , ID_RESTAURANT= 1, NAME="kebab poulet" , PRICE=10 },
            new Models.Dish { ID_DISH = 2 , ID_RESTAURANT= 1, NAME="kebab agneau" , PRICE=10 },
            new Models.Dish { ID_DISH = 3 , ID_RESTAURANT= 1, NAME="kebab crevette" , PRICE=15 },
            new Models.Dish { ID_DISH = 4 , ID_RESTAURANT= 1, NAME="golden apple" , PRICE=100 },
            new Models.Dish { ID_DISH = 5 , ID_RESTAURANT= 1, NAME="kebab caviar" , PRICE=1234 },
            new Models.Dish { ID_DISH = 6 , ID_RESTAURANT= 2, NAME="kebab" , PRICE=10 },
            new Models.Dish { ID_DISH = 7 , ID_RESTAURANT= 2, NAME="kebab crepe" , PRICE=1512 },
            new Models.Dish { ID_DISH = 8 , ID_RESTAURANT= 3, NAME="dfssdgers" , PRICE=5 },
            new Models.Dish { ID_DISH = 9 , ID_RESTAURANT= 3, NAME="the G.O.A.T" , PRICE=100000 },
            new Models.Dish { ID_DISH = 10 , ID_RESTAURANT= 4, NAME="kebab saignant" , PRICE=5168 },
            new Models.Dish { ID_DISH = 11 , ID_RESTAURANT= 4, NAME="cafards" , PRICE=1523 },
            new Models.Dish { ID_DISH = 12 , ID_RESTAURANT= 4, NAME="chupapi" , PRICE=667 },
            new Models.Dish { ID_DISH = 13 , ID_RESTAURANT= 5, NAME="dfwafaef" , PRICE=20853 },
            new Models.Dish { ID_DISH = 14 , ID_RESTAURANT= 5, NAME="kffsefsdf" , PRICE=012354 },
            new Models.Dish { ID_DISH = 15 , ID_RESTAURANT= 5, NAME="kebfesfsdesulet" , PRICE=232145253 }

        };

        public IActionResult Index()
        {
            return View(myRestos);
        }

        public IActionResult Details(int id)
        {
            var dishes = myDishes.Where(d => d.ID_RESTAURANT == id);
            
            return View(dishes);
        }
    }
}
