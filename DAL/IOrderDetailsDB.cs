using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IOrderDetailsDB
    {
        public List<OrderDetails> GetOrdersDetails();

        public OrderDetails GetOrderDetails(int orderId);

        public OrderDetails addOrderDetails(OrderDetails orderDetails);


    }
}
