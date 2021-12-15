using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Dish
    {
        public int ID_DISH { get; set; }

        public int ID_RESTAURANT { get; set; }

        public string NAME { get; set; }

        public decimal PRICE { get; set; }

        public string image_url { get; set; }

        public override string ToString()
        {
            return "ID DISH:" + ID_DISH +
                   " / ID RESTAURANT:" + ID_RESTAURANT +
                   " / NAME:" + NAME +
                   " / PRICE:" + PRICE ;
        }
    }
}
