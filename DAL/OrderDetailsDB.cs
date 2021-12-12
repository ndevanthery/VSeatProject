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

        //---------------------------------------------------
        // CONFIGURATION
        //---------------------------------------------------

        private IConfiguration Configuration { get; }

        public OrderDetailsDB(IConfiguration conf)
        {
            Configuration = conf;
        }

        //---------------------------------------------------
        // ADD METHOD
        //---------------------------------------------------

        public OrderDetails AddOrderDetails(OrderDetails orderDetails)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into ORDERDETAILS(ID_DISH, ID_ORDER,quantity) values(@ID_DISH , @ID_ORDER ,@quantity);";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_DISH", orderDetails.ID_DISH);
                    cmd.Parameters.AddWithValue("@ID_ORDER", orderDetails.ID_ORDER);
                    cmd.Parameters.AddWithValue("@quantity", orderDetails.quantity);

                    cn.Open();
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return orderDetails;
        }


        //---------------------------------------------------
        // GET ONE METHOD
        //---------------------------------------------------

        public OrderDetails GetOrderDetail(int orderId , int id_dish)
        {
            OrderDetails orderDetails = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from ORDERDETAILS WHERE ID_ORDER = @OrderId AND ID_DISH = @id_dish";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.Parameters.AddWithValue("@id_dish", id_dish);


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
                Console.WriteLine(e.Message);
            }

            return orderDetails;
        }



        //---------------------------------------------------
        // GET LIST METHODS
        //---------------------------------------------------


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
                Console.WriteLine(e.Message);
            }

            return results;
        }


        public List<OrderDetails> GetOrderDetailsByDish(int id_dish)

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
                            orderDetails.quantity = (int)dr["quantity"];

                            results.Add(orderDetails);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return results;
        }


        public List<OrderDetails> GetOrderDetailsByOrder(int orderId)
        {
            {
                List<OrderDetails> results = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "Select * from ORDERDETAILS WHERE ID_ORDER = @orderId";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@orderId", orderId);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (results == null)
                                    results = new List<OrderDetails>();

                                OrderDetails orderDetails = new OrderDetails();

                                orderDetails.ID_ORDER = (int)dr["ID_ORDER"];
                                orderDetails.ID_DISH = (int)dr["ID_DISH"];
                                orderDetails.quantity = (int)dr["quantity"];

                                results.Add(orderDetails);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return results;
            }


        }

    }

}
