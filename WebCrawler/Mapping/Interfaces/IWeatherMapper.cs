using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Mapping.Interfaces
{
    public interface IWeatherMapper
    {
        Weather MapToWeather(string weatherString);
    }
}
