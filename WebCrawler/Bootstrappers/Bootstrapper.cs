using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WebCrawler.Contexts;
using WebCrawler.Contexts.Interfaces;
using WebCrawler.Crawler;
using WebCrawler.Crawler.Interfaces;
using WebCrawler.Mapping;
using WebCrawler.Mapping.Interfaces;
using WebCrawler.Services;
using WebCrawler.Services.Interfaces;
using WebCrawler.Settings;
using WebCrawler.Settings.Interfaces;

namespace WebCrawler.Bootstrappers
{
    class Bootstrapper
    {
        private IContainer _container;

        public IContainer Start()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<OpenWeatherMapCrawler>()
                .As<IOpenWeatherMapCrawler>()
                .AutoActivate();

            builder
                .RegisterType<OpenWeatherMapSettings>()
                .As<IOpenWeatherMapSettings>();

            builder
                .RegisterType<OpenWeatherMapRestClient>()
                .As<IOpenWeatherMapRestClient>()
                .SingleInstance();

            builder
                .RegisterType<WeatherMapper>()
                .As<IWeatherMapper>();

            builder
                .Register<WeatherContext>(x => new WeatherContext(x.Resolve<IOpenWeatherMapSettings>().ConnectionString))
                .AsSelf();

            _container = builder.Build();

            return _container;
        }
    }
}
