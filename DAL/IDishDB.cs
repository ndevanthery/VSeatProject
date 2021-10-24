using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDishDB
    {
        public List<Dish> GetDishes();

        public Dish GetDish(string name);

        public void addDish(Dish dish);
    }
}
