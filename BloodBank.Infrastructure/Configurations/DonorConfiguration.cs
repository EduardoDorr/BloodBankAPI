using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using BloodBank.Domain.Enums;
using BloodBank.Domain.Entities;

namespace BloodBank.Infrastructure.Configurations;

internal class DonorConfiguration : BaseEntityConfiguration<Donor>
{
    public override void Configure(EntityTypeBuilder<Donor> builder)
    {
        base.Configure(builder);

        builder.Property(d => d.Name)
               .HasMaxLength(100)
               .IsRequired();
        
        builder.Property(d => d.BirthDate)
               .HasColumnType("date")
               .IsRequired();

        builder.Property(d => d.Weight)
               .HasColumnType("numeric(5,2)")
               .IsRequired();

        builder.OwnsOne(d => d.Gender,
            gender =>
            {
                gender.Property(d => d.Type)
                      .HasColumnName("Gender")
                      .HasConversion(new EnumToStringConverter<GenderType>())
                      .HasMaxLength(10)
                      .IsRequired();
            });

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

        builder.OwnsOne(d => d.Email,
            email =>
            {
                email.Property(d => d.Address)
                     .HasColumnName("Email")
                     .HasMaxLength(100)
                     .IsRequired();

                email.HasIndex(d => d.Address)
                     .IsUnique();
            });
        
        builder.OwnsOne(d => d.Address,
            address =>
            {
                address.Property(a => a.Street)
                       .HasColumnName("Street")
                       .HasMaxLength(100)
                       .IsRequired();

                address.Property(a => a.City)
                       .HasColumnName("City")
                       .HasMaxLength(50)
                       .IsRequired();

                address.Property(a => a.State)
                       .HasColumnName("State")
                       .HasMaxLength(25)
                       .IsRequired();

                address.Property(a => a.ZipCode)
                       .HasColumnName("ZipCode")
                       .HasMaxLength(8)
                       .IsRequired();
            });

        builder.HasMany(d => d.Donations)
               .WithOne(a => a.Donor)
               .HasForeignKey(a => a.DonorId)
               .IsRequired();
    }
}
