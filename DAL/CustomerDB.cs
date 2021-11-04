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
                            customer.ID_CITY = (int)dr["ID_CITY"];
                            customer.NAME = (string)dr["NAME"];
                            customer.SURNAME = (string)dr["SURNAME"];
                            customer.ADRESS = (string)dr["ADRESS"];
                            customer.POSTALCODE = (string)dr["POSTALCODE"];
                            customer.PHONENUMBER = (string)dr["PHONENUMBER"];
                            customer.PASSWORD = (string)dr["PASSWORD"];
                            // EMAIL PAS ENCORE AJOUTEE
                            customer.EMAIL = (string)dr["EMAIL"];

                            results.Add(customer);
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
        //ATTENTION L'ATTRIBUT "EMAIL" N AS PAS ETE AJOUTE
        public Customer GetCustomerByEmail(string email)
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from CUSTOMER WHERE EMAIL = @Email";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Email", email);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        customer = new Customer();

                        customer.ID_CUSTOMER = (int)dr["ID_CUSTOMER"];
                        customer.ID_CITY = (int)dr["ID_CITY"];
                        customer.NAME = (string)dr["NAME"];
                        customer.SURNAME = (string)dr["SURNAME"];
                        customer.ADRESS = (string)dr["ADRESS"];
                        customer.POSTALCODE = (string)dr["POSTALCODE"];
                        customer.PHONENUMBER = (string)dr["PHONENUMBER"];
                        customer.PASSWORD = (string)dr["PASSWORD"];
                        // EMAIL PAS ENCORE AJOUTEE
                        customer.EMAIL = (string)dr["EMAIL"];

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
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
                                customer.ID_CITY = (int)dr["ID_CITY"];
                                customer.NAME = (string)dr["NAME"];
                                customer.SURNAME = (string)dr["SURNAME"];
                                customer.ADRESS = (string)dr["ADRESS"];
                                customer.POSTALCODE = (string)dr["POSTALCODE"];
                                customer.PHONENUMBER = (string)dr["PHONENUMBER"];
                                customer.PASSWORD = (string)dr["PASSWORD"];
                                // EMAIL PAS ENCORE AJOUTEE
                                customer.EMAIL = (string)dr["EMAIL"];

                                results.Add(customer);
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

        

        
    public Customer updateCustomer(int id_customer)
    {
        Customer customer = null;
        string connectionString = Configuration.GetConnectionString("DefaultConnection");

        try
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "UPDATE CUSTOMER SET NAME = @Name,SURNAME = @Surname,ADRESS = @Adress,POSTALCODE = @Postalcode,PHONENUMBER = @Phonenumber,EMAIL = @Email WHERE ID_CUSTOMER = @Id_customer";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Id_customer", id_customer);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    customer = new Customer();

                    // Changement de la table
                    cmd.Parameters.AddWithValue("@NAME", customer.NAME);
                    cmd.Parameters.AddWithValue("@SURNAME", customer.SURNAME);
                    cmd.Parameters.AddWithValue("@ADRESS", customer.ADRESS);
                    cmd.Parameters.AddWithValue("@POSTALCODE", customer.POSTALCODE);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", customer.PHONENUMBER);
                    cmd.Parameters.AddWithValue("@EMAIL", customer.EMAIL);


                    }
            }
        }
        catch (Exception e)
        {
            throw e;
        }

        return customer;

    }
}
}
