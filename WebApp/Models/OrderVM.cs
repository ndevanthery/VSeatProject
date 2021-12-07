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

        public int ID_ORDER { get; set; }

        public int ID_CUSTOMER { get; set; }

        public DateTime ORDERDATE { get; set; }


        public int DISCOUNT { get; set; }

        public decimal TOTALPRICE { get; set; }

    }
}
