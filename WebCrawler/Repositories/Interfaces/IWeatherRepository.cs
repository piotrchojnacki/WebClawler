using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Repositories.Interfaces
{
    public interface IWeatherRepository 
    {
        void AddWeather(Weather weatherToAdd);
    }
}
