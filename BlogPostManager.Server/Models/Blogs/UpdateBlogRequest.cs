using BlogPostManager.Server.Entities;

namespace BlogPostManager.Server.Models;

public class UpdateBlogRequest
{
    public int Id { get; set; }
    public string Title { get; set; } 
    public string Description { get; set; } 
    public int CategoryId { get; set; } 
    public string Content { get; set; } 
    public byte[] MainImage { get; set; }
    public byte[][] Images { get; set; }
    public Guid UserId { get; set; }
}