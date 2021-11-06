using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class CityManager
    {
        private ICityDB cityDB { get; }

        public CityManager(IConfiguration conf)
        {
            cityDB = new CityDB(conf);

        }


        public List<City> GetCities()
        {
            return cityDB.GetCities();

        }

        public City AddCity(City city)
        {
            return cityDB.AddCity(city);
        }


        public City GetCity(int idCity)
        {
            return cityDB.GetCity(idCity);
        }

        public Cit

    }
}
