using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Contexts;
using WebCrawler.Contexts.Interfaces;
using WebCrawler.Models;
using WebCrawler.Repositories.Interfaces;

namespace WebCrawler.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherContext _context;
        public WeatherRepository(WeatherContext context)
        {
            _context = context;
        }

        public void AddWeather(Weather weatherToAdd)
        {
            _context.Weathers.Add(weatherToAdd);
            _context.SaveChanges();
        }
    }
}
