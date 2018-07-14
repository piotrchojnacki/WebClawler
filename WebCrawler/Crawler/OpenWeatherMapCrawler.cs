using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Contexts;
using WebCrawler.Contexts.Interfaces;
using WebCrawler.Crawler.Interfaces;
using WebCrawler.Mapping;
using WebCrawler.Mapping.Interfaces;
using WebCrawler.Models;
using WebCrawler.Models.Interfaces;
using WebCrawler.Repositories;
using WebCrawler.Services.Interfaces;
using WebCrawler.Settings.Interfaces;

namespace WebCrawler.Crawler
{
    class OpenWeatherMapCrawler : IOpenWeatherMapCrawler
    {
        private readonly string _openWeatherMapCityID;
        private readonly string _openWeatherMapAPIKey;
        private readonly TimeSpan _openWeatherMapTimeSpan;
        private readonly IOpenWeatherMapRestClient _openWeatherMapRestClient;
        private readonly IWeatherMapper _weatherMapper;
        private readonly WeatherContext _weatherContext;
        public IObservable<Weather> WeatherSource { get; private set; }


        public OpenWeatherMapCrawler(
            IOpenWeatherMapSettings openWeatherMapSettings,
            IOpenWeatherMapRestClient openWeatherMapRestClient,
            IWeatherMapper weatherMapper,
            WeatherContext weatherContext)
        {
            _openWeatherMapCityID = openWeatherMapSettings.OpenWeatherMapCityID;
            _openWeatherMapAPIKey = openWeatherMapSettings.OpenWeatherMapAPIKey;
            _openWeatherMapTimeSpan = openWeatherMapSettings.OpenWeatherMapTimeSpan;
            _openWeatherMapRestClient = openWeatherMapRestClient;
            _weatherMapper = weatherMapper;
            _weatherContext = weatherContext;


            WeatherSource = Observable.Interval(_openWeatherMapTimeSpan)
                .Select(x => Work());
      
        }


        public void Work(bool sth)
        {
            Console.WriteLine("{0} {1} {2}", _openWeatherMapCityID, _openWeatherMapAPIKey, _openWeatherMapTimeSpan.ToString());

            string weatherString = _openWeatherMapRestClient.GetWeather();

            Weather weather = _weatherMapper.MapToWeather(weatherString);

            //string conn = ConfigurationManager.AppSettings["ConnectionString"];
            //var weatherContext = new WeatherContext(conn);
            var weatherSet = new WeatherRepository(_weatherContext);

            weatherSet.Add(weather);
            _weatherContext.SaveChanges();
        }

        public Weather Work()
        {
          var weatherString =  _openWeatherMapRestClient.GetWeather();
          return _weatherMapper.MapToWeather(weatherString);
        }
    }
}
