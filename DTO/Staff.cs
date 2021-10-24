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

        public int ID_RESTAURANT { get; set; }

        public string NAME { get; set; }

        public string SURNAME { get; set; }

        public string ADRESS { get; set; }

        public string POSTALCODE { get; set; }

        public string PHONENUMBER { get; set; }

        public string PASSWORD { get; set; }

        public string USERNAME { get; set; }

        public override string ToString()
        {
            return "ID STAFF : " + ID_STAFF +
                   "ID RESTAURANT : " + ID_RESTAURANT +
                   "NAME : " + NAME +
                   "SURNAME : " + SURNAME +
                   "ADRESS : " + ADRESS +
                   "POSTAL CODE : " + POSTALCODE +
                   "PHONE NUMBER : " + PHONENUMBER +
                   "PASSWORD : " + PASSWORD +
                   "USERNAME : " + USERNAME;
        }

    }
}
