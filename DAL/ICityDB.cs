using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public interface ICityDB
    {



        //get City


        public City GetCity(int idCity);

        public City GetCity(string cityname);

        //update City

        public City UpdateCity(int idCityToChange, City newCity);

        //get Lists
        public List<City> GetCities();


    }
}
