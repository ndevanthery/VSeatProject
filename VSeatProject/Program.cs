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


            Console.WriteLine("start Adding Data in City");
            
            


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
