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

        //---------------------------------------------------
        // ADD METHOD
        //---------------------------------------------------
        public City AddCity(City city)
        {
            return cityDB.AddCity(city);
        }


        //---------------------------------------------------
        // GET one METHOD
        //---------------------------------------------------


        public City GetCity(int idCity)
        {
            return cityDB.GetCity(idCity);
        }



        //---------------------------------------------------
        // UPDATE METHOD
        //---------------------------------------------------
        public City UpdateCity(int idCityToChange, City newCity)
        {
            return cityDB.UpdateCity(idCityToChange, newCity);
        }


        //---------------------------------------------------
        // DELETE METHOD
        //---------------------------------------------------

        public City DeleteCity(int idCity)
        {
            return cityDB.DeleteCity(idCity);
        }

        //---------------------------------------------------
        // GET LISTS METHODS
        //---------------------------------------------------


        public List<City> GetCities()
        {
            return cityDB.GetCities();

        }











    }
}
