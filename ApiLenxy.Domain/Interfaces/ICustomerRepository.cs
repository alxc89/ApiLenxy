using ApiLenxy.Domain.Entites;
using System.Linq.Expressions;

namespace ApiLenxy.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> GetById(Guid id);
    Task<Customer> CreateAsync(Customer customer);
    Task<Customer> UpdateAsync(Customer customer);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Customer>> GetAsync();
    Task<bool> VerifyExistsByDocumentAsync(string document);
}
