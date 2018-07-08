using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Bootstrappers;
using WebCrawler.Contexts;
using WebCrawler.Models;
using WebCrawler.Repositories;

namespace WebCrawler
{
    class WebClawler
    {
        static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Start();

            Console.WriteLine("Hello World!");

            string conn = ConfigurationManager.AppSettings["ConnectionString"];
            Console.WriteLine(conn);

            NpgsqlConnection connection = new NpgsqlConnection(conn);

            connection.Open();
            Console.WriteLine("*");
            connection.Close();

            var weatherContext = new WeatherContext(conn);

            var weatherSet = new WeatherRepository(weatherContext);

            var weather = new Weather(300, 1000, 100, 0, 400, 50, 20, 10, 30, 1111111);

            weatherSet.Add(weather);

            Console.ReadKey();
        }
    }
}
