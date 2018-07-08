using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Mapping
{
    public class WeatherMapper
    {
        private readonly string _weatherString;

        public WeatherMapper(string weatherString)
        {
            _weatherString = weatherString;
        }
        public Weather MapToWeather()
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

            Decimal.TryParse(JObject.Parse(_weatherString)["main"]["temp"].ToString(), out temp);
            Int32.TryParse(JObject.Parse(_weatherString)["main"]["pressure"].ToString(), out pressure);
            Int32.TryParse(JObject.Parse(_weatherString)["main"]["humidity"].ToString(), out humidity);
            Decimal.TryParse(JObject.Parse(_weatherString)["main"]["temp_min"].ToString(), out tempMin);
            Decimal.TryParse(JObject.Parse(_weatherString)["main"]["temp_max"].ToString(), out tempMax);
            Int32.TryParse(JObject.Parse(_weatherString)["visibility"].ToString(), out visibility);
            Decimal.TryParse(JObject.Parse(_weatherString)["wind"]["speed"].ToString(), out windSpeed);
            Decimal.TryParse(JObject.Parse(_weatherString)["wind"]["deg"].ToString(), out windDeg);
            Int32.TryParse(JObject.Parse(_weatherString)["clouds"]["all"].ToString(), out cloudsAll);
            Int64.TryParse(JObject.Parse(_weatherString)["dt"].ToString(), out dt);

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
