using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Settings.Interfaces
{
    public interface IOpenWeatherMapSettings
    {
        string OpenWeatherMapCityID { get; }
        string OpenWeatherMapAPIKey { get; }
        TimeSpan OpenWeatherMapTimeSpan { get; }
    }
}
