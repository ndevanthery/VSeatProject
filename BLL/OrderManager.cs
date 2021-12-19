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


        public OrderManager(IOrderDB OrderDB)
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

        public List<Order> GetDuringOrdersForCustomer(int idCustomer)
        {
            return orderDB.GetDuringOrdersForCustomer(idCustomer);
        }

        public List<Order> GetOrdersByStaff(int idStaff)
        {
            return orderDB.GetOrdersByStaff(idStaff);

        }
        public List<Order> GetDuringOrdersForStaff(int idStaff)
        {
            return orderDB.GetDuringOrdersForStaff(idStaff);
        }

        public List<Order> GetOrdersByRestaurant(int idRestaurant)
        {
            return orderDB.GetOrdersByRestaurant(idRestaurant);
        }

        public List<Order> GetDuringOrdersForRestaurant(int idRestaurant)
        {
            return orderDB.GetDuringOrdersForRestaurant(idRestaurant);
        }

        public int nbOrderAtTimeForStaff(int idStaff, DateTime time)
        {
            var myDuringOrders = orderDB.GetDuringOrdersForStaff(idStaff);
            var minus15 = time.AddMinutes(-15);
            var plus15 = time.AddMinutes(15);
            int number = 0;
            if(myDuringOrders!=null)
            {
                foreach (var order in myDuringOrders)
                {
                    if (order.ORDERDATE.CompareTo(minus15) >= 0)
                    {
                        if (order.ORDERDATE.CompareTo(plus15) <= 0)
                        {
                            number++;
                        }
                    }
                }
            }
            
            return number;
        }









    }
}
