using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Models;
using WebCrawler.Services.Interfaces;
using WebCrawler.Settings.Interfaces;

namespace WebCrawler.Services
{
    class OpenWeatherMapRestClient : IOpenWeatherMapRestClient
    {
        private RestClient _client;
        private RestRequest _request;
        public OpenWeatherMapRestClient(IOpenWeatherMapSettings openWeatherMapSettings)
        {
            _client = new RestClient(openWeatherMapSettings.OpenWeatherMapBaseUrl);

            _request = new RestRequest("weather?id={id}&appid={appid}", Method.GET);
            _request
                .AddUrlSegment("id", openWeatherMapSettings.OpenWeatherMapCityID)
                .AddUrlSegment("appid", openWeatherMapSettings.OpenWeatherMapAPIKey);
        }

        public string GetWeather()
        {
            IRestResponse response = _client.Execute(_request);
            var content = response.Content;

            Console.WriteLine(content + Environment.NewLine);

            return content;
        }
    }
}
