using ApiLenxy.Domain.Notifications;

namespace ApiLenxy.Domain.Validations;

public partial class Contract<T>
{
    public bool Compare(int compare, string value)
    {
        return value.Length >= compare;
    }

    public Contract<T> IsNotNull(string value, string prop, string message)
    {
        if (value == null)
            AddNotification(prop, message);
        return this;
    }

    public Contract<T> IsGreaterThan(int compare, string value, string prop, string message)
    {
        if (!Compare(compare, value))
            AddNotification(prop, message);
        return this;
    }
}
