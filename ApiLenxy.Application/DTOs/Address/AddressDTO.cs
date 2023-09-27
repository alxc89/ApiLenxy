namespace ApiLenxy.Application.DTOs.Address;

public class AddressDTO
{
    public Guid Id { get; set; }
    public string ZipCode { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }

    public static AddressDTO ToAddressDTO(Domain.Entites.Address address)
     => new() {Id = address.Id, ZipCode = address.ZipCode, State = address.State, City = address.City, Street = address.Street, Number = address.Number };
}
