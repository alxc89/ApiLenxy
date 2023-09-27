using ApiLenxy.Application.DTOs.Address;
using ApiLenxy.Application.DTOs.Phone;
using ApiLenxy.Domain.ValueObjects;

namespace ApiLenxy.Application.DTOs.Customer;

public class CustomerDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string DocumentNumber { get; set; }
    public string DocumentType { get; set; }
    public bool Status { get; set; }
    public DateTime BirthDay { get; set; }
    public ICollection<PhoneDTO> Phone { get; set; }
    public AddressDTO Address { get; set; }

    public static implicit operator CustomerDTO(Domain.Entites.Customer customer)
    {
        return new CustomerDTO
        {
            Id = customer.Id,
            FirstName = customer.Name.FirstName,
            LastName = customer.Name.LastName,
            Email = customer.Email.Address,
            DocumentNumber = customer.Document.Number,
            DocumentType = customer.Document.Type.ToString(),
            Status = customer.Status,
            BirthDay = customer.BirthDay.Date,
            Phone = PhoneDTO.ToPhoneDTO(customer.Phones),
            Address = AddressDTO.ToAddressDTO(customer.Address),
        };
    }

    public static Domain.Entites.Customer ToCustomer(CustomerDTO customerDTO)
    {
        var name = new Name(customerDTO.FirstName, customerDTO.LastName);
        var document = new Document(customerDTO.DocumentNumber, customerDTO.DocumentType);
        var email = new Email(customerDTO.Email);
        var birthDay = new BirthDay(customerDTO.BirthDay);

        var phone = new List<Domain.Entites.Phone>();
        foreach (var item in customerDTO.Phone)
        {
            var phoneDTO = new Domain.Entites.Phone() { PhoneNumber = item.PhoneNumber };
            phone.Add(phoneDTO);
        }

        var address = new Domain.Entites.Address(customerDTO.Address.ZipCode, customerDTO.Address.State,
            customerDTO.Address.City, customerDTO.Address.Street, customerDTO.Address.Number);

        return new Domain.Entites.Customer(name, document, email, phone, birthDay, address);
    }
}
