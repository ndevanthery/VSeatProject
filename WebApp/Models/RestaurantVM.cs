using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebApp.Models
{
    public class RestaurantVM
    {
        public Restaurant restaurant { get; set; }
        public string RESTAURANTNAME { get; set; }

        public string CITYNAME { get; set; }

        public string TYPENAME { get; set; }

    }
}
