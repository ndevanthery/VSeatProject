using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderDetailsManager : IOrderDetailsManager
    {


        private IOrderDetailsDB orderDetailsDB { get; }

        public OrderDetailsManager(IConfiguration conf)
        {
            orderDetailsDB = new OrderDetailsDB(conf);

        }

        //---------------------------------------------------
        // ADD METHOD
        //---------------------------------------------------

        public OrderDetails AddOrderDetails(OrderDetails orderDetails)
        {
            return orderDetailsDB.AddOrderDetails(orderDetails);
        }

        //---------------------------------------------------
        // get one METHOD
        //---------------------------------------------------

        public OrderDetails GetOrderDetails(int orderId, int id_dish)
        {
            return orderDetailsDB.GetOrderDetail(orderId, id_dish);
        }


        //---------------------------------------------------
        // get list METHODS
        //---------------------------------------------------



        public List<OrderDetails> GetOrdersDetails()
        {
            return orderDetailsDB.GetOrdersDetails();
        }

        public List<OrderDetails> GetOrderDetailsByDish(int id_dish)
        {
            return orderDetailsDB.GetOrderDetailsByDish(id_dish);
        }

        public List<OrderDetails> GetOrderDetailsByOrder(int orderId)
        {
            return orderDetailsDB.GetOrderDetailsByOrder(orderId);
        }













    }
}
