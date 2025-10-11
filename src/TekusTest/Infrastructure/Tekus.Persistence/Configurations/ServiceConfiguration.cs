using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tekus.Domain.Entities;

namespace Tekus.Persistence.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.HourlyRate)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.HasMany(c => c.ServiceCountries)
               .WithOne(sc => sc.Service)
               .HasForeignKey(sc => sc.CountryId);
        }
    }
}
