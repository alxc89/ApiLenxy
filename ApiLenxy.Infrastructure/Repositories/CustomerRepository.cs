using ApiLenxy.Domain.Entites;
using ApiLenxy.Domain.Interfaces;
using ApiLenxy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiLenxy.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DataContext _context;
    public CustomerRepository(DataContext dataContext)
    {
        _context = dataContext;
    }

    public async Task<IEnumerable<Customer>> GetCustomerAsync()
    {
        var customers = _context
            .Customers
            .Include(p => p.Phones)
            .Include(a => a.Address)
            .AsNoTracking()
            .AsQueryable();
        return await customers.ToListAsync();
    }

    public async Task<Customer?> GetCustomerById(Guid id)
    {
        var customer = _context
            .Customers
            .Include(p => p.Phones)
            .Include(a => a.Address)
            .AsQueryable();

        var result = await customer.SingleOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<Customer> InsertCustomerAsync(Customer customer)
    {
        try
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        catch (Exception)
        {
            throw new Exception("Erro interno!");
        }

    }

    public async Task<Customer?> UpdateCustomerAsync(Customer customer)
    {
        try
        {
            var customerFromDataBase = await _context
                .Customers
                .Include(a => a.Address)
                .Include(p => p.Phones)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id.Equals(customer.Id));
            if (customer == null || customerFromDataBase == null)
                throw new ArgumentNullException(nameof(customer));

            customerFromDataBase = customer;
            customerFromDataBase.Address = customer.Address;
            customerFromDataBase.Phones = customer.Phones;
            _context.Customers.Update(customerFromDataBase);
            await _context.SaveChangesAsync();

            return customer;
        }
        catch (DbUpdateException u)
        {
            throw;
        }
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        var customer = await _context
            .Customers
            .SingleOrDefaultAsync(x => x.Id == id);
        if (customer != null)
            _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public static void UpdateCustomerPhone(Customer customer, Customer customerFromDataBase)
    {
        customerFromDataBase.Phones.Clear();
        foreach (var phone in customer.Phones)
            customerFromDataBase.Phones.Add(phone);
    }

    public Task<bool> VerifyExistsByDocumentAsync(string document)
    {
        throw new NotImplementedException();
    }
}

