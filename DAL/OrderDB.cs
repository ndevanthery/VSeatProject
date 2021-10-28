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
   public  class OrderDB : IOrderDB
    {

        private IConfiguration Configuration { get; }

        public OrderDB(IConfiguration conf)
        {
            Configuration = conf;
        }
        public Order addOrder(Order order)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into ORDER(ID_ORDER,ORDERDATE,DELIVERYTIME,DISCOUNT,TOTALPRICE) values(@ORDERDATE,@DELIVERYTIME,@DISCOUNT,@TOTALPRICE); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_ORDER", order.ID_ORDER);
                    cmd.Parameters.AddWithValue("@ORDERDATE", order.ORDERDATE);
                    cmd.Parameters.AddWithValue("@DELIVERYTIME", order.DELIVERYTIME);
                    cmd.Parameters.AddWithValue("@DISCOUNT", order.DISCOUNT);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", order.TOTALPRICE);

                    cn.Open();

                    order.ID_ORDER = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;

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
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from ORDER";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.ID_ORDER = (int)dr["ID_ORDER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.DELIVERYTIME = (DateTime)dr["DELIVERYTIME"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (double)dr["TOTALPRICE"];
                            

                            results.Add(order);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;

        }
    }
    }
}
