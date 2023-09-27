using ApiLenxy.Domain.Validations;

namespace ApiLenxy.Domain.Notifications;

public abstract class Notification<T> where T : EntityNotification
{
    private readonly List<T> _notifications;

    protected Notification() => _notifications = new List<T>();

    public IReadOnlyCollection<T> Notifications => _notifications;


    /*public void AddNotification(T notification)
    {
        _notifications.Add(notification);
    }*/

    private static T CreateNotification(string prop, string message)
    {
        return (T)Activator.CreateInstance(typeof(T), new object[] { message, prop });
    }

    public void AddNotification(string prop, string message)
    {
        var notification = CreateNotification(prop, message);
        _notifications.Add(notification);
    }

    public void AddNotifications(IReadOnlyCollection<T> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(Notification<T> item)
    {
        AddNotifications(item.Notifications);
    }

    public void AddNotifications(params Notification<T>[] items)
    {
        foreach (var item in items)
            AddNotifications(item);
    }

    public void Clear()
    {
        _notifications.Clear();
    }

    public void ReturnListOfNotification(params Notification<T>[] notifications) //List<EntityNotification>
    { 
        foreach(var item in notifications)
        {
            var teste = item;
        }
    }

    public bool IsValid => _notifications.Any() == false;
}
