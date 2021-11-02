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
    public class OrderDetailsDB : IOrderDetailsDB
    {

        private IConfiguration Configuration { get; }

        public OrderDetailsDB(IConfiguration conf)
        {
            Configuration = conf;
        }
        public OrderDetails addOrderDetails(OrderDetails orderDetails)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into ORDER_DETAILS(ID_DISH, ID_ORDER) values(@ID_DISH , @ID_ORDER); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_DISH", orderDetails.ID_DISH);
                    cmd.Parameters.AddWithValue("@ID_ORDER", orderDetails.ID_ORDER);

                    cn.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orderDetails;
        }

        public OrderDetails GetOrderDetailsWithOrderId(int orderId)
        {
            OrderDetails orderDetails = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from ORDERDETAILS WHERE ID_ORDER = @OrderId";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        orderDetails = new OrderDetails();

                        orderDetails.ID_ORDER = (int)dr["ID_ORDER"];
                        orderDetails.ID_DISH = (int)dr["ID_DISH"];



                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orderDetails;
        }

        public List<OrderDetails> GetOrdersDetails()
        {
            List<OrderDetails> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from ORDERDETAILS";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<OrderDetails>();

                            OrderDetails orderDetails = new OrderDetails();

                            orderDetails.ID_DISH = (int)dr["ID_DISH"];
                            orderDetails.ID_ORDER = (int)dr["ID_ORDER"];

                            results.Add(orderDetails);
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
    
        public List<OrderDetails> GetOrderDetailsWithIdDish(int id_dish)
        {
            List<OrderDetails> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from ORDERDETAILS WHERE ID_DISH = @id_dish";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_DISH", id_dish);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<OrderDetails>();

                            OrderDetails orderDetails = new OrderDetails();

                            orderDetails.ID_DISH = (int)dr["ID_DISH"];
                            orderDetails.ID_ORDER = (int)dr["ID_ORDER"];

                            results.Add(orderDetails);
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
