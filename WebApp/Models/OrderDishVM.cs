using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebApp.Models
{
    public class OrderDishVM
    {
        public Dish dish { get; set; }
        
        public string restaurantName { get; set; }

        public string cityname { get; set; }
        public int quantity { get; set; }
    }
}
