using Microsoft.EntityFrameworkCore;

namespace WebApi.DataModels.DbProviders
{
    abstract public class AbstractDbProvider
    {
        public static string DB_CONNECTION_STRING = "DB_CONNECTION_STRING";
        public static string DB_PROVIDER = "DB_PROVIDER";

        protected DbContextOptionsBuilder<ApplicationDbContext> config
        {
            get; set;
        }

        protected abstract DbContextOptionsBuilder<ApplicationDbContext> DatabaseOption();

        protected string ConnectionString()
        {
            return System.Environment.GetEnvironmentVariable(DB_CONNECTION_STRING);
        }

        public DbContextOptionsBuilder<ApplicationDbContext> Config()
        {
            this.config = new DbContextOptionsBuilder<ApplicationDbContext>();

            DatabaseOption();

            return config;
        }
    }
}