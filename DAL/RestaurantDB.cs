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
    public class RestaurantDB : IRestaurantDB
    {

        //---------------------------------------------------
        // configuration METHOD
        //---------------------------------------------------

        private IConfiguration Configuration { get; }

        public RestaurantDB(IConfiguration conf)
        {
            Configuration = conf;
        }


        //---------------------------------------------------
        // ADD METHOD
        //---------------------------------------------------

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into RESTAURANT(IDTYPE,IDCITY,NAME,ADRESS,PHONENUMBER,USERNAME,PASSWORD) values(@IDTYPE,@IDCITY,@NAME,@ADRESS,@PHONENUMBER,@USERNAME,@PASSWORD); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IDTYPE", restaurant.IDTYPE);

                    cmd.Parameters.AddWithValue("@IDCITY", restaurant.IDCITY);
                    cmd.Parameters.AddWithValue("@NAME", restaurant.NAME);
                    cmd.Parameters.AddWithValue("@ADRESS", restaurant.ADRESS);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", restaurant.PHONENUMBER);
                    cmd.Parameters.AddWithValue("@USERNAME", restaurant.USERNAME);
                    cmd.Parameters.AddWithValue("@ID_CITY", restaurant.PASSWORD);



                    cn.Open();

                    restaurant.ID_RESTAURANT = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return restaurant;

        }

        //---------------------------------------------------
        // GET ONE METHOD
        //---------------------------------------------------

        public Restaurant GetRestaurant(int idRestaurant)
        {
            Restaurant restaurant = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RESTAURANT WHERE ID_RESTAURANT = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idRestaurant);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        restaurant = new Restaurant();
                        restaurant.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                        restaurant.IDCITY = (int)dr["IDCITY"];
                        restaurant.IDTYPE = (int)dr["IDTYPE"];
                        restaurant.NAME = (string)dr["NAME"];
                        restaurant.ADRESS = (string)dr["ADRESS"];
                        restaurant.PHONENUMBER = (string)dr["PHONENUMBER"];
                        restaurant.USERNAME = (string)dr["USERNAME"];
                        restaurant.PASSWORD = (string)dr["PASSWORD"];



                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return restaurant;
        }

        //---------------------------------------------------
        // UPDATE METHOD
        //---------------------------------------------------

        public Restaurant UpdateRestaurant(int idRestaurant, Restaurant newRestaurant)
        {

            Restaurant restaurant = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE RESTAURANT SET IDTYPE = @IDTYPE , IDCITY= @IDCITY , NAME = @NAME , ADRESS = @ADRESS , PHONENUMBER =@PHONENUMBER, USERNAME=@USERNAME, PASSWORD = @PASSWORD WHERE ID_RESTAURANT = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IDTYPE", restaurant.IDTYPE);
                    cmd.Parameters.AddWithValue("@IDCITY", restaurant.IDCITY);
                    cmd.Parameters.AddWithValue("@NAME", restaurant.NAME);
                    cmd.Parameters.AddWithValue("@ADRESS", restaurant.ADRESS);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", restaurant.PHONENUMBER);
                    cmd.Parameters.AddWithValue("@USERNAME", restaurant.USERNAME);
                    cmd.Parameters.AddWithValue("@PASSWORD", restaurant.PASSWORD);

                    cmd.Parameters.AddWithValue("@id", idRestaurant);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        restaurant = new Restaurant();
                        restaurant.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                        restaurant.IDCITY = (int)dr["IDCITY"];
                        restaurant.IDTYPE = (int)dr["IDTYPE"];
                        restaurant.NAME = (string)dr["NAME"];
                        restaurant.ADRESS = (string)dr["ADRESS"];
                        restaurant.PHONENUMBER = (string)dr["PHONENUMBER"];
                        restaurant.USERNAME = (string)dr["USERNAME"];
                        restaurant.PASSWORD = (string)dr["PASSWORD"];


                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return restaurant;
        }

        //---------------------------------------------------
        // DELETE METHOD
        //---------------------------------------------------

        public Restaurant DeleteRestaurant(int idRestaurant)
        {
            Restaurant restaurant = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM RESTAURANT WHERE ID_RESTAURANT = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idRestaurant);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        restaurant = new Restaurant();
                        restaurant.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                        restaurant.IDCITY = (int)dr["IDCITY"];
                        restaurant.IDTYPE = (int)dr["IDTYPE"];
                        restaurant.NAME = (string)dr["NAME"];
                        restaurant.ADRESS = (string)dr["ADRESS"];
                        restaurant.PHONENUMBER = (string)dr["PHONENUMBER"];
                        restaurant.USERNAME = (string)dr["USERNAME"];
                        restaurant.PASSWORD = (string)dr["PASSWORD"];

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return restaurant;
        }



        //---------------------------------------------------
        // GET LISTS METHOD
        //---------------------------------------------------

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
                            restaurant.IDCITY = (int)dr["IDCITY"];
                            restaurant.IDTYPE = (int)dr["IDTYPE"];
                            restaurant.NAME = (string)dr["NAME"];
                            restaurant.ADRESS = (string)dr["ADRESS"];
                            restaurant.PHONENUMBER = (string)dr["PHONENUMBER"];
                            restaurant.USERNAME = (string)dr["USERNAME"];
                            restaurant.PASSWORD = (string)dr["PASSWORD"];

                            results.Add(restaurant);
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

        public List<Restaurant> GetRestaurantsByCity(int id_city)
        {
            List<Restaurant> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RESTAURANT WHERE IDCITY = @idCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCity", id_city);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            restaurant.IDCITY = (int)dr["IDCITY"];
                            restaurant.IDTYPE = (int)dr["IDTYPE"];
                            restaurant.NAME = (string)dr["NAME"];
                            restaurant.ADRESS = (string)dr["ADRESS"];
                            restaurant.PHONENUMBER = (string)dr["PHONENUMBER"];
                            restaurant.USERNAME = (string)dr["USERNAME"];
                            restaurant.PASSWORD = (string)dr["PASSWORD"];

                            results.Add(restaurant);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return results;        }

        public List<Restaurant> GetRestaurantsByType(int id_type)
        {
            List<Restaurant> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RESTAURANT WHERE IDTYPE = @idType";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idType", id_type);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            restaurant.IDCITY = (int)dr["IDCITY"];
                            restaurant.IDTYPE = (int)dr["IDTYPE"];
                            restaurant.NAME = (string)dr["NAME"];
                            restaurant.ADRESS = (string)dr["ADRESS"];
                            restaurant.PHONENUMBER = (string)dr["PHONENUMBER"];
                            restaurant.USERNAME = (string)dr["USERNAME"];
                            restaurant.PASSWORD = (string)dr["PASSWORD"];

                            results.Add(restaurant);
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
