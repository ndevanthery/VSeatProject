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

        public List<Order> GetOrders(DateTime orderDate)
        {
            return orderDB.GetOrders(orderDate);
        }

        public List<Order> GetOrdersByDiscount(int discount)
        {
            return orderDB.GetOrdersByDiscount(discount);
        }

        public List<Order> GetOrdersByMinTotalPrice(double totalPrice)
        {
            return orderDB.GetOrdersByMinTotalPrice(totalPrice);
        }

        public List<Order> GetOrdersByMaxTotalPrice(double totalPrice)
        {
            return orderDB.GetOrdersByMaxTotalPrice(totalPrice);
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
