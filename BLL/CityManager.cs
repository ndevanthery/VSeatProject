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
    public class CityManager : ICityManager
    {
        private ICityDB CityDB { get; }

        public CityManager(ICityDB cityDB)
        {
            CityDB = cityDB;

        }

        //---------------------------------------------------
        // GET ONE METHODS
        //---------------------------------------------------


        public City GetCity(int idCity)
        {
            return CityDB.GetCity(idCity);
        }

        public City GetCity(string cityname)
        {
            return CityDB.GetCity(cityname);
        }



        //---------------------------------------------------
        // UPDATE METHOD
        //---------------------------------------------------
        public City UpdateCity(int idCityToChange, City newCity)
        {
            return CityDB.UpdateCity(idCityToChange, newCity);
        }


        //---------------------------------------------------
        // GET LISTS METHODS
        //---------------------------------------------------


        public List<City> GetCities()
        {
            return CityDB.GetCities();

        }


    }
}
