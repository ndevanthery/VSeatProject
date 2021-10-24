using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DishDB : IDishDB
    {
        private IConfiguration Configuration { get; }

        public DishDB(IConfiguration conf)
        {
            Configuration = conf;
        }

        public List<Dish> GetDishes()
        {
            throw new NotImplementedException();
        }

        public Dish GetDish(string name)
        {
            throw new NotImplementedException();
        }

        public void addDish(Dish dish)
        {
            throw new NotImplementedException();
        }
    }
}
