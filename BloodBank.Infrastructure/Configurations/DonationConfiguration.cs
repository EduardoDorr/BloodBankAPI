using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        builder.Property(d => d.BloodType)
               .HasMaxLength(2)
               .IsRequired();

        builder.Property(d => d.RhFactor)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(d => d.AmountInML)
               .IsRequired();

        builder.HasOne(d => d.Donor)
               .WithMany(a => a.Donations)
               .HasForeignKey(d => d.DonorId)
               .IsRequired();
    }
}