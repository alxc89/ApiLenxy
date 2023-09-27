using ApiLenxy.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiLenxy.Infrastructure.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));
        builder.HasIndex(x => x.Id);
        #region ValueObjcet
        builder.OwnsOne(x => x.Name, name =>
        {
            name.Property(n => n.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR");
            name.Property(n => n.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR")
                .IsRequired();
        });
        builder.OwnsOne(x => x.Document, document =>
        {
            document.Property(d => d.Number)
                .HasColumnName("Document")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR")
                .IsRequired();
            document.Property(d => d.Type)
                .HasColumnName("Type")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR")
                .IsRequired();
});
        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(e => e.Address)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .HasColumnType("VARCHAR");
        });
        #endregion
    }
}
