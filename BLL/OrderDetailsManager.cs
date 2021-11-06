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
    public class OrderDetailsManager
    {
        private IOrderDetailsDB orderDetailsDB { get; }

        public OrderDetailsManager(IConfiguration conf)
        {
            orderDetailsDB = new OrderDetailsDB(conf);

        }

        public List<OrderDetails> GetOrdersDetails()
        {
            return orderDetailsDB.GetOrdersDetails();
        }

        public List<OrderDetails> GetOrderDetailsWithIdDish(int id_dish)
        {
            return orderDetailsDB.GetOrderDetailsWithIdDish(id_dish);
        }

        public List<OrderDetails> GetOrderDetailsByDish(string dishName)
        {
            return orderDetailsDB.GetOrderDetailsByDish(dishName);
        }



        public OrderDetails GetOrderDetails(int orderId)
        {
            return orderDetailsDB.GetOrderDetail(orderId);
        }

        public OrderDetails addOrderDetails(OrderDetails orderDetails)
        {
            return orderDetailsDB.addOrderDetails(orderDetails);
        }




    }
}
