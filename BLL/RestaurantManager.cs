﻿using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RestaurantManager : IRestaurantManager
    {
        private IRestaurantDB restaurantDB { get; }

        public RestaurantManager(IRestaurantDB restaurantDB)
        {
            this.restaurantDB = restaurantDB;

        }

        //login method
        public Restaurant loginRestaurant(string username, string password)
        {

            Restaurant loggedRestaurant = new Restaurant();

            //get list of restaurants
            var restaurants = GetRestaurants();

            foreach (var restaurant in restaurants)
            {
                if (restaurant.USERNAME == username && restaurant.PASSWORD == password)
                {
                    //if one restaurant username and password combinaison matches
                    //return the restaurant
                    loggedRestaurant = restaurant;

                    return loggedRestaurant;
                }

            }

            //if not, return null

            return null;

        }

        //---------------------------------------------------
        // ADD METHOD
        //---------------------------------------------------
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return restaurantDB.AddRestaurant(restaurant);
        }
        //---------------------------------------------------
        // GET ONE METHOD
        //---------------------------------------------------
        public Restaurant GetRestaurant(int idRestaurant)
        {
            return restaurantDB.GetRestaurant(idRestaurant);
        }
        //---------------------------------------------------
        // UPDATE METHOD
        //---------------------------------------------------
        public Restaurant UpdateRestaurant(int idRestaurant, Restaurant newRestaurant)
        {
            return restaurantDB.UpdateRestaurant(idRestaurant, newRestaurant);
        }
        //---------------------------------------------------
        // DELETE METHOD
        //---------------------------------------------------
        public Restaurant DeleteRestaurant(int idRestaurant)
        {
            return restaurantDB.DeleteRestaurant(idRestaurant);

        }
        //---------------------------------------------------
        // GET LIST METHODS
        //---------------------------------------------------

        public List<Restaurant> GetRestaurants()
        {
            return restaurantDB.GetRestaurants();
        }

        public List<Restaurant> GetRestaurantsByCity(int id_city)
        {
            return restaurantDB.GetRestaurantsByCity(id_city);
        }












    }
}
