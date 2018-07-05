using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Bootstrappers;

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

            Console.ReadKey();
        }
    }
}
