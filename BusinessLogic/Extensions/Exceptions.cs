namespace BusinessLogic;

public sealed class PostNotFoundException : Exception
{}
public sealed class UserNotFoundException : Exception
{}

public sealed class NotAuthorized : Exception
{
    
}

public sealed class BadRequestException : Exception
{
    // public BadRequestException() : base() { }
    // public BadRequestException(string message) : base(message) { }
    // public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
}
