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
                    string query = "Insert into CUSTOMER(IDCITY,FIRSTNAME,LASTNAME,ADRESS,PHONENUMBER,USERNAME,PASSWORD,EMAIL) values(@IDCITY,@FIRSTNAME,@LASTNAME,@ADRESS,@PHONENUMBER,@USERNAME,@PASSWORD,@EMAIL); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IDCITY", customer.IDCITY);
                    cmd.Parameters.AddWithValue("@FIRSTNAME", customer.FIRSTNAME);
                    cmd.Parameters.AddWithValue("@LASTNAME", customer.LASTNAME);
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
        // GET by one METHOD
        //---------------------------------------------------

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
                        if(dr.Read())
                        {
                            customer = new Customer();
                            customer.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            customer.IDCITY = (int)dr["IDCITY"];
                            customer.FIRSTNAME = (string)dr["FIRSTNAME"];
                            customer.LASTNAME = (string)dr["LASTNAME"];
                            customer.ADRESS = (string)dr["ADRESS"];
                            customer.PHONENUMBER = (string)dr["PHONENUMBER"];
                            customer.USERNAME = (string)dr["USERNAME"];
                            customer.PASSWORD = (string)dr["PASSWORD"];

                            customer.EMAIL = (string)dr["EMAIL"];
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

        public Customer UpdateCustomer(int id_customer , Customer newCustomer)
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE CUSTOMER SET IDCITY = @IDCITY , FIRSTNAME= @FIRSTNAME , LASTNAME = @LASTNAME , ADRESS = @ADRESS , PHONENUMBER =@PHONENUMBER, USERNAME=@USERNAME, PASSWORD = @PASSWORD , EMAIL=@EMAIL WHERE ID_CUSTOMER = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IDCITY", newCustomer.IDCITY );
                    cmd.Parameters.AddWithValue("@FIRSTNAME", newCustomer.FIRSTNAME);
                    cmd.Parameters.AddWithValue("@LASTNAME", newCustomer.LASTNAME);
                    cmd.Parameters.AddWithValue("@ADRESS", newCustomer.ADRESS);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", newCustomer.PHONENUMBER);
                    cmd.Parameters.AddWithValue("@USERNAME", newCustomer.USERNAME);
                    cmd.Parameters.AddWithValue("@PASSWORD", newCustomer.PASSWORD);
                    cmd.Parameters.AddWithValue("@EMAIL", newCustomer.EMAIL);

                    cmd.Parameters.AddWithValue("@id", id_customer);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        customer = new Customer();
                        customer.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                        customer.IDCITY = (int)dr["IDCITY"];
                        customer.FIRSTNAME = (string)dr["FIRSTNAME"];
                        customer.LASTNAME = (string)dr["LASTNAME"];
                        customer.ADRESS = (string)dr["ADRESS"];
                        customer.PHONENUMBER = (string)dr["PHONENUMBER"];
                        customer.USERNAME = (string)dr["USERNAME"];
                        customer.PASSWORD = (string)dr["PASSWORD"];

                        customer.EMAIL = (string)dr["EMAIL"];


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
        // DELETE METHOD
        //---------------------------------------------------
        public Customer DeleteCustomer(int id_customer)
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM CUSTOMER WHERE ID_CUSTOMER = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id_customer);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        customer = new Customer();
                        customer.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                        customer.IDCITY = (int)dr["IDCITY"];
                        customer.FIRSTNAME = (string)dr["FIRSTNAME"];
                        customer.LASTNAME = (string)dr["LASTNAME"];
                        customer.ADRESS = (string)dr["ADRESS"];
                        customer.PHONENUMBER = (string)dr["PHONENUMBER"];
                        customer.USERNAME = (string)dr["USERNAME"];
                        customer.PASSWORD = (string)dr["PASSWORD"];

                        customer.EMAIL = (string)dr["EMAIL"];


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

                            customer = new Customer();
                            customer.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                            customer.IDCITY = (int)dr["IDCITY"];
                            customer.FIRSTNAME = (string)dr["FIRSTNAME"];
                            customer.LASTNAME = (string)dr["LASTNAME"];
                            customer.ADRESS = (string)dr["ADRESS"];
                            customer.PHONENUMBER = (string)dr["PHONENUMBER"];
                            customer.USERNAME = (string)dr["USERNAME"];
                            customer.PASSWORD = (string)dr["PASSWORD"];

                            customer.EMAIL = (string)dr["EMAIL"];

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
        public List<Customer> GetCustomers(int id_city)
        {
            {
                List<Customer> results = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "Select * from CUSTOMER WHERE ID_CITY = @Id_city";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@Id_city", id_city);

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
                                customer.PHONENUMBER = (string)dr["PHONENUMBER"];
                                customer.USERNAME = (string)dr["USERNAME"];
                                customer.PASSWORD = (string)dr["PASSWORD"];

                                customer.EMAIL = (string)dr["EMAIL"];
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
}
