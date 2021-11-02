using DTO;
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
        private IConfiguration Configuration { get; }

        public DishDB(IConfiguration conf)
        {
            Configuration = conf;
        }

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

                            dish.IMAGE = (ImageFormat)dr["IMAGE"];

                            dish.NAME = (string)dr["NAME"];

                            dish.COST_PRICE = (double)dr["COST_PRICE"];

                            dish.SELL_PRICE = (double)dr["SELL_PRICE"];

                            results.Add(dish);
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

                            dish.IMAGE = (ImageFormat)dr["IMAGE"];

                            dish.NAME = (string)dr["NAME"];

                            dish.COST_PRICE = (double)dr["COST_PRICE"];

                            dish.SELL_PRICE = (double)dr["SELL_PRICE"];

                            results.Add(dish);
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

        public List<Dish> GetDishesUnderPrice(int maxPrice)
        {
            List<Dish> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DISH WHERE SELL_PRICE <= @Sell_price";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@SELL_PRICE", maxPrice);

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

                            dish.IMAGE = (ImageFormat)dr["IMAGE"];

                            dish.NAME = (string)dr["NAME"];

                            dish.COST_PRICE = (double)dr["COST_PRICE"];

                            dish.SELL_PRICE = (double)dr["SELL_PRICE"];

                            results.Add(dish);
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

        public Dish GetDish(string name)
        {
            Dish dish = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from DISH WHERE NAME = @Name";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", name);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        dish = new Dish();


                        dish.ID_DISH = (int)dr["ID_DISH"];

                        dish.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];

                        dish.IMAGE = (ImageFormat)dr["IMAGE"];

                        dish.NAME = (string)dr["NAME"];

                        dish.COST_PRICE = (double)dr["COST_PRICE"];

                        dish.SELL_PRICE = (double)dr["SELL_PRICE"];


                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }

        public Dish addDish(Dish dish)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into DISH(ID_DISH,ID_RESTAURANT,IMAGE,NAME,COST_PRICE,SELL_PRICE) values(@ID_RESTAURANT,@IMAGE,@NAME,@COST_PRICE,@SELL_PRICE); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_RESTAURANT", dish.ID_RESTAURANT);
                    cmd.Parameters.AddWithValue("@IMAGE", dish.IMAGE);
                    cmd.Parameters.AddWithValue("@NAME", dish.NAME);
                    cmd.Parameters.AddWithValue("@COST_PRICE", dish.COST_PRICE);
                    cmd.Parameters.AddWithValue("@SELL_PRICE", dish.SELL_PRICE);

                    cn.Open();

                    dish.ID_DISH = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }
    
        
    }
}
