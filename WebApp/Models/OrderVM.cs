using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebApp.Models
{
    public class OrderVM
    {
        public Order order { get; set; }

        public string restaurantName { get; set; }

        public string cityName { get; set; }

    }
}
