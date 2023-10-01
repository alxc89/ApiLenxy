using ApiLenxy.Domain.Validations;
using ApiLenxy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiLenxy.Domain.Entites;

public class Customer : Entity
{
    public Customer(Name name, Document document, Email email, ICollection<Phone> phones,
        BirthDay birthDay, Address address)
    {
        Name = name;
        Document = document;
        Email = email;
        Phones = phones;
        BirthDay = birthDay;
        SetStatus(true);
        Created_At = DateTime.Now;
        Address = address;
    }
    private Customer() { }

    public static Customer Update(Guid id, Name name, Document document, Email email, ICollection<Phone> phones,
        BirthDay birthDay, bool status, Address address)
    {
        var customer = new Customer
        {
            Name = name,
            Document = document,
            Email = email,
            Phones = phones,
            BirthDay = birthDay,
            Address = address
        };
        customer.SetId(id);
        customer.SetStatus(status);
        return customer;
    }

    public void Update(Name name, Document document, Email email, BirthDay birth, bool status)
    {
        Name = name;
        Document = document;
        Email = email;
        BirthDay = birth;
        SetStatus(status);
        Updated_At = DateTime.Now;
    }

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public ICollection<Phone> Phones { get; set; }
    public BirthDay BirthDay { get; private set; }
    public bool Status { get; private set; }
    public DateTime Created_At { get; private set; }
    public DateTime Updated_At { get; private set; }
    public Address Address { get; set; }

    private void SetStatus(bool active)
    {
        Status = active;
        Updated_At = DateTime.Now;
    }
}
