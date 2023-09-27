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
}
