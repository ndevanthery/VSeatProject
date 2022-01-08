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
        public List<Order> GetOrdersByCustomer(int idCustomer);
        public List<Order> GetDuringOrdersForCustomer(int idCustomer);
        public List<Order> GetOrdersByStaff(int idStaff);
        public List<Order> GetDuringOrdersForStaff(int idStaff);

        public List<Order> GetOrdersByRestaurant(int idRestaurant);

        public List<Order> GetDuringOrdersForRestaurant(int idRestaurant);

        public int nbOrderAtTimeForStaff(int idStaff, DateTime time);

    }
}
