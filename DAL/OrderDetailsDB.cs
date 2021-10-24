using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class OrderDetailsDB : IOrderDetailsDB
    {

        private IConfiguration Configuration { get; }

        public OrderDetailsDB(IConfiguration conf)
        {
            Configuration = conf;
        }
        public void addOrderDetails(OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }

        public OrderDetails GetOrderDetails(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> GetOrdersDetails()
        {
            throw new NotImplementedException();
        }
    }
}
