namespace BlogPostManager.Server.Entities;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; } 
    public string Content { get; set; } = string.Empty;
    public byte[] MainImage { get; set; }
    public byte[][] Images { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public Guid UserId { get; set; }
    public User User{ get; set; }
}