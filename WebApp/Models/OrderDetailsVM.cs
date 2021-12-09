using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OrderDetailsVM
    {
        public DateTime orderDate { get; set; }
        public OrderDetails orderDetail { get; set; }

        public Dish dish { get; set; }

        public decimal totalPrice { get; set; }

        public string restaurantname { get; set; }
    }
}
