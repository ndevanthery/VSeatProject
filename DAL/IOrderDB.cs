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
        //add Order

        public Order AddOrder(Order order);


        //get Order

        public Order GetOrder(int orderID);


        //update Order

        public Order UpdateOrder(int idOrder, Order newOrder);

        //delete Order

        public Order DeleteOrder(int idOrder);

        //get Lists

        public List<Order> GetOrders();

        public List<Order> GetOrders(DateTime orderDate);

        public List<Order> GetOrdersByDiscount(int discount);

        public List<Order> GetOrdersByMinTotalPrice(double totalPrice);

        public List<Order> GetOrdersByMaxTotalPrice(double totalPrice);

        public List<Order> GetOrdersByCustomer(int idCustomer);


    }
}
