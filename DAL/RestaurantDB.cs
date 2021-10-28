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
    class RestaurantDB : IRestaurantDB
    {

        private IConfiguration Configuration { get; }

        public RestaurantDB(IConfiguration conf)
        {
            Configuration = conf;
        }
        public Restaurant addRestaurant(Restaurant restaurant)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into RESTAURANT(ID_RESTAURANT,ID_CITY,IDTYPE,NAME,ADRESS,PHONENUMBER) values(@ID_CITY,@IDTYPE,@NAME,@ADRESS,@PHONENUMBER); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_CITY", restaurant.ID_CITY);
                    cmd.Parameters.AddWithValue("@IDTYPE", restaurant.IDTYPE);
                    cmd.Parameters.AddWithValue("@NAME", restaurant.NAME);
                    cmd.Parameters.AddWithValue("@ADRESS", restaurant.ADRESS);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", restaurant.PHONENUMBER);

                    cn.Open();

                    restaurant.ID_RESTAURANT = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;

        }

        public Restaurant GetRestaurant(string name, string adress)
        {
            Restaurant restaurant = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RESTAURANT WHERE NAME = @Name AND ADRESS = @Adress";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Adress", adress);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        restaurant = new Restaurant();
                        restaurant.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                        restaurant.ID_CITY = (int)dr["ID_CITY"];
                        restaurant.IDTYPE = (int)dr["IDTYPE"];
                        restaurant.NAME = (string)dr["NAME"];
                        restaurant.ADRESS = (string)dr["ADRESS"];
                        restaurant.PHONENUMBER = (string)dr["PHONENUMBER"];



                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RESTAURANT";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            restaurant.ID_CITY = (int)dr["ID_CITY"];
                            restaurant.IDTYPE = (int)dr["IDTYPE"];
                            restaurant.NAME = (string)dr["NAME"];
                            restaurant.ADRESS = (string)dr["ADRESS"];
                            restaurant.PHONENUMBER = (string)dr["PHONENUMBER"];

                            results.Add(restaurant);
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
