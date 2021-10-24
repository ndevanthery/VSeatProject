using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class OrderDB : IOrderDB
    {

        private IConfiguration Configuration { get; }

        public OrderDB(IConfiguration conf)
        {
            Configuration = conf;
        }
        public void addOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
