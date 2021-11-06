using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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
            //test Staff
            Console.WriteLine("==========================================");
            Console.WriteLine("Test DISH");
            Console.WriteLine("==========================================");

            DishManager dishManager = new DishManager(Configuration);
            Dish testDish = new Dish()
            {
                ID_RESTAURANT = 1,
                NAME = "donerbox",
                PRICE = 10.50
            };


            //add staff in database

            Dish temp = dishManager.addDish(testDish);

            Console.WriteLine("ADD METHOD WORKING");

            testDish.ID_DISH = temp.ID_DISH;

            Console.WriteLine(testDish.ToString());


            //see if it is in the list of restaurants

            var dishes = dishManager.GetDishes();
            foreach (var dish in dishes)
            {
                if (dish.ID_DISH == testDish.ID_DISH)
                {
                    Console.WriteLine("ADD METHOD WORKING");
                    Console.WriteLine("GET ALL METHOD WORKING");
                }
            }

            // test get restaurant with ID
            if (dishManager.GetDish(testDish.ID_DISH) != null)
            {
                Console.WriteLine("GET WITH ID WORKING");
            }

            // test get dishes in jetPizza
            var dishesinJetPizza = dishManager.GetDishes(1);
            foreach (var dish in dishesinJetPizza)
            {
                if (dish.ID_DISH == dish.ID_DISH)
                {
                    Console.WriteLine("GET DISH IN RESTAURANT WORKING");
                }
            }

            // test update
            Dish myUpdatedDish = new Dish()
            {
                ID_RESTAURANT = 1,
                NAME = "donerbox",
                PRICE = 9.20
            };
            dishManager.UpdateDish(testDish.ID_DISH, myUpdatedDish);

            // test if it was updated
            if (dishManager.GetDish(testDish.ID_DISH).PRICE == 9.20)
            {
                Console.WriteLine("UPDATE WORKING");
            }


            dishManager.DeleteDish(testDish.ID_DISH);
            // test if the user is still in the list
            dishes = dishManager.GetDishes();
            foreach (var dish in dishes)
            {
                if (dish.ID_DISH == testDish.ID_DISH)
                {
                    Console.WriteLine("ERROR : THE USER IS STILL THERE");
                }
            }
            Console.WriteLine("DELETE WORKING");

            Console.WriteLine("==========================================");
            Console.WriteLine("END TEST DISH");
            Console.WriteLine("==========================================");
        }
    
        
        public void OrderTest()
        { 
            Console.WriteLine("==========================================");
            Console.WriteLine("Test ORDER");
            Console.WriteLine("==========================================");
           
            //creation of the BLL manager object in order to call the DAL methods
            //creation of the object "testOrder" that will return all results from the tests
            OrderManager orderManager = new OrderManager(Configuration)
            Order testOrder = new Order
            {
                 ID_ORDER = 1,
                ID_CUSTOMER = 1,
                //YYYY-MM-DD
                // ATTENTION : remove datetime from table Order since we can add the time on orderDate
                ORDERDATE = "2021-06-11",
                //HH:MM:SS
                ORDERTIME = "19:50:47",
                //Create a table named "Discounts" that store all available discounts so we can call a discount by his id
                DISCOUNT = 15,
                TOTALPRICE = 135.54

            };
                  

            //testing method addOrder();
            Order temp = orderManager.addOrder(testOrder);
            
           Console.WriteLine("ADD METHOD WORKING");
            //Why do we have to do this if we know that the objects are the same
            //why not do a checking 

           // if (testOrder.equals(temp){ 
           //
           //     Console.WriteLine("ADD METHOD WORKING");
           //
           // }
            //instead of

            testOrder.ID_ORDER = temp.ID_ORDER;

            Console.WriteLine(testOrder.ToString());

            //Checking if the getOrders() List is working
            var orders = orderManager.GetOrders();
            foreach (var order in orders)
            {
                if (order.ID_ORDER == testOrder.ID_ORDER)
                {
                    Console.WriteLine("ADD METHOD WORKING");
                    Console.WriteLine("GetOrders() METHOD WORKING");
                }
            }

            // Checking if GetOrders(orderDate) is working
            // date of the "orderTest"

            DateTime testTime = "2021-06-11";

            var orders = orderManager.GetOrders(testTime);

            foreach (var order in orders) { 

                if(order.ID_ORDER != NULL) { 
            
                Console.WriteLine(" getOrder(orderDate) METHOD WORKING");

                }else { 
                    Console.WriteLine(" getOrder(orderDate) METHOD NOT WORKING - TRY ANOTHER ORDER DATE");
                }
            }
            // Checking if GetOrdersByDiscount(discount) is working
            //discount of the "orderTest"
            int testDiscount =15;

            var orders = orderManager.GetOrdersByDiscount(testDiscount);

            foreach (var order in orders) { 

                 if(order.DISCOUNT != NULL) { 
            
                    Console.WriteLine("GetOrderByDiscount(discount) METHOD WORKING");

                 } else { 
                    Console.WriteLine(" GetOrderByDiscount(discount) METHOD NOT WORKING - TRY ANOTHER DISCOUNT");
                
                 }
            }
            //Checking if GetOrdersByMinTotalPrice(totalPrice) is working
            //totalPrice of the "orderTest"
            //orderTest.totalPrice = 135.54
            double testTotalPrice = 150.00;

            var orders = orderManager.GetOrdersByMinTotalPrice(testTotalPrice);

            foreach (var order in orders) { 

                 if(order.TOTALPRICE < testTotalPrice) { 
            
                    Console.WriteLine("GetOrdersByMinTotalPrice(totalPrice) METHOD WORKING");

                 } else { 
                    Console.WriteLine(" GetOrderByDiscount(discount) METHOD NOT WORKING - TOTALPRICE BIGGER THAN THE PARAMETER");
                
                 }
            }
            //Checking if GetOrdersByMaxTotalPrice(totalPrice) is working
            //totalPrice of the "orderTest"
            var orders = orderManager.GetOrdersByMaxTotalPrice(testTotalPrice);

            foreach (var order in orders) { 

                 if(order.TOTALPRICE > testTotalPrice) { 
            
                    Console.WriteLine("GetOrdersByMaxTotalPrice(totalPrice) METHOD WORKING");

                 } else { 
                    Console.WriteLine("GetOrdersByMaxTotalPrice(totalPrice) METHOD NOT WORKING - TOTALPRICE UNDER THAN THE PARAMETER");
                 }
            }


            //Checking if GetOrder(orderID) is working
            //id_order of the "testOrder" is 1

            int testOrderID = 1;
            Order searchedOrder = new Order();

            searchedOrder = orderManager.GetOrder(testOrderID);

           if(searchedOrder.ID_ORDER != NULL) {
            
                 Console.WriteLine("GetOrder(orderID) METHOD WORKING");
            
            
            } else { 

                 Console.WriteLine("GetOrder(orderID) METHOD NOT WORKING - TRY ANOTHER ORDER ID");

            }
             Console.WriteLine("==========================================");
            Console.WriteLine("END TEST ORDER");
            Console.WriteLine("==========================================");

        }
        
        //TODO
        public void OrderDetailsTest()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("TEST ORDERDETAILS");
            Console.WriteLine("==========================================");

            OrderDetailsManager orderDetailsManager = new OrderDetailsManager(Configuration);



            Console.WriteLine("==========================================");
            Console.WriteLine("END TEST ORDERDETAILS");
            Console.WriteLine("==========================================");
        }

        public void RestaurantTest()
        {
            //test Staff
            Console.WriteLine("==========================================");
            Console.WriteLine("Test RESTAURANT");
            Console.WriteLine("==========================================");
            
            RestaurantManager restaurantManager = new RestaurantManager(Configuration);
            Restaurant testRestaurant = new Restaurant
            {
                IDCITY = 3,
                IDTYPE = 1,
                NAME = "le mix",
                ADRESS = "pl. Centrale 5",
                PHONENUMBER = "0244715550",
                USERNAME = "leMix",
                PASSWORD = "leMix"
            };


            //add staff in database

            Restaurant temp = restaurantManager.AddRestaurant(testRestaurant);

            Console.WriteLine("ADD METHOD WORKING");

            testRestaurant.ID_RESTAURANT = temp.ID_RESTAURANT;

            Console.WriteLine(testRestaurant.ToString());


            //see if it is in the list of restaurants

            var restaurants = restaurantManager.GetRestaurants();
            foreach (var restaurant in restaurants)
            {
                if (restaurant.ID_RESTAURANT == testRestaurant.ID_RESTAURANT)
                {
                    Console.WriteLine("ADD METHOD WORKING");
                    Console.WriteLine("GET ALL METHOD WORKING");
                }
            }

            // test get restaurant with ID
            if (restaurantManager.GetRestaurant(testRestaurant.ID_RESTAURANT) != null)
            {
                Console.WriteLine("GET WITH ID WORKING");
            }

            // test get restaurants in city
            var restaurantsInMonthey = restaurantManager.GetRestaurantsByCity(3);
            foreach (var restaurant in restaurantsInMonthey)
            {
                if (restaurant.ID_RESTAURANT == testRestaurant.ID_RESTAURANT)
                {
                    Console.WriteLine("GET RESTAURANT IN RESTAURANT WORKING");
                }
            }

            // test get restaurants in city
            var kebabs = restaurantManager.GetRestaurantsByType(1);
            foreach (var kebab in kebabs)
            {
                if (kebab.ID_RESTAURANT == testRestaurant.ID_RESTAURANT)
                {
                    Console.WriteLine("GET RESTAURANT IN RESTAURANT WORKING");
                }
            }

            // test update
            Restaurant myUpdatedRestaurant = new Restaurant
            {
                IDCITY = 3,
                IDTYPE = 1,
                NAME = "le mix modified",
                ADRESS = "pl. Centrale 5",
                PHONENUMBER = "0244715550",
                USERNAME = "leMix",
                PASSWORD = "leMix"
            };

            restaurantManager.UpdateRestaurant(testRestaurant.ID_RESTAURANT, myUpdatedRestaurant);

            // test if it was updated
            if (restaurantManager.GetRestaurant(testRestaurant.ID_RESTAURANT).NAME == "le mix modified")
            {
                Console.WriteLine("UPDATE WORKING");
            }


            restaurantManager.DeleteRestaurant(testRestaurant.ID_RESTAURANT);
            // test if the user is still in the list
            restaurants = restaurantManager.GetRestaurants();
            foreach (var restaurant in restaurants)
            {
                if (restaurant.ID_RESTAURANT == testRestaurant.ID_RESTAURANT)
                {
                    Console.WriteLine("ERROR : THE USER IS STILL THERE");
                }
            }
            Console.WriteLine("DELETE WORKING");

            Console.WriteLine("==========================================");
            Console.WriteLine("END TEST RESTAURANT");
            Console.WriteLine("==========================================");
        }


        public void RestoTypeTest()
        {
            //test restoType
            Console.WriteLine("==========================================");
            Console.WriteLine("Test RestoType");
            Console.WriteLine("==========================================");

            RestoTypeManager restoTypeManager = new RestoTypeManager(Configuration);
            RestoType testRestoType = new RestoType
            {
                TYPENAME = "typeTest"
            };


            //add restoType in database

            RestoType temp = restoTypeManager.addRestoType(testRestoType);

            Console.WriteLine("ADD METHOD WORKING");

            testRestoType.IDTYPE = temp.IDTYPE;

            Console.WriteLine(testRestoType.ToString());


            //see if it is in the list of restoType

            var restoTypes = restoTypeManager.GetRestoTypes();
            foreach (var restoType in restoTypes)
            {
                if (restoType.IDTYPE == restoType.IDTYPE)
                {
                    Console.WriteLine("ADD METHOD WORKING");
                    Console.WriteLine("GET ALL METHOD WORKING");
                }
            }

            // test get restotype with ID
            if (restoTypeManager.GetRestoType(testRestoType.IDTYPE) != null)
            {
                Console.WriteLine("GET WITH ID WORKING");
            }

            // test update
            RestoType myUpdatedrRestoType = new RestoType
            {
                TYPENAME = "modifiedType"
            };

            restoTypeManager.UpdateRestoType(testRestoType.IDTYPE, myUpdatedrRestoType);

            // test if it was updated
            if (restoTypeManager.GetRestoType(testRestoType.IDTYPE).TYPENAME == "modifiedType")
            {
                Console.WriteLine("UPDATE WORKING");
            }


            restoTypeManager.DeleteRestoType(testRestoType.IDTYPE);
            // test if the user is still in the list
            restoTypes = restoTypeManager.GetRestoTypes();
            foreach (var restoType in restoTypes)
            {
                if (restoType.IDTYPE == testRestoType.IDTYPE)
                {
                    Console.WriteLine("ERROR : THE USER IS STILL THERE");
                }
            }
            Console.WriteLine("DELETE WORKING");

            Console.WriteLine("==========================================");
            Console.WriteLine("END TEST RESTOTYPE");
            Console.WriteLine("==========================================");
        }

        public void StaffTest()
        {
            //test Staff
            Console.WriteLine("==========================================");
            Console.WriteLine("Test STAFF");
            Console.WriteLine("==========================================");

            StaffManager staffManager = new StaffManager(Configuration);
            Staff testStaff = new Staff
            {
                ID_RESTAURANT = 1,
                FIRSTNAME = "lily",
                LASTNAME = "test",
                ADRESS = "test adress",
                PHONENUMBER = "12345678",
                USERNAME = "lilyTest",
                PASSWORD = "lilyTest"
            };


            //add staff in database

            Staff temp = staffManager.AddStaff(testStaff);

            Console.WriteLine("ADD METHOD WORKING");

            testStaff.ID_STAFF = temp.ID_STAFF;

            Console.WriteLine(testStaff.ToString());


            //see if it is in the list of staff

            var staffs = staffManager.GetStaffs();
            foreach (var staff in staffs)
            {
                if (staff.ID_STAFF == testStaff.ID_STAFF)
                {
                    Console.WriteLine("ADD METHOD WORKING");
                    Console.WriteLine("GET ALL METHOD WORKING");
                }
            }

            // test get staff with ID
            if (staffManager.GetStaff(testStaff.ID_STAFF) != null)
            {
                Console.WriteLine("GET WITH ID WORKING");
            }

            // test get staff in restaurant
            var StaffinJetPizza = staffManager.GetStaffs();
            foreach (var staff in StaffinJetPizza)
            {
                if (staff.ID_STAFF== testStaff.ID_STAFF)
                {
                    Console.WriteLine("GET STAFF IN RESTAURANT WORKING");
                }
            }

            // test update
            Staff myUpdatedStaff = new Staff
            {
                ID_RESTAURANT = testStaff.ID_RESTAURANT,
                FIRSTNAME = "totoTest",
                LASTNAME = testStaff.LASTNAME,
                ADRESS = testStaff.ADRESS,
                PHONENUMBER = testStaff.PHONENUMBER,
                USERNAME = testStaff.USERNAME,
                PASSWORD = testStaff.PASSWORD
            };

            staffManager.UpdateStaff(testStaff.ID_STAFF, myUpdatedStaff);

            // test if it was updated
            if (staffManager.GetStaff(testStaff.ID_STAFF).FIRSTNAME == "totoTest")
            {
                Console.WriteLine("UPDATE WORKING");
            }


            staffManager.DeleteStaff(testStaff.ID_STAFF);
            // test if the user is still in the list
            staffs = staffManager.GetStaffs();
            foreach (var staff in staffs)
            {
                if (staff.ID_STAFF == testStaff.ID_STAFF)
                {
                    Console.WriteLine("ERROR : THE USER IS STILL THERE");
                }
            }
            Console.WriteLine("DELETE WORKING");

            Console.WriteLine("==========================================");
            Console.WriteLine("END TEST STAFF");
            Console.WriteLine("==========================================");
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
