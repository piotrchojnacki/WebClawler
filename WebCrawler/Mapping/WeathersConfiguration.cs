using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.AbstractionLayer;
using WebCrawler.Models;

namespace WebCrawler.Mapping
{
    class WeathersConfiguration : AEntityConfiguration<Weather>
    {
        public WeathersConfiguration()
            : base("Weather") { }

        public override void BuildConfiguration()
        {
            #region Primary key
            this.HasKey(weather => weather.Id);
            #endregion

            #region Properties
            this.Property(weather => weather.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            this.Property(weather => weather.Temp)
                .HasColumnName("Temp");

            this.Property(weather => weather.Pressure)
                .HasColumnName("Pressure");

            this.Property(weather => weather.Humidity)
                .HasColumnName("Humidity");

            this.Property(weather => weather.TempMin)
                .HasColumnName("TempMin");

            this.Property(weather => weather.TempMax)
                .HasColumnName("TempMax");

            this.Property(weather => weather.Visibility)
                .HasColumnName("Visibility");

            this.Property(weather => weather.WindSpeed)
                .HasColumnName("WindSpeed");

            this.Property(weather => weather.WindDeg)
                .HasColumnName("WindDeg");

            this.Property(weather => weather.CloudsAll)
                .HasColumnName("CloudsAll");

            this.Property(weather => weather.Dt)
                .HasColumnName("Dt");
            #endregion
        }
    }
}
