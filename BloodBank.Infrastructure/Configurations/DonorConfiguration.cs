using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Configurations;

internal class DonorConfiguration : BaseEntityConfiguration<Donor>
{
    public override void Configure(EntityTypeBuilder<Donor> builder)
    {
        base.Configure(builder);

        builder.Property(d => d.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(d => d.Email)
               .HasMaxLength(100)
               .IsRequired();

        builder.HasIndex(d => d.Email)
               .IsUnique();

        builder.Property(d => d.BirthDate)
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(d => d.Gender)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(d => d.Weight)
               .HasColumnType("numeric(3,2)")
               .IsRequired();

        builder.Property(d => d.BloodType)
               .HasMaxLength(2)
               .IsRequired();

        builder.Property(d => d.RhFactor)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(d => d.AddressId)
               .IsRequired();

        builder.HasOne(d => d.Address)
               .WithMany(a => a.Donors)
               .HasForeignKey(d => d.AddressId)
               .IsRequired();

        builder.HasMany(d => d.Donations)
               .WithOne(a => a.Donor)
               .HasForeignKey(a => a.DonorId)
               .IsRequired();
    }
}
