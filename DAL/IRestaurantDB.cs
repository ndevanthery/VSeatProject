using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRestaurantDB
    {
        //add Restaurant


        public Restaurant addRestaurant(Restaurant restaurant);


        //get lists

        public List<Restaurant> GetRestaurants();

        public List<Restaurant> GetRestaurantsByCity(int id_city);

        public List<Restaurant> GetRestaurantsByType(int id_type);


        //get Restaurant

        public Restaurant GetRestaurant(string name , string adress);

        public Restaurant GetRestaurant(int idRestaurant);



    }
}
