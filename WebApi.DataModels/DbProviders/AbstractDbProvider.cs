using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApi.DataModels.DbProviders
{
    abstract public class AbstractDbProvider
    {
        public static string DB_PROVIDER = "DB_PROVIDER";

        protected DbContextOptionsBuilder<ApplicationDbContext> config
        {
            get; set;
        }

        protected IConfiguration _configuration;

        public AbstractDbProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected abstract DbContextOptionsBuilder<ApplicationDbContext> DatabaseOption();

        protected string ConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public DbContextOptionsBuilder<ApplicationDbContext> Config()
        {
            this.config = new DbContextOptionsBuilder<ApplicationDbContext>();

            this.config = DatabaseOption();

            return config;
        }

        public static DbContextOptionsBuilder<ApplicationDbContext> LoadDbOptions(string dbProviderName)
        {
            AbstractDbProvider dbProvider = Assembly.GetExecutingAssembly().CreateInstance(dbProviderName) as AbstractDbProvider;
            return dbProvider.Config();
        }
    }
}