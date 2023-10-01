namespace ApiLenxy.Domain.Entites;

public class Phone : Entity
{
    public Phone(string numberPhone)
    {
        PhoneNumber = numberPhone;
    }

    public Phone() { }

    public Guid CustomerId { get; set; }
    public string PhoneNumber { get; set; }
    public Customer Customer { get; set; }

    public static Phone Update(Guid id, string phoneNumber, Guid customerId)
    {
        Phone phone = new()
        {
            PhoneNumber = phoneNumber,
            CustomerId = customerId
        };
        phone.SetId(id);

        return phone;
    }

    public void Update(string phoneNumber, Guid customerId)
    {
        PhoneNumber = phoneNumber;
        CustomerId = customerId;
    }
}
