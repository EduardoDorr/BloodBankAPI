using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using BloodBank.Domain.Enums;
using BloodBank.Domain.Entities;

namespace BloodBank.Infrastructure.Configurations;

internal class BloodStorageConfiguration : BaseEntityConfiguration<BloodStorage>
{
    public override void Configure(EntityTypeBuilder<BloodStorage> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.AmountInML)
               .IsRequired();

        builder.OwnsOne(b => b.BloodData,
            bloodData =>
            {
                bloodData.Property(b => b.BloodType)
                         .HasColumnName("BloodType")
                         .HasConversion(new EnumToStringConverter<BloodType>())
                         .HasMaxLength(2)
                         .IsRequired();

                bloodData.Property(b => b.RhFactor)
                         .HasColumnName("RhFactor")
                         .HasConversion(new EnumToStringConverter<RhFactor>())
                         .HasMaxLength(10)
                         .IsRequired();
            });       
    }
}