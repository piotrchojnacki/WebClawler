using System;
using System.Collections.Generic;
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

            Console.ReadKey();
        }
    }
}
