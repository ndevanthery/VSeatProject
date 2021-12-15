using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Restaurant
    {
        public int ID_RESTAURANT { get; set; }

        public int IDCITY { get; set; }

        public int IDTYPE { get; set; }

        public string NAME { get; set; }

        public string ADRESS { get; set; }

        public string PHONENUMBER { get; set; }

        public string USERNAME { get; set; }

        public string PASSWORD { get; set; }

        public bool confirmed { get; set; }

        public string image_url { get; set; }

        public override string ToString()
        {
            return "ID RESTAURANT:" + ID_RESTAURANT +
                   " / ID CITY:" + IDCITY +
                   " / ID TYPE:" + IDTYPE +
                   " / NAME:" + NAME +
                   " / ADRESS:" + ADRESS +
                   " / PHONE NUMBER:" + PHONENUMBER+
                   " / USERNAME:" + USERNAME +
                   " / PASSWORD:" + PASSWORD 
                   ;

        }


    }
}
