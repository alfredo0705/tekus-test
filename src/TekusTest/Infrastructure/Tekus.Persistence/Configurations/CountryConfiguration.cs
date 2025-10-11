using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tekus.Domain.Entities;

namespace Tekus.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Code)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.HasMany(c => c.ServiceCountries)
               .WithOne(sc => sc.Country)
               .HasForeignKey(sc => sc.CountryId);
        }
    }
}
