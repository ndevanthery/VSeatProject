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
        //---------------------------------------------------
        // CONFIGURATION
        //---------------------------------------------------

        private IConfiguration Configuration { get; }

        public OrderDB(IConfiguration conf)
        {
            Configuration = conf;
        }

        //---------------------------------------------------
        // ADD METHOD
        //---------------------------------------------------


        public Order AddOrder(Order order)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into [dbo].[ORDER](ID_CUSTOMER,ORDERDATE,DISCOUNT,TOTALPRICE,ID_STAFF,ID_RESTAURANT,isDelivered) values(@ID_CUSTOMER ,@ORDERDATE,@DISCOUNT,@TOTALPRICE,@ID_STAFF,@ID_RESTAURANT,@isDelivered); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_CUSTOMER",order.ID_CUSTOMER);
                    cmd.Parameters.AddWithValue("@ORDERDATE", order.ORDERDATE);
                    cmd.Parameters.AddWithValue("@DISCOUNT", order.DISCOUNT);
                    cmd.Parameters.AddWithValue("@TOTALPRICE", order.TOTALPRICE);
                    cmd.Parameters.AddWithValue("@ID_RESTAURANT", order.ID_RESTAURANT);
                    cmd.Parameters.AddWithValue("@ID_STAFF", order.ID_STAFF);
                    cmd.Parameters.AddWithValue("@isDelivered", order.isDelivered);



                    cn.Open();

                    order.ID_ORDER = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return order;

        }


        //---------------------------------------------------
        // GET ONE METHOD
        //---------------------------------------------------
        public Order GetOrder(int orderID)
        {
            Order order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [dbo].[ORDER] WHERE ID_ORDER= @ID_ORDER";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_ORDER", orderID);



                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            order = new Order();
                            order.ID_ORDER = (int)dr["ID_ORDER"];
                            order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];
                            order.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            order.ID_STAFF = (int)dr["ID_STAFF"];
                            order.isDelivered = (bool)dr["isDelivered"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return order;
        }

        //---------------------------------------------------
        // UPDATE METHOD
        //---------------------------------------------------

        public Order UpdateOrder(int idOrder, Order newOrder)
        {
            Order order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [dbo].[ORDER] SET ID_CUSTOMER = @ID_CUSTOMER , ORDERDATE= @ORDERDATE , DISCOUNT = @DISCOUNT , TOTALPRICE =@TOTALPRICE , ID_STAFF = @ID_STAFF , ID_RESTAURANT = @ID_RESTAURANT , isDelivered =@isDelivered WHERE ID_ORDER = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_CUSTOMER", newOrder.ID_CUSTOMER);
                    cmd.Parameters.AddWithValue("@ORDERDATE", newOrder.ORDERDATE);
                    cmd.Parameters.AddWithValue("@DISCOUNT", newOrder.DISCOUNT);
                    cmd.Parameters.AddWithValue("@TOTALPRICE", newOrder.TOTALPRICE);
                    cmd.Parameters.AddWithValue("@ID_STAFF", newOrder.ID_STAFF);
                    cmd.Parameters.AddWithValue("@ID_RESTAURANT", newOrder.ID_RESTAURANT);
                    cmd.Parameters.AddWithValue("@isDelivered", newOrder.isDelivered);


                    cmd.Parameters.AddWithValue("@id", idOrder);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            order = new Order();
                            order.ID_ORDER = (int)dr["ID_ORDER"];
                            order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];
                            order.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            order.ID_STAFF = (int)dr["ID_STAFF"];
                            order.isDelivered = (bool)dr["isDelivered"];

                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return order;
        }


        //---------------------------------------------------
        // DELETE METHOD
        //---------------------------------------------------
        public Order DeleteOrder(int id_order)
        {
            Order order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM [dbo].[ORDER] WHERE ID_ORDER = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id_order);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            order = new Order();
                            order.ID_ORDER = (int)dr["ID_ORDER"];
                            order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];
                            order.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            order.ID_STAFF = (int)dr["ID_STAFF"];
                            order.isDelivered = (bool)dr["isDelivered"];

                        }


                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return order;
        }

        //---------------------------------------------------
        // GET lists METHODS
        //---------------------------------------------------


        public List<Order> GetOrders()
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [dbo].[ORDER]";
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
                            order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];
                            order.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            order.ID_STAFF = (int)dr["ID_STAFF"];
                            order.isDelivered = (bool)dr["isDelivered"];


                            Console.WriteLine(order);
                            results.Add(order);
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
        public List<Order> GetOrdersByCustomer(int idCustomer)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [dbo].[ORDER] WHERE ID_CUSTOMER = @idCustomer ORDER BY ORDERDATE DESC";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCustomer", idCustomer);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.ID_ORDER = (int)dr["ID_ORDER"];
                            order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];
                            order.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            order.ID_STAFF = (int)dr["ID_STAFF"];
                            order.isDelivered = (bool)dr["isDelivered"];



                            results.Add(order);
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

        public List<Order> GetDuringOrdersForCustomer(int idCustomer)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    //string query = "Select * from [dbo].[ORDER] WHERE ID_CUSTOMER = @idCustomer AND ORDERDATE>GETDATE() ORDER BY ORDERDATE DESC";
                    string query = "Select * from [dbo].[ORDER] WHERE ID_CUSTOMER = @idCustomer AND isDelivered=0 ORDER BY ORDERDATE DESC";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCustomer", idCustomer);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.ID_ORDER = (int)dr["ID_ORDER"];
                            order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];
                            order.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            order.ID_STAFF = (int)dr["ID_STAFF"];
                            order.isDelivered = (bool)dr["isDelivered"];



                            results.Add(order);
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

        public List<Order> GetOrdersByStaff(int idStaff)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [dbo].[ORDER] WHERE ID_STAFF = @ID_STAFF ORDER BY ORDERDATE DESC";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_STAFF", idStaff);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.ID_ORDER = (int)dr["ID_ORDER"];
                            order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];
                            order.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            order.ID_STAFF = (int)dr["ID_STAFF"];
                            order.isDelivered = (bool)dr["isDelivered"];



                            results.Add(order);
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

        public List<Order> GetDuringOrdersForStaff(int idStaff)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    //string query = "Select * from [dbo].[ORDER] WHERE ID_STAFF = @ID_STAFF AND DATEADD(MINUTE,30,ORDERDATE)>GETDATE() ORDER BY ORDERDATE DESC";
                    string query = "Select * from [dbo].[ORDER] WHERE ID_STAFF = @ID_STAFF AND isDelivered=0 ORDER BY ORDERDATE DESC";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_STAFF", idStaff);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.ID_ORDER = (int)dr["ID_ORDER"];
                            order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];
                            order.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            order.ID_STAFF = (int)dr["ID_STAFF"];
                            order.isDelivered = (bool)dr["isDelivered"];



                            results.Add(order);
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

        public List<Order> GetOrdersByRestaurant(int idRestaurant)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [dbo].[ORDER] WHERE ID_RESTAURANT = @ID_RESTAURANT ORDER BY ORDERDATE DESC";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_RESTAURANT", idRestaurant);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.ID_ORDER = (int)dr["ID_ORDER"];
                            order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];
                            order.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            order.ID_STAFF = (int)dr["ID_STAFF"];
                            order.isDelivered = (bool)dr["isDelivered"];



                            results.Add(order);
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

        public List<Order> GetDuringOrdersForRestaurant(int idRestaurant)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [dbo].[ORDER] WHERE ID_RESTAURANT = @ID_RESTAURANT AND DATEADD(MINUTE,30,ORDERDATE)>GETDATE() ORDER BY ORDERDATE DESC";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_RESTAURANT", idRestaurant);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.ID_ORDER = (int)dr["ID_ORDER"];
                            order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];
                            order.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            order.ID_STAFF = (int)dr["ID_STAFF"];
                            order.isDelivered = (bool)dr["isDelivered"];



                            results.Add(order);
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
