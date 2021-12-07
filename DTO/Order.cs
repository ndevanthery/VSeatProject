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

        public int ID_CUSTOMER { get; set; }

        public DateTime ORDERDATE { get; set; }


        public int DISCOUNT { get; set; }

        public decimal TOTALPRICE { get; set; }

        // ajouter un CustomerID dans order ! 

        public override string ToString()
        {
            return "ID ORDER:" + ID_ORDER +
                    " / ID CUSTOMER:" + ID_CUSTOMER +
                   " / ORDER DATE:" + ORDERDATE +
                   " / DISCOUNT:" + DISCOUNT +
                   " / TOTAL PRICE:" + TOTALPRICE;
        }

    }
}
