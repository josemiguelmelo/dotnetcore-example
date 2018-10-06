using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace WebApi.DataModels.DbProviders
{
    public class MySqlDbProvider : AbstractDbProvider
    {
        protected override DbContextOptionsBuilder<ApplicationDbContext> DatabaseOption()
        {
            return this.config.UseMySQL(ConnectionString());
        }
    }
}