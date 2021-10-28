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
    class CustomerManager
    {
        private ICustomerDB customerDB { get; }

        public CustomerManager(IConfiguration conf)
        {
            customerDB = new CustomerDB(conf);
        }

        public List<Customer> GetCustomers()
        {
            return customerDB.GetCustomers();
        }

        public Customer GetCustomer(string name, string surname)
        {
            return customerDB.GetCustomer(name, surname);
        }

        public Customer addCustomer(Customer customer)
        {
            return customerDB.addCustomer(customer);
        }


    }
}
