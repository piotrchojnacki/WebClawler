using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Models.Interfaces
{
    public interface IWeather
    {
        long Id { get; }
        decimal Temp { get; }
        int Pressure { get; }
        int Humidity { get; }
        decimal TempMin { get; }
        decimal TempMax { get; }
        int Visibility { get; }
        decimal WindSpeed { get; }
        decimal WindDeg { get; }
        int CloudsAll { get; }
        long Dt { get; }
    }
}
