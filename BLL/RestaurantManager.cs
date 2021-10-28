using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class RestaurantManager
    {
        private IRestaurantDB restaurantDB { get; }

        public RestaurantManager(IConfiguration conf)
        {
            restaurantDB = new RestaurantDB(conf);

        }


        public List<Restaurant> GetRestaurants()
        {
            return restaurantDB.GetRestaurants();
        }

        public Restaurant GetRestaurant(string name, string adress)
        {
            return restaurantDB.GetRestaurant(name, adress);
        }

        public Restaurant addRestaurant(Restaurant restaurant)
        {
            return restaurantDB.addRestaurant(restaurant);
        }

    }
}
