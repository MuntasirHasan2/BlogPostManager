namespace BlogPostManager.Server.CustomExceptions;
public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message){}
}