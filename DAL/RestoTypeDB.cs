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
    public class RestoTypeDB : IRestoTypeDB
    {

        private IConfiguration Configuration { get; }

        public RestoTypeDB(IConfiguration conf)
        {
            Configuration = conf;
        }


        public RestoType addRestoType(RestoType restoType)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into RESTOTYPE(ID_TYPE, TYPENAME) values(@Typename); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Typename", restoType.TYPENAME);

                    cn.Open();

                    restoType.IDTYPE = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restoType;
        }

        public RestoType GetRestoType(string typeName)
        {
            RestoType restoType = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RESTOTYPE WHERE CITYNAME = @typeName";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@typeName", typeName);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        restoType = new RestoType();

                        restoType.IDTYPE = (int)dr["IDTYPE"];

                        restoType.TYPENAME = (string)dr["TYPENAME"];


                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restoType;
        }

                
        
        public RestoType GetRestoType(int idType)
        {
             RestoType restoType = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RESTOTYPE WHERE IDTYPE = @idType";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idType", idType);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        restoType = new RestoType();

                        restoType.IDTYPE = (int)dr["IDTYPE"];

                        restoType.TYPENAME = (string)dr["TYPENAME"];


                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restoType;
        }


        public List<RestoType> GetRestoTypes()
        {
            List<RestoType> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from RESTOTYPE";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<RestoType>();

                            RestoType restoType = new RestoType();

                            restoType.IDTYPE = (int)dr["IDTYPE"];

                            restoType.TYPENAME = (string)dr["TYPENAME"];

                            results.Add(restoType);
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
