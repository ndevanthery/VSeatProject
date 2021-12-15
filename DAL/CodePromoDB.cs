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


        //add

        public CodePromo AddCodePromo(CodePromo codePromo)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into CODEPROMO(ID_RESTAURANT,CODEPROMO,DISCOUNT) values(@ID_RESTAURANT,@CODEPROMO,@DISCOUNT); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_RESTAURANT", codePromo.ID_RESTAURANT);
                    cmd.Parameters.AddWithValue("@CODEPROMO", codePromo.CODEPROMO);
                    cmd.Parameters.AddWithValue("@DISCOUNT", codePromo.DISCOUNT);

                    cn.Open();

                    codePromo.ID_CODEPROMO= Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return codePromo;
        }


        public List<CodePromo> GetCodes(int idRestaurant)
        {
            {
                List<CodePromo> results = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "Select * from CODEPROMO WHERE ID_RESTAURANT = @id";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@id", idRestaurant);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (results == null)
                                    results = new List<CodePromo>();

                                CodePromo codePromo = new CodePromo();

                                codePromo.ID_CODEPROMO = (int)dr["ID_CODEPROMO"];
                                codePromo.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                                codePromo.CODEPROMO = (string)dr["CODEPROMO"];
                                codePromo.DISCOUNT = (int)dr["DISCOUNT"];

                                results.Add(codePromo);
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
