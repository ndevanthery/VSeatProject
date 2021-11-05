using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class DishManager
    {

        private IDishDB dishDB { get; }
        public List<Dish> GetDishes()
        {
            return dishDB.GetDishes();
        }

        public Dish addDish(Dish dish)
        {
            return dishDB.addDish(dish);
        }

    }
}
