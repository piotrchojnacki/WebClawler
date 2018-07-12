﻿using Npgsql;
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

            Console.ReadKey();
        }
    }
}
