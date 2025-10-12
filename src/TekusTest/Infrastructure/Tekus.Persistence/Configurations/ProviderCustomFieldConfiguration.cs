using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tekus.Domain.Entities;

namespace Tekus.Persistence.Configurations
{
    public class ProviderCustomFieldConfiguration : IEntityTypeConfiguration<ProviderCustomField>
    {
        public void Configure(EntityTypeBuilder<ProviderCustomField> builder)
        {
            builder.ToTable("ProviderCustomFields");

            // Clave compuesta: evita campos repetidos por proveedor
            builder.HasKey(cf => new { cf.ProviderId, cf.FieldName });

            // Relaciones
            builder.HasOne(cf => cf.Provider)
                   .WithMany(p => p.CustomFields)
                   .HasForeignKey(cf => cf.ProviderId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Propiedades
            builder.Property(cf => cf.FieldName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(cf => cf.FieldValue)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}
