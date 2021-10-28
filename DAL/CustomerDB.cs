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
                    //quand la personne va crée son compte elle ne va pas savoir quoi mettre dans ID_CITY car elle ne connait pas
                    //L'id de sa ville, ajouter un attribut "CITY" ?
                    string query = "Insert into CUSTOMER(ID_CUSTOMER,ID_CITY,NAME,SURNAME,ADRESS,POSTALCODE,PHONENUMBER,PASSWORD) values(ID_CITY,NAME,SURNAME,ADRESS,POSTALCODE,PHONENUMBER,PASSWORD); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_CITY", customer.ID_CITY);
                    cmd.Parameters.AddWithValue("@NAME", customer.NAME);
                    cmd.Parameters.AddWithValue("@SURNAME", customer.SURNAME);
                    cmd.Parameters.AddWithValue("@ADRESS", customer.ADRESS);
                    cmd.Parameters.AddWithValue("@POSTALCODE", customer.POSTALCODE);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", customer.PHONENUMBER);
                    cmd.Parameters.AddWithValue("@PASSWORD", customer.PASSWORD);

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

        public Customer GetCustomer(string name, string surname)
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
            throw new NotImplementedException();
        }
    }
}
