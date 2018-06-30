using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Crawler.Interfaces;
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

        public OpenWeatherMapCrawler(IOpenWeatherMapSettings openWeatherMapSettings,
            IOpenWeatherMapRestClient openWeatherMapRestClient)
        {
            _openWeatherMapCityID = openWeatherMapSettings.OpenWeatherMapCityID;
            _openWeatherMapAPIKey = openWeatherMapSettings.OpenWeatherMapAPIKey;
            _openWeatherMapTimeSpan = openWeatherMapSettings.OpenWeatherMapTimeSpan;
            _openWeatherMapRestClient = openWeatherMapRestClient;

            Work();
        }

        public void Work()
        {
            Console.WriteLine("{0} {1} {2}", _openWeatherMapCityID, _openWeatherMapAPIKey, _openWeatherMapTimeSpan.ToString());

            var obs = Observable.Interval(_openWeatherMapTimeSpan).Subscribe(_ => { _openWeatherMapRestClient.GetWeather(); });
        }
    }
}
