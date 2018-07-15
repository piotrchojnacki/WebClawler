using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Services.Interfaces
{
    public interface IOpenWeatherMapRestClient
    {
        string GetWeather();
    }
}
