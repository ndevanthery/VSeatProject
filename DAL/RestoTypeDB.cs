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
        //---------------------------------------------------
        // CONFIGURATION
        //---------------------------------------------------


        private IConfiguration Configuration { get; }

        public RestoTypeDB(IConfiguration conf)
        {
            Configuration = conf;
        }




        //---------------------------------------------------
        // GET ONE METHOD
        //---------------------------------------------------

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
                        while (dr.Read())
                        {

                            restoType = new RestoType();

                            restoType.IDTYPE = (int)dr["IDTYPE"];

                            restoType.TYPENAME = (string)dr["TYPENAME"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return restoType;
        }



    }
}
