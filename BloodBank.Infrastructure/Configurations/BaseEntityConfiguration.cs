using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BloodBank.Domain.Entities;

namespace BloodBank.Infrastructure.Configurations;

internal abstract class BaseEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TBase> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .UseIdentityColumn();

        builder.Property(b => b.IsActive)
               .IsRequired();

        builder.Property(b => b.CreatedAt)
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(b => b.UpdatedAt)
               .HasColumnType("datetime")
               .IsRequired();
    }
}