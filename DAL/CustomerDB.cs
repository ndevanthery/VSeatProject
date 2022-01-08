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


        //---------------------------------------------------
        // CONFIGURATION
        //---------------------------------------------------

        private IConfiguration Configuration { get; }

        public CustomerDB(IConfiguration conf)
        {
            Configuration = conf;
        }



        //---------------------------------------------------
        // ADD METHOD
        //---------------------------------------------------

        public Customer AddCustomer(Customer customer)
        {

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into CUSTOMER(IDCITY,FIRSTNAME,LASTNAME,ADRESS,PHONENUMBER,USERNAME,PASSWORD,EMAIL,image_url,confirmed) values(@IDCITY,@FIRSTNAME,@LASTNAME,@ADRESS,@PHONENUMBER,@USERNAME,@PASSWORD,@EMAIL,@image_url,@confirmed); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IDCITY", customer.IDCITY);
                    cmd.Parameters.AddWithValue("@FIRSTNAME", customer.FIRSTNAME);
                    cmd.Parameters.AddWithValue("@LASTNAME", customer.LASTNAME);
                    cmd.Parameters.AddWithValue("@ADRESS", customer.ADRESS);
                    if(customer.PHONENUMBER == null)
                    {
                        cmd.Parameters.AddWithValue("@PHONENUMBER", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PHONENUMBER", customer.PHONENUMBER);

                    }

                    cmd.Parameters.AddWithValue("@USERNAME", customer.USERNAME);
                    cmd.Parameters.AddWithValue("@PASSWORD", customer.PASSWORD);
                    cmd.Parameters.AddWithValue("@EMAIL", customer.EMAIL);
                    if(customer.image_url == null)
                    {
                        cmd.Parameters.AddWithValue("@image_url", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_url", customer.image_url);

                    }
                    cmd.Parameters.AddWithValue("@confirmed", false);

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
        // GET by one METHOD
        //---------------------------------------------------
        //get a customer by its ID
        public Customer GetCustomer(int idCustomer)
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from CUSTOMER where ID_CUSTOMER = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idCustomer);
                    
                    

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            customer = new Customer();
                            customer.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            customer.IDCITY = (int)dr["IDCITY"];
                            customer.FIRSTNAME = (string)dr["FIRSTNAME"];
                            customer.LASTNAME = (string)dr["LASTNAME"];
                            customer.ADRESS = (string)dr["ADRESS"];

                            if(dr["PHONENUMBER"]!=DBNull.Value)
                            {
                                customer.PHONENUMBER = (string)dr["PHONENUMBER"];

                            }
                            customer.USERNAME = (string)dr["USERNAME"];
                            customer.PASSWORD = (string)dr["PASSWORD"];

                            customer.EMAIL = (string)dr["EMAIL"];
                            if(dr["image_url"]!=DBNull.Value)
                            {
                                customer.image_url = (string)dr["image_url"];
                            }
                            customer.confirmed = (bool)dr["confirmed"];
                        }
                        


                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return customer;
        }


        //---------------------------------------------------
        // UPDATE METHOD
        //---------------------------------------------------

        public Customer UpdateCustomer(int id_customer , Customer customer)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE CUSTOMER SET IDCITY = @IDCITY , FIRSTNAME= @FIRSTNAME , LASTNAME = @LASTNAME , ADRESS = @ADRESS , PHONENUMBER =@PHONENUMBER, USERNAME=@USERNAME, PASSWORD = @PASSWORD , EMAIL=@EMAIL, image_url = @image_url , confirmed = @confirmed WHERE ID_CUSTOMER = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IDCITY", customer.IDCITY);
                    cmd.Parameters.AddWithValue("@FIRSTNAME", customer.FIRSTNAME);
                    cmd.Parameters.AddWithValue("@LASTNAME", customer.LASTNAME);
                    cmd.Parameters.AddWithValue("@ADRESS", customer.ADRESS);
                    if (customer.PHONENUMBER == null)
                    {
                        cmd.Parameters.AddWithValue("@PHONENUMBER", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PHONENUMBER", customer.PHONENUMBER);

                    }

                    cmd.Parameters.AddWithValue("@USERNAME", customer.USERNAME);
                    cmd.Parameters.AddWithValue("@PASSWORD", customer.PASSWORD);
                    cmd.Parameters.AddWithValue("@EMAIL", customer.EMAIL);
                    if (customer.image_url == null)
                    {
                        cmd.Parameters.AddWithValue("@image_url", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_url", customer.image_url);

                    }
                    cmd.Parameters.AddWithValue("@confirmed", customer.confirmed);

                    cmd.Parameters.AddWithValue("@id", id_customer);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            customer = new Customer();
                            customer.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            customer.IDCITY = (int)dr["IDCITY"];
                            customer.FIRSTNAME = (string)dr["FIRSTNAME"];
                            customer.LASTNAME = (string)dr["LASTNAME"];
                            customer.ADRESS = (string)dr["ADRESS"];

                            if (dr["PHONENUMBER"] != DBNull.Value)
                            {
                                customer.PHONENUMBER = (string)dr["PHONENUMBER"];

                            }
                            customer.USERNAME = (string)dr["USERNAME"];
                            customer.PASSWORD = (string)dr["PASSWORD"];

                            customer.EMAIL = (string)dr["EMAIL"];
                            if (dr["image_url"] != DBNull.Value)
                            {
                                customer.image_url = (string)dr["image_url"];
                            }
                            customer.confirmed = (bool)dr["confirmed"];
                        }


                    }
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
            List<Customer> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from CUSTOMER";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Customer>();

                            Customer customer = new Customer();

                            customer.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            customer.IDCITY = (int)dr["IDCITY"];
                            customer.FIRSTNAME = (string)dr["FIRSTNAME"];
                            customer.LASTNAME = (string)dr["LASTNAME"];
                            customer.ADRESS = (string)dr["ADRESS"];

                            if (dr["PHONENUMBER"] != DBNull.Value)
                            {
                                customer.PHONENUMBER = (string)dr["PHONENUMBER"];

                            }
                            customer.USERNAME = (string)dr["USERNAME"];
                            customer.PASSWORD = (string)dr["PASSWORD"];

                            customer.EMAIL = (string)dr["EMAIL"];
                            if (dr["image_url"] != DBNull.Value)
                            {
                                customer.image_url = (string)dr["image_url"];
                            }
                            customer.confirmed = (bool)dr["confirmed"];

                            results.Add(customer);
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
