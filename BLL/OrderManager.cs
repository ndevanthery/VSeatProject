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
    public class OrderManager : IOrderManager
    {
        private IOrderDB orderDB { get; }


        public OrderManager(OrderDB OrderDB)
        {
            orderDB = OrderDB;
        }

        //---------------------------------------------------
        // ADD METHOD
        //---------------------------------------------------
        public Order AddOrder(Order order)
        {
            return orderDB.AddOrder(order);
        }


        //---------------------------------------------------
        // GET ONE METHOD
        //---------------------------------------------------
        public Order GetOrder(int orderID)
        {
            return orderDB.GetOrder(orderID);
        }


        //---------------------------------------------------
        // UPDATE METHOD
        //---------------------------------------------------
        public Order UpdaterOrder(int idOrder, Order newOrder)
        {
            return orderDB.UpdateOrder(idOrder, newOrder);
        }
        //---------------------------------------------------
        // DELETE METHOD
        //---------------------------------------------------
        public Order DeleteOrder(int idOrder)
        {
            return orderDB.DeleteOrder(idOrder);
        }
        //---------------------------------------------------
        // GET lists METHODS
        //---------------------------------------------------



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


        public List<Order> GetOrdersByCustomer(int idCustomer)
        {
            return orderDB.GetOrdersByCustomer(idCustomer);
        }










    }
}
