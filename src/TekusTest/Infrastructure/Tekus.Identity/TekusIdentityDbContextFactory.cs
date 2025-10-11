using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tekus.Identity
{
    public class TekusIdentityDbContextFactory : IDesignTimeDbContextFactory<TekusIdentityDbContext>
    {
        public TekusIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TekusIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("DBConnectionString");

            builder.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });

            return new TekusIdentityDbContext(builder.Options);
        }
    }
}
