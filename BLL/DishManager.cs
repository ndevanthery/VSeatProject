using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class DishManager
    {

        private IDishDB dishDB { get; }

        public DishManager(IConfiguration conf)
        {
            dishDB = new DishDB(conf);

        }


        //add method
        public Dish AddDish(Dish dish)
        {

            return dishDB.AddDish(dish);
        }

        //get one method

        public Dish GetDish(int idDish)
        {
            return dishDB.GetDish(idDish);

        }

        //update method

        public Dish UpdateDish(int idDishOld, Dish newDish)
        {
            return dishDB.UpdateDish(idDishOld, newDish);
        }


        //delete method


        public Dish DeleteDish(int idDish)
        {
            return dishDB.DeleteDish(idDish);
        }

        //get list methods


        public List<Dish> GetDishes()
        {
            return dishDB.GetDishes();
        }

        public List<Dish> GetDishes(int idRestaurant)
        {
            return dishDB.GetDishes(idRestaurant);
        }

         public List<Dish> GetDishesUnderPrice(int maxPrice)
        {
            return dishDB.GetDishesUnderPrice(maxPrice);
        }









    }
}
