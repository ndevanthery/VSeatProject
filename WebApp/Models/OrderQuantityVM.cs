using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebApp.Models
{
    public class OrderQuantityVM
    {
        public Dish dish { get; set; }

        public int quantity { get; set; }

        public decimal CA { get; set; }
    }
}
