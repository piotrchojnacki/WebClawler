using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.AbstractionLayer.Interfaces;

namespace WebCrawler.AbstractionLayer
{
    public abstract class AEntityConfiguration<T> : EntityTypeConfiguration<T>, IEntityTypeConfiguration where T : class
    {
        protected AEntityConfiguration(string tableName)
        {
            this.ToTable(tableName);
        }

        public AEntityConfiguration(string tableName, string schemaName)
        {
            this.ToTable(tableName, schemaName);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            this.BuildConfiguration();
            registrar.Add(this);
        }

        public abstract void BuildConfiguration();
    }
}
