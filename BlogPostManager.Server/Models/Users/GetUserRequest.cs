namespace BlogPostManager.Server.Models;

public class GetUserRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}