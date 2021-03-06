﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Crawler.Interfaces
{
    public interface IOpenWeatherMapCrawler
    {
        IObservable<Weather> WeatherSource { get; }
    }
}
