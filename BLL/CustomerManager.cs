using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerManager
    {
        private ICustomerDB customerDB { get; }

        public CustomerManager(IConfiguration conf)
        {
            customerDB = new CustomerDB(conf);
        }
        //login method
        public Customer loginCustomer(string username,string password) {
            
            Customer loggedCustomer = new Customer();

            var customers = GetCustomers();

            foreach (var customer in customers)
            {
                if (customer.USERNAME == username && customer.PASSWORD == password )
                {
                    Console.WriteLine("customer found and logged");
                    loggedCustomer.IDCITY = customer.IDCITY;
                    loggedCustomer.ID_CUSTOMER = customer.ID_CUSTOMER;
                    loggedCustomer.FIRSTNAME = customer.FIRSTNAME;
                    loggedCustomer.LASTNAME = customer.LASTNAME;
                    loggedCustomer.ADRESS = customer.ADRESS;
                    loggedCustomer.PHONENUMBER = customer.PHONENUMBER;
                    loggedCustomer.USERNAME = customer.USERNAME;
                    loggedCustomer.EMAIL = customer.EMAIL;
                    
                    return loggedCustomer;
                }
                
            }
            

            Console.WriteLine("customer username or password incorrect");
            return null;
                 
        }

        //add method

        public Customer AddCustomer(Customer customer)
        {
            return customerDB.AddCustomer(customer);
        }

        //get one method
        public Customer GetCustomer(int idCustomer)
        {
            return customerDB.GetCustomer(idCustomer);
        }


        //update method
        public Customer UpdateCustomer(int id_customer , Customer newCustomer)
        {
            return customerDB.UpdateCustomer(id_customer, newCustomer);
        }


        //delete method
        public Customer DeleteCustomer(int id_customer)
        {
            return customerDB.DeleteCustomer(id_customer);
        }

        //get Lists methods

        public List<Customer> GetCustomers()
        {
            return customerDB.GetCustomers();
        }

        public List<Customer> GetCustomers(int id_city)
        {
            return customerDB.GetCustomers(id_city);
        }







    }
}
