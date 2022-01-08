using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public interface ICityManager
    {
        public City GetCity(int idCity);
        public City UpdateCity(int idCityToChange, City newCity);
        public List<City> GetCities();
        public City GetCity(string cityname);

    }
}
