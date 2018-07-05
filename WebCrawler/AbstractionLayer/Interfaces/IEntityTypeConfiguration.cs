using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.AbstractionLayer.Interfaces
{
    public interface IEntityTypeConfiguration
    {
        void AddConfiguration(ConfigurationRegistrar registrar);
    }
}
