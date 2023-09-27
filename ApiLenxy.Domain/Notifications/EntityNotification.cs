namespace ApiLenxy.Domain.Notifications;

public class EntityNotification
{
    public EntityNotification()
    {
        
    }
    public EntityNotification(string message, string propertyName)
    {
        Message = message;
        PropertyName = propertyName;
    }

    public string Message { get; set; }
    public string PropertyName { get; set; }
}
