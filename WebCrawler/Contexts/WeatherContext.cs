using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Contexts
{
    public class WeatherContext : DbContext
    {
        #region Properties
        public DbSet<Weather> Weathers { get; set; }
        #endregion

        #region .ctor
        public WeatherContext(string connectionString)
            : base(new NpgsqlConnection(connectionString), true)
        {
            Database.SetInitializer<WeatherContext>(null);
        }
        #endregion
    }
}
