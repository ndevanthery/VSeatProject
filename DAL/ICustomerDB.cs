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
        public List<Customer> GetCustomers();
   
        public Customer GetCustomerByName(string name, string surname);

        public Customer GetCustomerByEmail(string email);

        public List<Customer> GetCustomers(int id_city);

        public Customer addCustomer(Customer customer);
        // COMMENT UPDATE L ADDRESSE TOUT EN UPDATANT L ID_CITY ??
        public Customer updateCustomerAdress(int id_customer,string adress);

        public Customer updateCustomerPhoneNumber(int id_customer, string phoneNumber);

        public Customer updateCustomerPassword(int id_customer, string password);

        


    }
}
