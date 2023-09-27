using ApiLenxy.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiLenxy.Infrastructure.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address));
        builder.HasKey(p => p.Id);
        builder.Property(a => a.Street)
            .HasColumnType("varchar")
            .HasMaxLength(150);
        builder.Property(a => a.State)
            .HasColumnType("char")
            .HasMaxLength(2);
        builder.Property(a => a.City)
            .HasColumnType("varchar")
            .HasMaxLength(100);
        builder.Property(a => a.Number)
            .HasColumnType("varchar")
            .HasMaxLength(20);

        builder.HasOne(a => a.Customer)
            .WithOne(c => c.Address)
            .HasForeignKey<Address>(c => c.CustomerId)
            .IsRequired();
    }
}
