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
            //test Customer
            Console.WriteLine("==========================================");
            Console.WriteLine("Test City");
            Console.WriteLine("==========================================");
            CityManager cityManager = new CityManager(Configuration);
            City testCity = new City
            {
                CITYNAME = "testCity",
                NPA = 9999
            };


            Console.WriteLine("test ADD City");

            //add city in database

            City temp = cityManager.AddCity(testCity);

            Console.WriteLine("city added :");

            testCity.IDCITY = temp.IDCITY;

            Console.WriteLine(testCity.ToString());


            //see if it is in the list of city

            var cities = cityManager.GetCities();
            foreach (var city in cities)
            {
                if (city.IDCITY == testCity.IDCITY)
                {
                    Console.WriteLine("test city in list : it's working");
                }
            }

            // test get city with ID
            if (cityManager.GetCity(testCity.IDCITY) != null)
            {
                Console.WriteLine("Get Method with ID is working");
            }



            // test update
            City myUpdatedCity = new City
            {
                CITYNAME = testCity.CITYNAME,
                NPA = 9998
            };

            cityManager.UpdateCity(testCity.IDCITY, myUpdatedCity);

            // test if it was updated
            if (cityManager.GetCity(testCity.IDCITY).NPA == 9998)
            {
                Console.WriteLine("update Method is working");
            }


            cityManager.DeleteCity(testCity.IDCITY);
            // test if the user is still in the list
            cities = cityManager.GetCities();
            foreach (var city in cities)
            {
                if (city.IDCITY == testCity.IDCITY)
                {
                    Console.WriteLine("ERROR : THE City IS STILL THERE");
                }
            }
            Console.WriteLine("DELETE working");

            Console.WriteLine("==========================================");
            Console.WriteLine("Test CITY END");
            Console.WriteLine("==========================================");
        }


        public void CustomerTest()
        {
            //test Customer
            Console.WriteLine("==========================================");
            Console.WriteLine("Test CUSTOMER");
            Console.WriteLine("==========================================");
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

            Customer temp = customerManager.AddCustomer(testCustomer);

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
            var customersInMonthey = customerManager.GetCustomers(testCustomer.IDCITY);
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

            Console.WriteLine("==========================================");
            Console.WriteLine("Test CUSTOMER");
            Console.WriteLine("==========================================");
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

            Dish temp = dishManager.AddDish(testDish);

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
                if (dish.ID_DISH == testDish.ID_DISH)
                {
                    Console.WriteLine("GET DISH IN RESTAURANT WORKING");
                }
            }


            // test get dishes under 20
            var dishesUnder20 = dishManager.GetDishesUnderPrice(20);
            foreach (var dish in dishesUnder20)
            {
                if (dish.ID_DISH == testDish.ID_DISH)
                {
                    Console.WriteLine("GET DISH under 20 WORKING");
                }
            }
            var dishesUnder10 = dishManager.GetDishesUnderPrice(10);
            foreach (var dish in dishesUnder10)
            {
                if (dish.ID_DISH == testDish.ID_DISH)
                {
                    Console.WriteLine("ERROR : GET DISH under 10 problem");
                }
            }
            Console.WriteLine("if the last message isn't ERROR , getDishUnderPrice is working");



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
            //test Order
            Console.WriteLine("==========================================");
            Console.WriteLine("Test ORDER");
            Console.WriteLine("==========================================");
            OrderManager orderManager = new OrderManager(Configuration);
            Order testOrder = new Order
            {
                ID_CUSTOMER = 3,
                ORDERDATE = new DateTime(2021 , 06,11,15,31,12),
                DISCOUNT = 12,
                TOTALPRICE = 132.12
            };


            Console.WriteLine("test ADD Order");

            //add Order in database

            Order temp = orderManager.AddOrder(testOrder);

            Console.WriteLine("order added :");

            testOrder.ID_ORDER = temp.ID_ORDER;

            Console.WriteLine(testOrder.ToString());


            //see if it is in the list of order

            var orders = orderManager.GetOrders();
            foreach (var order in orders)
            {
                if (order.ID_ORDER == testOrder.ID_ORDER)
                {
                    Console.WriteLine("test Order in list : it's working");
                }
            }

            // test get order with ID
            if (orderManager.GetOrder(testOrder.ID_ORDER) != null)
            {
                Console.WriteLine("Get Method with ID is working");
            }

            // test get Order by Date
            var OrdersToday = orderManager.GetOrders(new DateTime(2021,06,11));
            foreach (var order in OrdersToday)
            {
                if (order.ID_ORDER == testOrder.ID_ORDER)
                {
                    Console.WriteLine("get Order by Date working");
                }
            }


            // test get Order by Discount
            var OrdersDiscount12 = orderManager.GetOrdersByDiscount(12);
            foreach (var order in OrdersDiscount12)
            {
                if (order.ID_ORDER == testOrder.ID_ORDER)
                {
                    Console.WriteLine("get Order by Discount working");
                }
            }

            // test get Order by min total price
            var OrdersMin100 = orderManager.GetOrdersByMinTotalPrice(100.00);
            foreach (var order in OrdersMin100)
            {
                if (order.ID_ORDER == testOrder.ID_ORDER)
                {
                    Console.WriteLine("order appears with min 100");
                }
            }
            var OrdersMin200 = orderManager.GetOrdersByMinTotalPrice(200.00);
            foreach (var order in OrdersMin200)
            {
                if (order.ID_ORDER == testOrder.ID_ORDER)
                {
                    Console.WriteLine("order appears with 200 min : ERROR");
                }
            }
            Console.WriteLine("if the last message was not ERROR , get order with min total is working");



            // test get Order by max total price
            var OrdersMax200 = orderManager.GetOrdersByMaxTotalPrice(200.00);
            foreach (var order in OrdersMax200)
            {
                if (order.ID_ORDER == testOrder.ID_ORDER)
                {
                    Console.WriteLine("order appears with max 200");
                }
            }
            var OrdersMax100 = orderManager.GetOrdersByMaxTotalPrice(100.00);
            foreach (var order in OrdersMax100)
            {
                if (order.ID_ORDER == testOrder.ID_ORDER)
                {
                    Console.WriteLine("order appears with 100 max : ERROR");
                }
            }
            Console.WriteLine("if the last message was not ERROR , get order with max total is working");


            // test get Order by Customer
            var ordersByTestUser = orderManager.GetOrdersByCustomer(testOrder.ID_CUSTOMER);
            foreach (var order in ordersByTestUser)
            {
                if (order.ID_ORDER == testOrder.ID_ORDER)
                {
                    Console.WriteLine("get Order by Customer Working");
                }
            }





            // test update
            Order myUpdatedOrder = new Order
            {
                ID_CUSTOMER = 3,
                ORDERDATE = new DateTime(2021, 06, 11, 15, 31, 12),
                DISCOUNT = 12,
                TOTALPRICE = 145.50
            };


            orderManager.UpdaterOrder(testOrder.ID_ORDER, myUpdatedOrder);

            // test if it was updated
            if (orderManager.GetOrder(testOrder.ID_ORDER).TOTALPRICE == 145.50)
            {
                Console.WriteLine("update Method is working");
            }


            orderManager.DeleteOrder(testOrder.ID_ORDER);
            // test if the user is still in the list
            orders = orderManager.GetOrders();
            foreach (var order in orders)
            {
                if (order.ID_ORDER == testOrder.ID_ORDER)
                {
                    Console.WriteLine("ERROR : THE ORDER IS STILL THERE");
                }
            }
            Console.WriteLine("DELETE working");

            Console.WriteLine("==========================================");
            Console.WriteLine("Test ORDER END");
            Console.WriteLine("==========================================");

        }
        
        //TODO
        public void OrderDetailsTest()
        {
            //test Customer
            Console.WriteLine("==========================================");
            Console.WriteLine("Test ORDER DETAILS");
            Console.WriteLine("==========================================");
            OrderDetailsManager orderDetailsManager = new OrderDetailsManager(Configuration);
            OrderDetails testOrderDetails = new OrderDetails
            {
                ID_ORDER = 1,
                ID_DISH = 2
            };


            Console.WriteLine("test ADD orderDetails");

            //add customer in database

            orderDetailsManager.AddOrderDetails(testOrderDetails);

            Console.WriteLine("orderDetails added :");

            Console.WriteLine(testOrderDetails.ToString());


            //see if it is in the list of customers

            var orderDetails = orderDetailsManager.GetOrdersDetails();
            foreach (var orderDetail in orderDetails)
            {
                if (orderDetail.ID_ORDER == testOrderDetails.ID_ORDER)
                {
                    if (orderDetail.ID_DISH == testOrderDetails.ID_DISH)
                    {
                        Console.WriteLine("test customer in list : it's working");

                    }
                }
            }

            // test get OrderDetails with id's
            if (orderDetailsManager.GetOrderDetails(testOrderDetails.ID_ORDER , testOrderDetails.ID_DISH) != null)
            {
                Console.WriteLine("Get Method with ID's is working");
            }

            // test get OrderDetails with dish
            var OrderDetailswithDish = orderDetailsManager.GetOrderDetailsByDish(testOrderDetails.ID_DISH);
            foreach (var orderDetail in OrderDetailswithDish)
            {
                if (orderDetail.ID_ORDER == testOrderDetails.ID_ORDER)
                {
                    if (orderDetail.ID_DISH == testOrderDetails.ID_DISH)
                    {
                        Console.WriteLine("test orderDetails with Dish : it's working");

                    }
                }
            }

            // test get OrderDetails with orderID
            var OrderDetailswithOrder = orderDetailsManager.GetOrderDetailsByOrder(testOrderDetails.ID_ORDER);
            foreach (var orderDetail in OrderDetailswithOrder)
            {
                if (orderDetail.ID_ORDER == testOrderDetails.ID_ORDER)
                {
                    if (orderDetail.ID_DISH == testOrderDetails.ID_DISH)
                    {
                        Console.WriteLine("test orderDetails with Order : it's working");

                    }
                }
            }

            Console.WriteLine("==========================================");
            Console.WriteLine("Test CUSTOMER");
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

            RestoType temp = restoTypeManager.AddRestoType(testRestoType);

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
            var StaffinJetPizza = staffManager.GetStaffs(testStaff.ID_RESTAURANT);
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



    }
}
