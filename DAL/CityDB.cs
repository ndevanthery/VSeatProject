using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CityDB : ICityDB
    {

        private IConfiguration Configuration { get; }

        public CityDB(IConfiguration conf)
        {
            Configuration =conf;
        }

        public void AddCity(City city)
        {

            //to implement
            throw new NotImplementedException();
        }

        public List<City> GetCities()
        {
            //to implement
            throw new NotImplementedException();
        }
    }
}
