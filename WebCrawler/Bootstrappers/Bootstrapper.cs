using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WebCrawler.Connectors;
using WebCrawler.Connectors.Interfaces;
using WebCrawler.Contexts;
using WebCrawler.Contexts.Interfaces;
using WebCrawler.Crawler;
using WebCrawler.Crawler.Interfaces;
using WebCrawler.Mapping;
using WebCrawler.Mapping.Interfaces;
using WebCrawler.Repositories;
using WebCrawler.Repositories.Interfaces;
using WebCrawler.Savers.Interfaces;
using WebCrawler.Services;
using WebCrawler.Services.Interfaces;
using WebCrawler.Settings;
using WebCrawler.Settings.Interfaces;
using WebCrawlers.Saver;

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
                .RegisterType<Connector>()
                .As<IConnector>()
                .AutoActivate();

            builder
                .RegisterType<Saver>()
                .As<ISaver>();

            builder
                .RegisterType<WeatherRepository>()
                .As<IWeatherRepository>();

            builder
                .Register<WeatherContext>(x => new WeatherContext(x.Resolve<IOpenWeatherMapSettings>().ConnectionString))
                .AsSelf();

            _container = builder.Build();            

            return _container;
        }
    }
}
