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
    public class CityDB : ICityDB
    {


        //configuration
        private IConfiguration Configuration { get; }

        public CityDB(IConfiguration conf)
        {
            Configuration =conf;
        }

        //---------------------------------------------------
        // GET by one METHOD
        //---------------------------------------------------
        //get a city by its ID.
        public City GetCity(int idCity)
        {
            City city = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from CITY WHERE IDCITY = @idCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCity", idCity);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            city = new City();
                            city.IDCITY = (int)dr["IDCITY"];

                            city.CITYNAME = (string)dr["CITYNAME"];

                            city.NPA = (string)dr["NPA"];

                            if(dr["image_url"] != DBNull.Value)
                            {
                                city.image_url = (string)dr["image_url"];
                            }


                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return city;
        }

        //get a city by its name
        public City GetCity(string cityname)
        {
            City city = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from CITY WHERE CITYNAME = @CITYNAME";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@CITYNAME", cityname);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            city = new City();
                            city.IDCITY = (int)dr["IDCITY"];

                            city.CITYNAME = (string)dr["CITYNAME"];

                            city.NPA = (string)dr["NPA"];

                            if (dr["image_url"] != DBNull.Value)
                            {
                                city.image_url = (string)dr["image_url"];
                            }


                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return city;
        }



        //---------------------------------------------------
        // UPDATE METHOD
        //---------------------------------------------------

        public City UpdateCity(int idCity, City newCity)
         {
            City city = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE CITY SET CITYNAME= @CITYNAME , NPA = @NPA, image_url = @image_url WHERE IDCITY = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@CITYNAME", newCity.CITYNAME);
                    cmd.Parameters.AddWithValue("@NPA", newCity.NPA);
                    cmd.Parameters.AddWithValue("@image_url", newCity.image_url);

                    cmd.Parameters.AddWithValue("@id", idCity);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {

                            city = new City();
                            city.IDCITY = (int)dr["IDCITY"];

                            city.CITYNAME = (string)dr["CITYNAME"];

                            city.NPA = (string)dr["NPA"];

                            if (dr["image_url"] != DBNull.Value)
                            {
                                city.image_url = (string)dr["image_url"];
                            }


                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return city;
        }

        //---------------------------------------------------
        // GET by Lists METHODS
        //---------------------------------------------------

        public List<City> GetCities()
        {
            List<City> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from CITY";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<City>();

                            City city = new City();

                            city.IDCITY = (int)dr["IDCITY"];

                            city.CITYNAME = (string)dr["CITYNAME"];

                            city.NPA = (string)dr["NPA"];

                            if(dr["image_url"]!=DBNull.Value)
                            {
                                city.image_url = (string)dr["image_url"];

                            }


                            results.Add(city);
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
