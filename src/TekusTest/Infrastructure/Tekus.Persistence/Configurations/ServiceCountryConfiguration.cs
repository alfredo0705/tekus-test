using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tekus.Domain.Entities;

namespace Tekus.Persistence.Configurations
{
    public class ServiceCountryConfiguration : IEntityTypeConfiguration<ServiceCountry>
    {
        public void Configure(EntityTypeBuilder<ServiceCountry> builder)
        {
            builder.ToTable("ServiceCountries");

            builder.HasKey(sc => new { sc.ServiceId, sc.CountryId });
        }
    }
}
