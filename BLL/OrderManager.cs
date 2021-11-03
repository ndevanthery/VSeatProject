using DTO;
using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class OrderManager
    {
        private IOrderDB orderDB { get; }
    

        public OrderManager(IConfiguration conf)
        {
            orderDB = new OrderDB(conf);
        }


        public List<Order> GetOrders()
        {
            return orderDB.GetOrders();
        }
        public Order GetOrder(int orderID)
        {
            return orderDB.GetOrder(orderID);
        }

        public Order addOrder(Order order)
        {
            return orderDB.addOrder(order);
        }
    }
}
