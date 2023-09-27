using ApiLenxy.Domain.Entites;
using ApiLenxy.Domain.Interfaces;
using ApiLenxy.Infrastructure.Context;

namespace ApiLenxy.Infrastructure.Repositories;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    private readonly DataContext _context;
    public CustomerRepository(DataContext dataContext) : base(dataContext)
    {
        _context = dataContext;
    }

    Task<bool> ICustomerRepository.VerifyExistsByDocumentAsync(string document)
    {
        throw new NotImplementedException();
    }

    public async Task<Customer> UpdateCustomer(Guid id, Customer customer)
    {
        var customerLoadFromDataBase = await GetById(id, p => p.Phones, a => a.Address);
        if (customer == null)
            throw new ArgumentNullException(nameof(customer));
        _context.Customers.Entry(customerLoadFromDataBase).CurrentValues.SetValues(customer);
        await _context.SaveChangesAsync();

        return customer;
    }
}
