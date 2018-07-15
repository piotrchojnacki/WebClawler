using log4net;
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
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly WeatherContext _context;
        public WeatherRepository(WeatherContext context)
        {
            _context = context;
        }

        public void AddWeather(Weather weatherToAdd)
        {
            if (weatherToAdd != null)
            {
                _context.Weathers.Add(weatherToAdd);
                _context.SaveChanges();

                log.InfoFormat("Inserted 1 row to database.");
            }
            else
            {
                log.InfoFormat("Row is empty, could not insert empty row to database.");
            }

        }
    }
}
