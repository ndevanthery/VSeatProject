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

        public Customer GetCustomerByName(string name, string surname);

        public Customer GetCustomerByEmail(string email);

        public Customer GetCustomer(int idCustomer);

       

    }
}
