﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public interface IRestaurantManager
    {

        public Restaurant loginRestaurant(string username, string password);

        public Restaurant AddRestaurant(Restaurant restaurant);

        public Restaurant GetRestaurant(int idRestaurant);

        public Restaurant UpdateRestaurant(int idRestaurant, Restaurant newRestaurant);

        public List<Restaurant> GetRestaurants();

        public List<Restaurant> GetRestaurantsByCity(int id_city);

    }
}
