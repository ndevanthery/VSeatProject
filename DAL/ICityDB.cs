using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    interface ICityDB
    {

        public List<City> GetCities();

        public City AddCity(City city);

        public City GetCity(string cityName);
    }
}
