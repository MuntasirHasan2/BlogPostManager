using BlogPostManager.Server.Enums;

namespace BlogPostManager.Server.Entities;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public Roles Role { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public List<Blog> Blogs { get; } = new();
}