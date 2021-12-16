using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApp.Models
{
    public class OrderDishCodePromo
    {

        public List<OrderDishVM> orderDishes { get; set; }
        public string codePromo { get; set; }
        public int discount { get; set; }

        public DateTime date{get;set;}

    }
}
