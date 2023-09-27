using Microsoft.EntityFrameworkCore;

namespace ApiLenxy.Domain.ValueObjects;

[Owned]
public class BirthDay
{
    public BirthDay(DateTime date)
    {
        SetDate(date);
    }

    public DateTime Date { get; private set; }

    private void SetDate(DateTime date)
    {
        if (DateTime.Now == date)
            throw new ArgumentException("Data de Aniversário não poder igual a Data de Hoje");
        Date = date;
    }
}
