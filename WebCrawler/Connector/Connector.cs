using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Connector.Interfaces;
using WebCrawler.Crawler.Interfaces;
using WebCrawler.Saver.Interfaces;

namespace WebCrawler.Connector
{
    public class Connector : IConnector
    {
        #region .ctor
            public Connector(ISaver saver, IOpenWeatherMapCrawler openWeatherMapCrawler)
        {
            openWeatherMapCrawler.WeatherSource.Subscribe(weather => saver.Save(weather));
        }
        #endregion
    }
}
