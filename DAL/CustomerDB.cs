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
        private IConfiguration Configuration { get; }

        public CustomerDB(IConfiguration conf)
        {
            Configuration = conf;
        }

        public Customer addCustomer(Customer customer)
        {

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into CUSTOMER(ID_CUSTOMER,ID_CITY,NAME,SURNAME,ADRESS,POSTALCODE,PHONENUMBER,PASSWORD) values(ID_CITY,NAME,SURNAME,ADRESS,POSTALCODE,PHONENUMBER,PASSWORD); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_CITY", customer.ID_CITY);
                    cmd.Parameters.AddWithValue("@NAME", customer.NAME);
                    cmd.Parameters.AddWithValue("@SURNAME", customer.SURNAME);
                    cmd.Parameters.AddWithValue("@ADRESS", customer.ADRESS);
                    cmd.Parameters.AddWithValue("@POSTALCODE", customer.POSTALCODE);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", customer.PHONENUMBER);
                    cmd.Parameters.AddWithValue("@PASSWORD", customer.PASSWORD);
                    // EMAIL PAS ENCORE AJOUTEE
                    customer.EMAIL = (string)dr["EMAIL"];
                    cn.Open();

                    customer.ID_CUSTOMER = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;

        }

        public Customer GetCustomerByName(string name, string surname)
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from CUSTOMER WHERE NAME = @name AND SURNAME=@surname";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);


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

        public Customer updateCustomerAdress(int id_customer, string adress)
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE CUSTOMER SET ADRESS = @ADRESS WHERE ID_CUSTOMER = @Id_customer";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ADRESS", adress);
                    cmd.Parameters.AddWithValue("@Id_customer", id_customer);

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
                        // Changement d'adresse
                        cmd.Parameters.AddWithValue("@ADRESS", customer.ADRESS);

                        
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }

        public Customer updateCustomerPhoneNumber(int id_customer, string phoneNumber)
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE CUSTOMER SET PHONENUMBER = @Phonenumber WHERE ID_CUSTOMER = @Id_customer";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ADRESS", phoneNumber);
                    cmd.Parameters.AddWithValue("@Id_customer", id_customer);

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
                        // Changement de numéro de téléphone
                        cmd.Parameters.AddWithValue("@PHONENUMBER", customer.PHONENUMBER);


                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }

        public Customer updateCustomerPassword(int id_customer, string password)
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE CUSTOMER SET PASSWORD = @Password WHERE ID_CUSTOMER = @Id_customer";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@PASSWORD", password);
                    cmd.Parameters.AddWithValue("@Id_customer", id_customer);

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
                        // Changement de numéro de téléphone
                        cmd.Parameters.AddWithValue("@PASSWORD", customer.PASSWORD);


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
