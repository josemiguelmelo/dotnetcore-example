using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApi.DataModels.DbProviders
{
    public class InMemoryDbProvider : AbstractDbProvider
    {
        public InMemoryDbProvider(IConfiguration configuration) : base(configuration)
        {
        }

        protected override DbContextOptionsBuilder<ApplicationDbContext> DatabaseOption()
        {
            return this.config.UseInMemoryDatabase(ConnectionString());
        }
    }
}