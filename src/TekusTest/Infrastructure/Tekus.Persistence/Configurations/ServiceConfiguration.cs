using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;
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

            // Convierte List<string> <-> string (JSON)
            builder.Property(s => s.Countries)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                       v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
                   .HasColumnType("nvarchar(max)");
        }
    }
}
