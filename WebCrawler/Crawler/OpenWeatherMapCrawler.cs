using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Crawler.Interfaces;
using WebCrawler.Settings.Interfaces;

namespace WebCrawler.Crawler
{
    class OpenWeatherMapCrawler : IOpenWeatherMapCrawler
    {
        private readonly string _openWeatherMapCityID;
        private readonly string _openWeatherMapAPIKey;
        private readonly TimeSpan _openWeatherMapTimeSpan;

        public OpenWeatherMapCrawler(IOpenWeatherMapSettings openWeatherMapSettings)
        {
            _openWeatherMapCityID = openWeatherMapSettings.OpenWeatherMapCityID;
            _openWeatherMapAPIKey = openWeatherMapSettings.OpenWeatherMapAPIKey;
            _openWeatherMapTimeSpan = openWeatherMapSettings.OpenWeatherMapTimeSpan;

            Work();
        }

        public void Work()
        {
            Console.WriteLine("{0} {1} {2}", _openWeatherMapCityID, _openWeatherMapAPIKey, _openWeatherMapTimeSpan.ToString());

            var tweets = Observable.Interval(_openWeatherMapTimeSpan).Subscribe(_ => { DoSth(); });
        }

        private void DoSth()
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/");

            var request = new RestRequest("weather?id={id}&appid={appid}", Method.GET);

            request.AddUrlSegment("id", _openWeatherMapCityID);
            request.AddUrlSegment("appid", _openWeatherMapAPIKey);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);
            Console.WriteLine("^");
        }
    }
}
