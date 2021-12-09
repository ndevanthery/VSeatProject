using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDetails
    {
        public int ID_DISH { get; set; }

        public int ID_ORDER { get; set; }

        public int quantity { get; set; }

        public override string ToString()
        {
            return "ID DISH:" + ID_DISH +
                   " / ID ORDER:" + ID_ORDER;
        }


    }
}
