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

        public void AddCity(City city);
    }
}
