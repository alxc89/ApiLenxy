using ApiLenxy.Domain.Notifications;
using ApiLenxy.Domain.Notifications.Interfaces;

namespace ApiLenxy.Domain.Validations;

public partial class Contract<T> : Notification<EntityNotification>
{
    public Contract<T> Requires()
    {
        return this;
    }

    public Contract<T> Join(params Notification<EntityNotification>[] items)
    {
        if (items == null) return this;
        foreach (var item in items)
        {
            if (item.IsValid == false)
                AddNotifications(item.Notifications);
        }

        return this;
    }
}
