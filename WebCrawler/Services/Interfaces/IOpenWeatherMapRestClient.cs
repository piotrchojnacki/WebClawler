using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Services.Interfaces
{
    interface IOpenWeatherMapRestClient
    {
        //void GetWeather();
        string GetWeather();
    }
}
