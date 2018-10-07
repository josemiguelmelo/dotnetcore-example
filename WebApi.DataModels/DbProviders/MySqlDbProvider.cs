using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApi.DataModels.DbProviders
{
    public class MySqlDbProvider : AbstractDbProvider
    {
        public MySqlDbProvider(IConfiguration configuration) : base(configuration)
        {
        }

        protected override DbContextOptionsBuilder<ApplicationDbContext> DatabaseOption()
        {
            return this.config.UseMySql(ConnectionString());
        }
    }
}