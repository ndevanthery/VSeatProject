﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DishDB : IDishDB
    {

        //configuration
        private IConfiguration Configuration { get; }

        public DishDB(IConfiguration conf)
        {
            Configuration = conf;
        }

        //---------------------------------------------------
        // ADD METHODS
        //---------------------------------------------------

        public Dish AddDish(Dish dish)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into DISH(ID_RESTAURANT,NAME,PRICE,image_url) values(@ID_RESTAURANT,@NAME,@PRICE,@image_url); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_RESTAURANT", dish.ID_RESTAURANT);
                    cmd.Parameters.AddWithValue("@NAME", dish.NAME);
                    cmd.Parameters.AddWithValue("@PRICE", dish.PRICE);

                    if(dish.image_url==null)
                    {
                        cmd.Parameters.AddWithValue("@image_url", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_url", dish.image_url);

                    }


                    cn.Open();

                    dish.ID_DISH = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return dish;
        }


        




        //---------------------------------------------------
        // GET one METHOD
        //---------------------------------------------------


        public Dish GetDish(int idDish)
        {
            Dish dish = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DISH WHERE ID_DISH = @Id_dish";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id_dish", idDish);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dish = new Dish();

                            dish.ID_DISH = (int)dr["ID_DISH"];

                            dish.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];

                            dish.NAME = (string)dr["NAME"];

                            dish.PRICE = (decimal)dr["PRICE"];

                            if(dr["image_url"]!=DBNull.Value)
                            {
                                dish.image_url = (string)dr["image_url"];
                            }


                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return dish;
        }


        //---------------------------------------------------
        // UPDATE METHOD
        //---------------------------------------------------

        public Dish UpdateDish(int idDish, Dish newDish)
        {
            Dish dish = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE DISH SET ID_RESTAURANT = @ID_RESTAURANT, NAME = @NAME, PRICE = @PRICE, image_url = @image_url WHERE ID_DISH = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@ID_RESTAURANT", newDish.ID_RESTAURANT);
                    if (newDish.image_url == null)
                    {
                        cmd.Parameters.AddWithValue("@image_url", DBNull.Value);

                    }
                    cmd.Parameters.AddWithValue("@NAME", newDish.NAME);
                    cmd.Parameters.AddWithValue("@PRICE", newDish.PRICE);

                    // old parameter used to figure out which dish to update

                    cmd.Parameters.AddWithValue("@id", idDish);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            dish = new Dish();

                            dish.ID_DISH = (int)dr["ID_DISH"];

                            dish.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];

                            dish.NAME = (string)dr["NAME"];

                            dish.PRICE = (decimal)dr["PRICE"];

                            if (dr["image_url"] != DBNull.Value)
                            {
                                dish.image_url = (string)dr["image_url"];
                            }


                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return dish;
        }




        //---------------------------------------------------
        // DELETE METHOD
        //---------------------------------------------------

        public Dish DeleteDish(int idDish)
       {
            Dish dish = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM DISH WHERE ID_DISH = @Id_dish";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id_dish", idDish);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dish = new Dish();

                            dish.ID_DISH = (int)dr["ID_DISH"];

                            dish.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];

                            dish.NAME = (string)dr["NAME"];

                            dish.PRICE = (decimal)dr["PRICE"];

                            if (dr["image_url"] != DBNull.Value)
                            {
                                dish.image_url = (string)dr["image_url"];
                            }


                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return dish;
        }

        //---------------------------------------------------
        // GET by Lists METHODS
        //---------------------------------------------------


        public List<Dish> GetDishes()
        {
            List<Dish> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DISH";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dish>();

                            Dish dish = new Dish();


                            dish.ID_DISH = (int)dr["ID_DISH"];

                            dish.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];

                            dish.NAME = (string)dr["NAME"];

                            dish.PRICE = (decimal)dr["PRICE"];

                            if (dr["image_url"] != DBNull.Value)
                            {
                                dish.image_url = (string)dr["image_url"];
                            }

                            results.Add(dish);
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

        public List<Dish> GetDishes(int idRestaurant)
        {
            List<Dish> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DISH WHERE ID_RESTAURANT = @Id_restaurant";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id_restaurant", idRestaurant);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dish>();

                            Dish dish = new Dish();


                            dish.ID_DISH = (int)dr["ID_DISH"];

                            dish.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];

                            dish.NAME = (string)dr["NAME"];

                            dish.PRICE = (decimal)dr["PRICE"];

                            if (dr["image_url"] != DBNull.Value)
                            {
                                dish.image_url = (string)dr["image_url"];
                            }

                            results.Add(dish);
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

        public List<Dish> GetDishesUnderPrice(int maxPrice)
        {
            List<Dish> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DISH WHERE PRICE <= @PRICE";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@PRICE", maxPrice);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dish>();

                            Dish dish = new Dish();


                            dish.ID_DISH = (int)dr["ID_DISH"];

                            dish.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];

                            dish.NAME = (string)dr["NAME"];

                            dish.PRICE = (decimal)dr["PRICE"];

                            if (dr["image_url"] != DBNull.Value)
                            {
                                dish.image_url = (string)dr["image_url"];
                            }

                            results.Add(dish);
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
