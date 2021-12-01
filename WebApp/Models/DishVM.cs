using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DishVM
    {

        public ImageFormat IMAGE { get; set; }

        public string NAME { get; set; }

        public double PRICE { get; set; }



        public override string ToString()
        {
            return " / IMAGE:" + IMAGE +
                   " / NAME:" + NAME +
                   " / PRICE:" + PRICE ;
        }
    }
}
