using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace VSeat
{

    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath("P://hes//semestre 3//VSeat_Project//VSeatProject//VSeatProject/")
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        static void Main(string[] args)
        {
            


        }

        public void CityTest()
        {

        }


        public void CustomerTest()
        {
            //test Customer
            Console.WriteLine("Test Customer BLL");
            CustomerManager customerManager = new CustomerManager(Configuration);
            Customer testCustomer = new Customer();
            testCustomer.IDCITY = 3;
            testCustomer.FIRSTNAME = "lily";
            testCustomer.LASTNAME = "test";
            testCustomer.ADRESS = "test adress";
            testCustomer.PHONENUMBER = "12345678";
            testCustomer.USERNAME = "lilyTest";
            testCustomer.PASSWORD = "lilyTest";
            testCustomer.EMAIL = "lilytest@gmail.com";

            Console.WriteLine("test ADD user");

            //add customer in database

            Customer temp = customerManager.addCustomer(testCustomer);

            Console.WriteLine("user added :");

            testCustomer.ID_CUSTOMER = temp.ID_CUSTOMER;

            Console.WriteLine(testCustomer.ToString());


            //see if it is in the list of customers

            var customers = customerManager.GetCustomers();
            foreach (var customer in customers)
            {
                if (customer.ID_CUSTOMER == testCustomer.ID_CUSTOMER)
                {
                    Console.WriteLine("test customer in list : it's working");
                }
            }

            // test get customer with ID
            if (customerManager.GetCustomer(testCustomer.ID_CUSTOMER) != null)
            {
                Console.WriteLine("Get Method with ID is working");
            }

            // test get customers in city
            var customersInMonthey = customerManager.GetCustomers();
            foreach (var customer in customersInMonthey)
            {
                if (customer.ID_CUSTOMER == testCustomer.ID_CUSTOMER)
                {
                    Console.WriteLine("get customers in City working");
                }
            }

            // test update
            Customer myUpdatedCustomer = new Customer();
            myUpdatedCustomer.IDCITY = testCustomer.IDCITY;
            myUpdatedCustomer.FIRSTNAME = "totoTest";
            myUpdatedCustomer.LASTNAME = testCustomer.LASTNAME;
            myUpdatedCustomer.ADRESS = testCustomer.ADRESS;
            myUpdatedCustomer.PHONENUMBER = testCustomer.PHONENUMBER;
            myUpdatedCustomer.USERNAME = testCustomer.USERNAME;
            myUpdatedCustomer.PASSWORD = testCustomer.PASSWORD;
            myUpdatedCustomer.EMAIL = testCustomer.EMAIL;

            customerManager.UpdateCustomer(testCustomer.ID_CUSTOMER, myUpdatedCustomer);

            // test if it was updated
            if (customerManager.GetCustomer(testCustomer.ID_CUSTOMER).FIRSTNAME == "totoTest")
            {
                Console.WriteLine("update Method is working");
            }


            customerManager.DeleteCustomer(testCustomer.ID_CUSTOMER);
            // test if the user is still in the list
            customers = customerManager.GetCustomers();
            foreach (var customer in customers)
            {
                if (customer.ID_CUSTOMER == testCustomer.ID_CUSTOMER)
                {
                    Console.WriteLine("ERROR : THE USER IS STILL THERE");
                }
            }
            Console.WriteLine("DELETE working");
        }


        public void DishTest()
        {

        }

        public void OrderTest()
        {

        }


        public void OrderDetailsTest()
        {

        }

        public void RestaurantTest()
        {

        }


        public void RestoTypeTest()
        {

        }

        public void StaffTest()
        {

        }

        //use only once to prevent having multiple times the same town
        public static void AddCitiesTest()
        {
            CityManager cityManager = new CityManager(Configuration);

            City city = new City();


            city.CITYNAME = "Sion";
            city.NPA = 1950;
            cityManager.AddCity(city);
            Console.WriteLine(city.ToString());

            city.CITYNAME = "Sierre";
            city.NPA = 3960;
            cityManager.AddCity(city);
            Console.WriteLine(city.ToString());


            city.CITYNAME = "Martigny";
            city.NPA = 1920;
            cityManager.AddCity(city);
            Console.WriteLine(city.ToString());


            city.CITYNAME = "St-Maurice";
            city.NPA = 1890;
            cityManager.AddCity(city);
            Console.WriteLine(city.ToString());


            city.CITYNAME = "Conthey";
            city.NPA = 1964;
            cityManager.AddCity(city);
            Console.WriteLine(city.ToString());




        }


    }
}
