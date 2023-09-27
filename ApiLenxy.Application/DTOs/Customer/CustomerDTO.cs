using ApiLenxy.Application.DTOs.Address;
using ApiLenxy.Application.DTOs.Phone;

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

    //public static Customer ToCutomer(CustomerDTO customerDTO)
    //{
    //    var name = new Name(customerDTO.FirstName, customerDTO.LastName);
    //    var document = new Document(customerDTO.DocumentNumber, Api_Lenxy.Domain.Enums.EDocumentType.CPF);
    //    var email = new Email(customerDTO.Email);
    //    var birthDay = new BirthDay(customerDTO.BirthDay);

    //    var phone = new List<Phone>
    //    {
    //        new Phone(customerDTO.Phone.ToString()),
    //    };

    //    var address = new Address(customerDTO.Address.ZipCode, customerDTO.Address.State,
    //        customerDTO.Address.City, customerDTO.Address.Street, customerDTO.Address.Number);

    //    return new Customer(name, document, email, phone, birthDay, address);
    //}
}
