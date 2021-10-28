using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    interface ICustomerDB
    { // test
        public List<Customer> GetCustomers();
         // test
        public Customer GetCustomer(string name, string surname);

        public Customer addCustomer(Customer customer); 

    }
}
