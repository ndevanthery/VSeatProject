using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class City
    {
        public int ID_CITY  { get; set; }

        public string CITYNAME { get; set; }

        public override string ToString()
        {
            return "ID_CITY : " + ID_CITY +
                    "CityName : " + CITYNAME;
        }

    }
}
