using ApiLenxy.Application.DTOs.Customer;
using ApiLenxy.Application.Services.Shared;
using ApiLenxy.Domain.Entites;

namespace ApiLenxy.Application.Services.Customer;

public interface ICustomerService
{
    Task<ServiceResponse<CustomerDTO>> GetCustomersAsync();
    Task<ServiceResponse<CustomerDTO>> GetCustomerByIdAsync(Guid idCustomer);
    Task<ServiceResponse<CustomerDTO>> CreateCustomerAsync(CreateCustomerDTO createCustomerDTO);
    Task<ServiceResponse<CustomerDTO>> UpdateCustomerAsync(UpdateCustomerDTO updateCustomerDTO);
    Task<ServiceResponse<CustomerDTO>> DeleteAsync(Guid id);
}
