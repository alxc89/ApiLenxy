using ApiLenxy.Application.DTOs;
using ApiLenxy.Application.DTOs.Address;
using ApiLenxy.Application.DTOs.Phone;

namespace ApiLenxy.Application.DTOs.Customer;

public class CreateCustomerDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string DocumentNumber { get; set; }
    public string DocumentType { get; set; }
    public bool Status { get; set; }
    public DateTime BirthDay { get; set; }
    public ICollection<CreatePhoneDTO> Phone { get; set; }
    public CreateAddressDTO Address { get; set; }
}
