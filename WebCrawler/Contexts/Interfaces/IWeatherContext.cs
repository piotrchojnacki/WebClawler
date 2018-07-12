using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Contexts.Interfaces
{
    public interface IWeatherContext
    {
        DbSet<Weather> Weathers { get; }
    }
}
