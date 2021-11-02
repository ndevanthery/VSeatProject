using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrderDB
    {
        public List<Order> GetOrders();

        public List<Order> GetOrders(DateTime orderDate);

        public List<Order> GetOrdersByDiscount(int discount);

        public List<Order> GetOrdersByMinTotalPrice(double totalPrice);
        
        public List<Order> GetOrdersByMaxTotalPrice(double totalPrice);

        public Order GetOrder(int orderID);

        


        public Order addOrder(Order order);

    }
}
