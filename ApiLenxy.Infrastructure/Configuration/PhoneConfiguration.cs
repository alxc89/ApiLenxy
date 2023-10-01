using ApiLenxy.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiLenxy.Infrastructure.Configuration;

public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.ToTable(nameof(Phone));
        builder.HasKey(x => x.Id);
        builder.Property(p => p.PhoneNumber).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.Created_at).HasColumnType("datetime2");

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Phones)
            .HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
    }
}
