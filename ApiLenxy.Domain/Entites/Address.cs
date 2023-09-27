namespace ApiLenxy.Domain.Entites;

public class Address : Entity
{
    public Address(string zipCode, string state, string city, string street, string number)
    {
        ZipCode = zipCode;
        State = state;
        City = city;
        Street = street;
        Number = number;
    }
    
    private Address() { }

    public Guid CustomerId { get; private set; }
    public string ZipCode { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public Customer Customer { get; private set; }
}
