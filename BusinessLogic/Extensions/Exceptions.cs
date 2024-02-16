namespace BusinessLogic;

public sealed class NotFoundEntity : Exception
{
    public NotFoundEntity(string message) : base(message)
    {
    }
}

public sealed class NotAuthorized : Exception
{

}

public sealed class BadRequestException : Exception
{
    // public BadRequestException() : base() { }
    // public BadRequestException(string message) : base(message) { }
    // public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
}

public class ResourceNotFoundException : Exception
{
}