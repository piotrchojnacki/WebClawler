using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Mapping.Interfaces;
using WebCrawler.Models;

namespace WebCrawler.Mapping
{
    public class WeatherMapper : IWeatherMapper
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public WeatherMapper() {}
        public Weather MapToWeather(string weatherString)
        {
            decimal temp;
            int pressure;
            int humidity;
            decimal tempMin;
            decimal tempMax;
            int visibility;
            decimal windSpeed;
            decimal windDeg;
            int cloudsAll;
            long dt;

            try
            {
                Decimal.TryParse(JObject.Parse(weatherString)["main"]["temp"].ToString(), out temp);
                Int32.TryParse(JObject.Parse(weatherString)["main"]["pressure"].ToString(), out pressure);
                Int32.TryParse(JObject.Parse(weatherString)["main"]["humidity"].ToString(), out humidity);
                Decimal.TryParse(JObject.Parse(weatherString)["main"]["temp_min"].ToString(), out tempMin);
                Decimal.TryParse(JObject.Parse(weatherString)["main"]["temp_max"].ToString(), out tempMax);
                Int32.TryParse(JObject.Parse(weatherString)["visibility"].ToString(), out visibility);
                Decimal.TryParse(JObject.Parse(weatherString)["wind"]["speed"].ToString(), out windSpeed);
                Decimal.TryParse(JObject.Parse(weatherString)["wind"]["deg"].ToString(), out windDeg);
                Int32.TryParse(JObject.Parse(weatherString)["clouds"]["all"].ToString(), out cloudsAll);
                Int64.TryParse(JObject.Parse(weatherString)["dt"].ToString(), out dt);

                log.InfoFormat("Mapped JObject to Weather.");
            }
            catch(NullReferenceException e)
            {
                log.ErrorFormat("Could not map JObject to Weather:\n" + e);
                return null;
            }

            return new Weather(
                temp,
                pressure,
                humidity,
                tempMin,
                tempMax,
                visibility,
                windSpeed,
                windDeg,
                cloudsAll,
                dt);
        }
    }
}
