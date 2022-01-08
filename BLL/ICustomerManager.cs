using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public interface ICustomerManager
    {
        public Customer loginCustomer(string username, string password);
        public Customer AddCustomer(Customer customer);
        public Customer GetCustomer(int idCustomer);
        public Customer UpdateCustomer(int id_customer, Customer newCustomer);
        public List<Customer> GetCustomers();



    }
}
