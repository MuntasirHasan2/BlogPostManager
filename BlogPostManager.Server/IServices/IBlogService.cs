using BlogPostManager.Server.Entities;
using BlogPostManager.Server.Models;

namespace BlogPostManager.Server.IServices;

public interface IBlogService
{
    Task<bool> AddAsync(CreateBlogRequest createBlogRequest);
    Task<BlogResponse> GetAsync(int id);
    Task<List<BlogResponse>> ListAsync();
    Task<List<BlogResponse>> ListByUserIdAsync(Guid UserId);
    Task<List<BlogResponse>> ListByCategoryAsync(int CategoryId);
    Task<bool> UpdateAsync(UpdateBlogRequest updateBlogRequest);
    Task<bool> DeleteAsync(int id);
}