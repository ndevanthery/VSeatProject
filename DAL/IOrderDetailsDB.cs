using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrderDetailsDB
    {
        public List<OrderDetails> GetOrdersDetails();

        public List<OrderDetails> GetOrderDetailsWithIdDish(int id_dish);

        public OrderDetails GetOrderDetailsWithOrderId(int orderId);

        public OrderDetails addOrderDetails(OrderDetails orderDetails);




    }
}
