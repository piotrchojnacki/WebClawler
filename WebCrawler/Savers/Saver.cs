using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Contexts.Interfaces;
using WebCrawler.Models;
using WebCrawler.Repositories;
using WebCrawler.Repositories.Interfaces;
using WebCrawler.Savers.Interfaces;

namespace WebCrawlers.Saver
{
    public class Saver : ISaver
    {
        private readonly IWeatherRepository _weatherRepository;
        public Saver(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        public void Save(Weather weather)
        {
            Console.WriteLine("Saved: " + weather.Temp);
            _weatherRepository.AddWeather(weather);
        }
    }
}
