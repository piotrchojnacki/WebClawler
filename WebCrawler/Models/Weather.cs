using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Models.Interfaces;

namespace WebCrawler.Models
{
    public class Weather : IWeather
    {
        public long Id { get; private set; }
        public decimal Temp { get; private set; }
        public int Pressure { get; private set; }
        public int Humidity { get; private set; }
        public decimal TempMin { get; private set; }
        public decimal TempMax { get; private set; }
        public int Visibility  { get; private set; }
        public decimal WindSpeed { get; private set; }
        public decimal WindDeg { get; private set; }
        public int CloudsAll { get; private set; }
        public long Dt { get; private set; }

        public Weather(
            decimal temp,
            int pressure,
            int humidity,
            decimal tempMin,
            decimal tempMax,
            int visibility,
            decimal windSpeed,
            decimal windDeg,
            int cloudsAll,
            long dt)
        {
            Temp = temp;
            Pressure = pressure;
            Humidity = humidity;
            TempMin = tempMin;
            TempMax = tempMax;
            Visibility = visibility;
            WindSpeed = windSpeed;
            WindDeg = windDeg;
            CloudsAll = cloudsAll;
            Dt = dt;
        }
    }
}
