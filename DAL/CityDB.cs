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
        // ADD METHODS
        //---------------------------------------------------

        public City AddCity(City city)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into CITY(CITYNAME,NPA) values(@cityName,@npa); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@cityName", city.CITYNAME);
                    cmd.Parameters.AddWithValue("@npa", city.NPA);

                    cn.Open();

                    city.IDCITY = Convert.ToInt32(cmd.ExecuteScalar());
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

                            city.NPA = (int)dr["NPA"];


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







        //---------------------------------------------------
        // GET by one METHODS
        //---------------------------------------------------

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

                        city.IDCITY = (int)dr["IDCITY"];

                        city.CITYNAME = (string)dr["CITYNAME"];

                        city.NPA = (int)dr["NPA"];



                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                    string query = "Select * from CITY WHERE IDCITY = @idCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCity", idCity);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        city = new City();

                        city.IDCITY = (int)dr["IDCITY"];

                        city.CITYNAME = (string)dr["CITYNAME"];

                        city.NPA = (int)dr["NPA"];

                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return city;
        }

    }
}
