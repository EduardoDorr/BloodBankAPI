using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BloodBank.Domain.Entities;

namespace BloodBank.Infrastructure.Configurations;

internal class BloodStorageConfiguration : BaseEntityConfiguration<BloodStorage>
{
    public override void Configure(EntityTypeBuilder<BloodStorage> builder)
    {
        base.Configure(builder);

        builder.Property(d => d.BloodType)
               .HasMaxLength(2)
               .IsRequired();

        builder.Property(d => d.RhFactor)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(d => d.AmountInML)
               .IsRequired();
    }
}