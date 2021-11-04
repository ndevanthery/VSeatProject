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
    class OrderDetailsManager
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
