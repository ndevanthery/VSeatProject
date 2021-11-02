using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Order
    {

        public int ID_ORDER { get; set; }

        public DateTime ORDERDATE { get; set; }

        public DateTime DELIVERYTIME { get; set; }

        public int DISCOUNT { get; set; }

        public double TOTALPRICE { get; set; }

        // ajouter un CustomerID dans order ! 

        public override string ToString()
        {
            return "ID ORDER : " + ID_ORDER +
                   "ORDER DATE : " + ORDERDATE +
                   "DELIVERY TIME : " + DELIVERYTIME +
                   "DISCOUNT : " + DISCOUNT +
                   "TOTAL PRICE : " + TOTALPRICE;
        }

    }
}
