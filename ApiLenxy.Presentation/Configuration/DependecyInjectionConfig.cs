using ApiLenxy.Application.Services.Customer;
using ApiLenxy.Domain.Interfaces;
using ApiLenxy.Infrastructure.Repositories;

namespace ApiLenxy.Presentation.Configuration;

public static class DependecyInjectionConfig
{
    public static void AddDependecyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<ICustomerService, CustomerService>();
    }
}
