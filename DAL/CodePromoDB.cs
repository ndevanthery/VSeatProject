using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class CodePromoDB : ICodePromoDB
    {
        //configuration .
        private IConfiguration Configuration { get; }

        public CodePromoDB(IConfiguration conf)
        {
            Configuration = conf;
        }

        //get the codePromo by its stringCode
        public CodePromo GetCode(string codeString)
        {
            {
                CodePromo codePromo = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "Select * from CODEPROMO WHERE CODEPROMO = @CODEPROMO";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@CODEPROMO", codeString);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                codePromo = new CodePromo();

                                codePromo.ID_CODEPROMO = (int)dr["ID_CODEPROMO"];
                                codePromo.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                                codePromo.CODEPROMO = (string)dr["CODEPROMO"];
                                codePromo.DISCOUNT = (int)dr["DISCOUNT"];

                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return codePromo;
            }


        }




    }
}
