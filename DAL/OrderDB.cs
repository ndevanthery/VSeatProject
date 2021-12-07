﻿using DTO;
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
                    string query = "Insert into [dbo].[ORDER](ID_CUSTOMER,ORDERDATE,DISCOUNT,TOTALPRICE) values(@ID_CUSTOMER ,@ORDERDATE,@DISCOUNT,@TOTALPRICE); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_CUSTOMER", order.ID_CUSTOMER);
                    cmd.Parameters.AddWithValue("@ORDERDATE", order.ORDERDATE);
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

                        order = new Order();
                        order.ID_ORDER = (int)dr["ID_ORDER"];
                        order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                        order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                        order.DISCOUNT = (int)dr["DISCOUNT"];
                        order.TOTALPRICE = (decimal)dr["TOTALPRICE"];

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
                    string query = "UPDATE [dbo].[ORDER] SET ID_CUSTOMER = @ID_CUSTOMER , ORDERDATE= @ORDERDATE , DISCOUNT = @DISCOUNT , TOTALPRICE =@TOTALPRICE WHERE ID_ORDER = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_CUSTOMER", newOrder.ID_CUSTOMER);
                    cmd.Parameters.AddWithValue("@ORDERDATE", newOrder.ORDERDATE);
                    cmd.Parameters.AddWithValue("@DISCOUNT", newOrder.DISCOUNT);
                    cmd.Parameters.AddWithValue("@TOTALPRICE", newOrder.TOTALPRICE);

                    cmd.Parameters.AddWithValue("@id", idOrder);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        order = new Order();
                        order.ID_ORDER = (int)dr["ID_ORDER"];
                        order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                        order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                        order.DISCOUNT = (int)dr["DISCOUNT"];
                        order.TOTALPRICE = (decimal)dr["TOTALPRICE"];



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

                        order = new Order();
                        order.ID_ORDER = (int)dr["ID_ORDER"];
                        order.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                        order.ORDERDATE = (DateTime)dr["ORDERDATE"];
                        order.DISCOUNT = (int)dr["DISCOUNT"];
                        order.TOTALPRICE = (decimal)dr["TOTALPRICE"];


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
    
        public List<Order> GetOrders(DateTime orderDate)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [dbo].[ORDER] WHERE ORDERDATE = @orderDate";
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
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];


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
                    string query = "Select * from [dbo].[ORDER] WHERE DISCOUNT = @discount";
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
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];


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
                    string query = "Select * from [dbo].[ORDER] WHERE TOTALPRICE > @total";
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
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];

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
                    string query = "Select * from [dbo].[ORDER] WHERE TOTALPRICE < @total";
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
                            order.DISCOUNT = (int)dr["DISCOUNT"];
                            order.TOTALPRICE = (decimal)dr["TOTALPRICE"];


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
                    string query = "Select * from [dbo].[ORDER] WHERE ID_CUSTOMER = @idCustomer";
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
