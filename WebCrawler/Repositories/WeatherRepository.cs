using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Contexts;
using WebCrawler.Models;
using WebCrawler.Repositories.Interfaces;

namespace WebCrawler.Repositories
{
    public class WeatherRepository : Repository<Weather>, IWeatherRepository
    {
        public WeatherRepository(WeatherContext context)
            : base(context) { }

    }
}
