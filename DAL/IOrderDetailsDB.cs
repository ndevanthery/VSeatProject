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

        // get OrderDetails

        public OrderDetails GetOrderDetail(int orderId, int id_dish);


        //get Lists


        public List<OrderDetails> GetOrdersDetails();

        public List<OrderDetails> GetOrderDetailsByDish(int id_dish);

        public List<OrderDetails> GetOrderDetailsByOrder(int orderId);



      
      





    }
}
