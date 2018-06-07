using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Test.Interfaces;

namespace WebCrawler.Test
{
    public class TestCP : ITestCW
    {
        public TestCP()
        {
            WriteOnConsole();
        }
        public void WriteOnConsole()
        {
            System.Console.WriteLine("Hello World! CP");

            System.Console.ReadKey();
        }
    }
}
