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
        //add City
        public City AddCity(City city);





        //get City


        public City GetCity(int idCity);


        //update City

        public City UpdateCity(int idCityToChange, City newCity);


        //delete city

        public City DeleteCity(int idCity);

        //get Lists
        public List<City> GetCities();


    }
}
