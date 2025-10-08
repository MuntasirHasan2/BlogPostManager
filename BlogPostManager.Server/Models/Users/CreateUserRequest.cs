using BlogPostManager.Server.Enums;

namespace BlogPostManager.Server.Models;

public class CreateUserRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Roles Role { get; } = Roles.User;
}