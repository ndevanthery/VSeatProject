using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDishDB
    {
        //add Dish

        public Dish AddDish(Dish dish);



        //get Dish

        public Dish GetDish(int idDish);


        //update Dish

        public Dish UpdateDish(int idDish, Dish newDish);


        //delete Dish

        public Dish DeleteDish(int idDish);


        //get Lists
        public List<Dish> GetDishes();

        public List<Dish> GetDishes(int idRestaurant);

        public List<Dish> GetDishesUnderPrice(int maxPrice);


    }
}
