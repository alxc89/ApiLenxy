using ApiLenxy.Domain.Validations;
using Microsoft.EntityFrameworkCore;

namespace ApiLenxy.Domain.ValueObjects;

[Owned]
public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public Name()
    {

    }
   
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
