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

        public List<Restaurant> GetRestaurantsByCity(int id_city)
        {
            return restaurantDB.GetRestaurantsByCity(id_city);
        }

        public List<Restaurant> GetRestaurantsByType(int id_type)
        {
           return restaurantDB.GetRestaurantsByType(id_type);

        }


        public Restaurant GetRestaurant(int idRestaurant)
        {
            return restaurantDB.GetRestaurant(idRestaurant);
        }

        public Restaurant addRestaurant(Restaurant restaurant)
        {
            return restaurantDB.addRestaurant(restaurant);
        }

    }
}
