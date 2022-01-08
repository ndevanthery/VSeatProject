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
        //add OrderDetails

        public OrderDetails AddOrderDetails(OrderDetails orderDetails);

        // delete 
        public List<OrderDetails> DeleteOrderDetails(int id_order);
        //get Lists

        public List<OrderDetails> GetOrderDetailsByDish(int id_dish);

        public List<OrderDetails> GetOrderDetailsByOrder(int orderId);



      
      





    }
}
