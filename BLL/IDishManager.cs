using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IDishManager
    {
        public Dish AddDish(Dish dish);

        public Dish GetDish(int idDish);

        public Dish UpdateDish(int idDishOld, Dish newDish);

        public Dish DeleteDish(int idDish);

        public List<Dish> GetDishes(int idRestaurant);

    }
}
