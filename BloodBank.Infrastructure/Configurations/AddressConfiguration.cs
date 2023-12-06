using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BloodBank.Domain.Entities;

namespace BloodBank.Infrastructure.Configurations;

internal class AddressConfiguration : BaseEntityConfiguration<Address>
{
    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        base.Configure(builder);

        builder.Property(a => a.Street)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(a => a.City)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(a => a.State)
               .HasMaxLength(25)
               .IsRequired();

        builder.Property(a => a.PostalCode)
               .HasMaxLength(8)
               .IsRequired();

        builder.HasMany(a => a.Donors)
               .WithOne(d => d.Address)
               .HasForeignKey(d => d.AddressId)
               .IsRequired();
    }
}