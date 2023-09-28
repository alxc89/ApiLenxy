using ApiLenxy.Domain.Entites;
using System.Linq.Expressions;

namespace ApiLenxy.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetCustomerAsync();
    Task<Customer> GetCustomerById(Guid id);
    Task<Customer> InsertCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Guid id);
    Task<bool> VerifyExistsByDocumentAsync(string document);
}
