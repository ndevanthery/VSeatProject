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

        private IConfiguration Configuration { get; }

        public CityDB(IConfiguration conf)
        {
            Configuration =conf;
        }

        public City AddCity(City city)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into CITY(ID_CITY, CITYNAME) values(@cityName); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@cityName", city.CITYNAME);

                    cn.Open();

                    city.ID_CITY = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return city;

        }

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

                            city.ID_CITY = (int)dr["ID_CITY"];

                            city.CITYNAME = (string)dr["CITYNAME"];

                            results.Add(city);
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


        public City GetCity(string cityName)
        {
            City city = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from CITY WHERE CITYNAME = @cityName";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@cityName", cityName);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        city = new City();

                        city.ID_CITY = (int)dr["ID_CITY"];

                        city.CITYNAME = (string)dr["CITYNAME"];

                        
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return city;
        }



        public City GetCity(int idCity)
        {
            City city = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from CITY WHERE ID_CITY = @idCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCity", idCity);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        city = new City();

                        city.ID_CITY = (int)dr["ID_CITY"];

                        city.CITYNAME = (string)dr["CITYNAME"];

                        
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return city;
        }

    }
}
