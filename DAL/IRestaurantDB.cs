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


        public Restaurant AddRestaurant(Restaurant restaurant);




        //get Restaurant

        public Restaurant GetRestaurant(int idRestaurant);



        //update Restaurant

        public Restaurant UpdateRestaurant(int idRestaurant, Restaurant newRestaurant);


        //delete Restaurant

        public Restaurant DeleteRestaurant(int idRestaurant);


        //get lists

        public List<Restaurant> GetRestaurants();

        public List<Restaurant> GetRestaurantsByCity(int id_city);

        public List<Restaurant> GetRestaurantsByType(int id_type);



    }
}
