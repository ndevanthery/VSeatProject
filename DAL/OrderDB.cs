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


        public Order addOrder(Order order)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into ORDER(ID_CUSTOMER,ORDERDATE,ORDERTIME,DISCOUNT,TOTALPRICE) values(@ID_CUSTOMER ,@ORDERDATE,@ORDERTIME,@DISCOUNT,@TOTALPRICE); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_CUSTOMER", order.ID_CUSTOMER);
                    cmd.Parameters.AddWithValue("@ORDERDATE", order.ORDERDATE);
                    cmd.Parameters.AddWithValue("@ORDERTIME", order.ORDERTIME);
                    cmd.Parameters.AddWithValue("@DISCOUNT", order.DISCOUNT);
                    cmd.Parameters.AddWithValue("@TOTALPRICE", order.TOTALPRICE);

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
        // GET lists METHODS
        //---------------------------------------------------





        //---------------------------------------------------
        // GET ONE METHODS
        //---------------------------------------------------

        public Order GetOrder(int orderID)
        {
            Order order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from ORDER WHERE ID_ORDER= @ID_ORDER";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_ORDER", orderID);



                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        order = new Order();
                        order.ID_ORDER = (int)dr["ID_ORDER"];
                        order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                        order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                        order.ORDERTIME = (DateTime)dr["ORDERTIME"];
                        order.DISCOUNT = (int)dr["DISCOUNT"];
                        order.TOTALPRICE = (double)dr["TOTALPRICE"];

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




        //---------------------------------------------------
        // DELETE METHOD
        //---------------------------------------------------




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
                            order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                            order.ORDERTIME = (DateTime)dr["ORDERTIME"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (double)dr["TOTALPRICE"];


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
    
        public List<Order> GetOrders(DateTime orderDate)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from ORDER WHERE ORDERDATE = @orderDate";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@orderDate", orderDate);
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
                            order.ORDERTIME = (DateTime)dr["ORDERTIME"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (double)dr["TOTALPRICE"];


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

        public List<Order> GetOrdersByDiscount(int discount)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from ORDER WHERE DISCOUNT = @discount";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@disount", discount);
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
                            order.ORDERTIME = (DateTime)dr["ORDERTIME"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (double)dr["TOTALPRICE"];


                            results.Add(order);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return results;                }

        public List<Order> GetOrdersByMinTotalPrice(double totalPrice)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from ORDER WHERE TOTALPRICE > @total";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@total", totalPrice);
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
                            order.ORDERTIME = (DateTime)dr["ORDERTIME"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (double)dr["TOTALPRICE"];

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

        public List<Order> GetOrdersByMaxTotalPrice(double totalPrice)
        {
        List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from ORDER WHERE TOTALPRICE < @total";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@total", totalPrice);
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
                            order.ORDERTIME = (DateTime)dr["ORDERTIME"];
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (double)dr["TOTALPRICE"];


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
