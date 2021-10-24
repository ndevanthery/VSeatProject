using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class RestaurantDB : IRestaurantDB
    {

        private IConfiguration Configuration { get; }

        public RestaurantDB(IConfiguration conf)
        {
            Configuration = conf;
        }
        public void addRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetRestaurant(string name, string adress)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> GetRestaurants()
        {
            throw new NotImplementedException();
        }
    }
}
