using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tekus.Domain.Entities;

namespace Tekus.Persistence.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Providers");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.NIT)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(c => c.Services)
               .WithOne(sc => sc.Provider)
               .HasForeignKey(sc => sc.ProviderId);
        }
    }
}
