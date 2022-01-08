using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Customer
    {
        public int ID_CUSTOMER { get; set; }

        public int IDCITY { get; set; }

        public string FIRSTNAME { get; set; }

        public string LASTNAME { get; set; }

        public string ADRESS { get; set; }

        public string PHONENUMBER { get; set; }

        public string USERNAME { get; set; }

        public string PASSWORD { get; set; }

        public string EMAIL { get; set; }

        public string image_url { get; set; }

        public bool confirmed { get; set; }


    }
}
