using Microsoft.EntityFrameworkCore;

namespace WebApi.DataModels.DbProviders
{
    public class InMemoryDbProvider : AbstractDbProvider
    {
        protected override DbContextOptionsBuilder<ApplicationDbContext> DatabaseOption()
        {
            return this.config.UseInMemoryDatabase(ConnectionString());
        }
    }
}