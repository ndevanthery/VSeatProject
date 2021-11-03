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
    public class CustomerDB : ICustomerDB
    {

        //configuration
        private IConfiguration Configuration { get; }

        public CustomerDB(IConfiguration conf)
        {
            Configuration = conf;
        }






        //---------------------------------------------------
        // ADD METHODS
        //---------------------------------------------------

        public Customer addCustomer(Customer customer)
        {

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into CUSTOMER(IDCITY,NAME,FIRSTNAME,LASTNAME,ADRESS,PHONENUMBER,USERNAME,PASSWORD,EMAIL) values(@IDCITY,@NAME,@FIRSTNAME,@LASTNAME,@ADRESS,@PHONENUMBER,@USERNAME,@PASSWORD,@EMAIL); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_CITY", customer.IDCITY);
                    cmd.Parameters.AddWithValue("@NAME", customer.FIRSTNAME);
                    cmd.Parameters.AddWithValue("@SURNAME", customer.LASTNAME);
                    cmd.Parameters.AddWithValue("@ADRESS", customer.ADRESS);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", customer.PHONENUMBER);
                    cmd.Parameters.AddWithValue("@USERNAME", customer.USERNAME);
                    cmd.Parameters.AddWithValue("@PASSWORD", customer.PASSWORD);
                    cmd.Parameters.AddWithValue("@EMAIL", customer.EMAIL);


                    cn.Open();

                    customer.ID_CUSTOMER = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return customer;

        }




        //---------------------------------------------------
        // GET by Lists METHODS
        //---------------------------------------------------


        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers(int id_city)
        {
            throw new NotImplementedException();
        }



        //---------------------------------------------------
        // GET by one METHODS
        //---------------------------------------------------

        public Customer GetCustomerByName(string firstname, string lastname)
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from CUSTOMER WHERE FIRSTNAME = @firstname AND LASTNAME=@lastname";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@lastname", lastname);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        customer = new Customer();
                        customer.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                        customer.IDCITY = (int)dr["IDCITY"];
                        customer.FIRSTNAME = (string)dr["NAME"];
                        customer.LASTNAME = (string)dr["SURNAME"];
                        customer.ADRESS = (string)dr["ADRESS"];
                        customer.PHONENUMBER = (string)dr["PHONENUMBER"];
                        customer.USERNAME = (string)dr["USERNAME"];
                        customer.PASSWORD = (string)dr["PASSWORD"];
                        customer.EMAIL  = (string)dr["EMAIL"];




                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return customer;
        }

       public Customer GetCustomerByEmail(string email)
       {
            throw new NotImplementedException();
       }



       
    
    }
}
