namespace ApiLenxy.Application.Services.Shared;
public class ServiceResponseHelper
{
    public static ServiceResponse<T> Success<T>(int status, string message, T data)
    {
        return new ServiceResponse<T>(message, status, data);
    }
    public static ServiceResponse<T> Success<T>(int status, string message, List<T> data)
    {
        return new ServiceResponse<T>(message, status, data);
    }
    public static ServiceResponse<T> Success<T>(int status, string message)
    {
        return new ServiceResponse<T>(message, status);
    }
    public static ServiceResponse<T> Error<T>(int status, string message)
    {
        return new ServiceResponse<T>(message, status);
    }
}
