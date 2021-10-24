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

        public int ID_CITY { get; set; }

        public string NAME { get; set; }

        public string SURNAME { get; set; }

        public string ADRESS { get; set; }

        public string POSTALCODE { get; set; }

        public string PHONENUMBER { get; set; }

        public string PASSWORD { get; set; }

        public override string ToString()
        {
            return "ID_CUSTOMER : " + ID_CUSTOMER +
                    "ID_CITY : " + ID_CITY +
                    "name : " + NAME +
                    "surname : " + SURNAME +
                    "adress : " + ADRESS +
                    "postal code : " + POSTALCODE +
                    "phone number : " + PHONENUMBER +
                    "password : " + PASSWORD;
        }

    }
}
