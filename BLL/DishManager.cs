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

        public List<Dish> GetDishes()
        {
            return dishDB.GetDishes();
        }

        public List<Dish> GetDishes(int idRestaurant)
        {
            return dishDB.GetDishes(idRestaurant);
        }

        public Dish addDish(Dish dish)
        {

            return dishDB.addDish(dish);
        }

        public Dish GetDish(int idDish)
        {
            return dishDB.GetDish(idDish);

        }

        public Dish UpdateDish(int idDish, Dish newDish)
        {
            return dishDB.UpdateDish(idDish, newDish);
        }
        public Dish DeleteDish(int idDish)
        {
            return dishDB.DeleteDish(idDish);
        }




    }
}
