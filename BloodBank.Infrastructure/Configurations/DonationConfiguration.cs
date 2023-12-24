using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using BloodBank.Domain.Enums;
using BloodBank.Domain.Entities;

namespace BloodBank.Infrastructure.Configurations;

internal class DonationConfiguration : BaseEntityConfiguration<Donation>
{
    public override void Configure(EntityTypeBuilder<Donation> builder)
    {
        base.Configure(builder);

        builder.Property(d => d.DonorId)
               .IsRequired();

        builder.Property(d => d.DonationDate)
               .HasColumnType("datetime")
               .IsRequired();

        builder.OwnsOne(d => d.BloodData,
            bloodData =>
            {
                bloodData.Property(d => d.BloodType)
                         .HasColumnName("BloodType")
                         .HasConversion(new EnumToStringConverter<BloodType>())
                         .HasMaxLength(2)
                         .IsRequired();

                bloodData.Property(d => d.RhFactor)
                         .HasColumnName("RhFactor")
                         .HasConversion(new EnumToStringConverter<RhFactor>())
                         .HasMaxLength(10)
                         .IsRequired();
            });

        builder.Property(d => d.AmountInML)
               .IsRequired();

        builder.HasOne(d => d.Donor)
               .WithMany(a => a.Donations)
               .HasForeignKey(d => d.DonorId)
               .IsRequired();
    }
}