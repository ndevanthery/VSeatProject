using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Staff
    {
        public int ID_STAFF { get; set; }

        public int IDCITY { get; set; }

        public string FIRSTNAME { get; set; }

        public string LASTNAME { get; set; }

        public string ADRESS { get; set; }

        public string PHONENUMBER { get; set; }

        public string USERNAME { get; set; }

        public string PASSWORD { get; set; }

        public bool confirmed { get; set; }

        public string image_url { get; set; }

        public string email { get; set; }


    }
}
