using ApiLenxy.Domain.Entites;

namespace ApiLenxy.Domain.Interfaces;

public interface ICustomerRepository : IRepositoryBase<Customer>
{
    Task<bool> VerifyExistsByDocumentAsync(string document);
    Task<Customer> UpdateCustomer(Guid id, Customer customer);
}
