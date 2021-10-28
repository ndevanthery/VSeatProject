using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class OrderDB : IOrderDB
    {

        private IConfiguration Configuration { get; }

        public OrderDB(IConfiguration conf)
        {
            Configuration = conf;
        }
        public void addOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int orderID)
        {
            Order order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from ORDER WHERE WHERE ID_ORDER= @ID_ORDER";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_ORDER", orderID);
                    


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        order = new Order();
                        order.ID_ORDER = (int)dr["ID_ORDER"];
                        order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                        order.DELIVERYTIME = (DateTime)dr["DELIVERYTIME"];
                        order.DISCOUNT = (int)dr["DISCOUNT"];
                        order.TOTALPRICE = (double)dr["TOTALPRICE"];
                        



                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return order;
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
