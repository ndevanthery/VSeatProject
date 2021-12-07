using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public interface IOrderDetailsManager
    {
        public OrderDetails AddOrderDetails(OrderDetails orderDetails);
        public OrderDetails GetOrderDetails(int orderId, int id_dish);
        public List<OrderDetails> GetOrdersDetails();
        public List<OrderDetails> GetOrderDetailsByDish(int id_dish);
        public List<OrderDetails> GetOrderDetailsByOrder(int orderId);
    }
}
