using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{

    public interface ICustomerDB
    {

        //add Customer

        public Customer addCustomer(Customer customer);


        //get Lists

        public List<Customer> GetCustomers();

        public List<Customer> GetCustomers(int id_city);



        //get Customers

        public Customer GetCustomer(int idCustomer);



        //update customer
        public Customer updateCustomer(int id_customer , Customer newCustomer);



        //delete customer

        public Customer deleteCustomer(int id_customer);


    }
}
