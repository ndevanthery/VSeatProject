using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO; 

namespace BLL
{
    public interface IOrderManager
    {
        public Order AddOrder(Order order);
        public Order GetOrder(int orderID);
        public Order UpdaterOrder(int idOrder, Order newOrder);
        public Order DeleteOrder(int idOrder);
        public List<Order> GetOrders();
        public List<Order> GetOrders(DateTime orderDate);
        public List<Order> GetOrdersByDiscount(int discount);
        public List<Order> GetOrdersByMinTotalPrice(double totalPrice);
        public List<Order> GetOrdersByMaxTotalPrice(double totalPrice);
        public List<Order> GetOrdersByCustomer(int idCustomer);

    }
}
