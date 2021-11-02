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
        public List<Dish> GetDishes();

        public List<Dish> GetDishes(int idRestaurant);

        public List<Dishes> GetDishesUnderPrice(int maxPrice);

        public Dish GetDish(string name);

        public Dish addDish(Dish dish);
    }
}
