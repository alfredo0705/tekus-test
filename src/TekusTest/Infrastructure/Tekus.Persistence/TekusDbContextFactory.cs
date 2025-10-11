using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tekus.Persistence
{
    public class TekusDbContextFactory : IDesignTimeDbContextFactory<TekusDbContext>
    {
        TekusDbContext IDesignTimeDbContextFactory<TekusDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TekusDbContext>();
            var connectionString = configuration.GetConnectionString("DBConnectionString");

            builder.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });

            return new TekusDbContext(builder.Options);
        }
    }
}
