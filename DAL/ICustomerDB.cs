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

        public Customer AddCustomer(Customer customer);


        //get Customers

        public Customer GetCustomer(int idCustomer);



        //update customer
        public Customer UpdateCustomer(int id_customer , Customer newCustomer);



        //delete customer

        public Customer DeleteCustomer(int id_customer);



        //get Lists

        public List<Customer> GetCustomers();

        public List<Customer> GetCustomers(int id_city);






    }
}
