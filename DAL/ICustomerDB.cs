using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    interface ICustomerDB
    {
        public List<Customer> GetCustomers();

        public Customer GetCustomer(string name, string surname);

        public void addCustomer(Customer customer); 

    }
}
