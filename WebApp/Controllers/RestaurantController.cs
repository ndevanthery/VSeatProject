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

        public IActionResult Index()
        {
            return View(myRestos);
        }
    }
}
