using ApiLenxy.Domain.Entites;
using ApiLenxy.Infrastructure.Configuration;
using ApiLenxy.Infrastructure.ExtensionsMethods;
using Microsoft.EntityFrameworkCore;

namespace ApiLenxy.Infrastructure.Context;

public class DataContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ConfigureOwnedTypeNavigationsAsRequired();
    }
}
