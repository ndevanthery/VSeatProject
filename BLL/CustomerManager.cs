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
    public class CustomerManager : ICustomerManager
    {
        private ICustomerDB customerDB { get; }

        public CustomerManager(IConfiguration conf)
        {
            customerDB = new CustomerDB(conf);
        }

        //login method
        public Customer loginCustomer(string username,string password) {
            
            Customer loggedCustomer = new Customer();

            //get all customers
            var customers = GetCustomers();

            foreach (var customer in customers)
            {
                //test if one of them's username and password combination is working
                if (customer.USERNAME == username && customer.PASSWORD == password )
                {
                    loggedCustomer = customer;
                    
                    return loggedCustomer;
                }
                
            }
            //if no one was found, send null back

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


        //get Lists methods

        public List<Customer> GetCustomers()
        {
            return customerDB.GetCustomers();
        }








    }
}
