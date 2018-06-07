using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WebCrawler.Crawler;
using WebCrawler.Crawler.Interfaces;
using WebCrawler.Settings;
using WebCrawler.Settings.Interfaces;
using WebCrawler.Test;
using WebCrawler.Test.Interfaces;

namespace WebCrawler.Bootstrappers
{
    class Bootstrapper
    {
        private IContainer _container;

        public IContainer Start()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<TestCW>()
                .As<ITestCW>()
                .AutoActivate();

            builder
                .RegisterType<TestCP>()
                .As<ITestCW>()
                .AutoActivate();

            builder
                .RegisterType<TwitterCrawler>()
                .As<ITwitterCrawler>()
                .AutoActivate();

            builder
                .RegisterType<TwitterSettings>()
                .As<ITwitterSettings>();

            _container = builder.Build();

            return _container;
        }
    }
}
