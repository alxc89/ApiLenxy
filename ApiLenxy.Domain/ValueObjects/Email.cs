using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiLenxy.Domain.ValueObjects;

[Owned]
public class Email
{
    public Email(string address)
    {
        Address = address;
    }
    private Email()
    {
    }
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    public string Address { get; private set; }
}
