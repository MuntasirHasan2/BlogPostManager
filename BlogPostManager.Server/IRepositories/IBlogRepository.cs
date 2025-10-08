using BlogPostManager.Server.Models;
using BlogPostManager.Server.Entities;
namespace BlogPostManager.Server.IRepositories;

public interface IBlogRepository
{
    Task<bool> AddAsync(Blog blog);
    Task<Blog?> GetAsync(int id);
    Task<List<Blog>> ListAsync();
    Task<List<Blog>> ListByUserIdAsync(Guid UserId);
    Task<List<Blog>> ListByCategoryAsync(int CategoryId);
    Task<bool> UpdateAsync(Blog blog);
    Task<bool> DeleteAsync(Blog blog);
}