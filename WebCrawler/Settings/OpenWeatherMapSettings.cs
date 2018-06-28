using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Settings.Interfaces;

namespace WebCrawler.Settings
{
    public class OpenWeatherMapSettings : IOpenWeatherMapSettings
    {
        public OpenWeatherMapSettings()
        {
            OpenWeatherMapCityID = ConfigurationManager.AppSettings["openWeatherMapCityID"];
            OpenWeatherMapAPIKey = ConfigurationManager.AppSettings["openWeatherMapAPIKey"];

            var openWeatherMapTimeSpan = ConfigurationManager.AppSettings["openWeatherMapTimeSpan"];
            OpenWeatherMapTimeSpan = TimeSpan.Parse(openWeatherMapTimeSpan);
        }
        public string OpenWeatherMapCityID { get; set; }
        public string OpenWeatherMapAPIKey { get; set; }
        public TimeSpan OpenWeatherMapTimeSpan { get; set; }
    }
}
