using BlogPostManager.Server.Entities;
using BlogPostManager.Server.Models;
using BlogPostManager.Server.BlogDBContexts;
using BlogPostManager.Server.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlogPostManager.Server.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly BlogDBContext _blogDBContext;
    public BlogRepository()
    {
        _blogDBContext = new BlogDBContext();
    }
    public async Task<bool> AddAsync(Blog blog)
    {
        await _blogDBContext.Blogs.AddAsync(blog);
        return await _blogDBContext.SaveChangesAsync() > 0;
    }
    public async Task<Blog?> GetAsync(int id)
    {
        return await _blogDBContext.Blogs.FirstOrDefaultAsync(n => n.Id == id);
    }
    public async Task<List<Blog>> ListAsync()
    {
        return await _blogDBContext.Blogs
                                   .ToListAsync();
    }
    public async Task<List<Blog>> ListByUserIdAsync(Guid UserId)
    {
        return await _blogDBContext.Blogs
                                   .Where(n => n.UserId == UserId)
                                   .ToListAsync();
    }
    public async Task<List<Blog>> ListByCategoryAsync(int CategoryId)
    {
        return await _blogDBContext.Blogs
                                   .Where(n => n.CategoryId == CategoryId)
                                   .ToListAsync();
    }
    public async Task<bool> UpdateAsync(Blog blog)
    {
        _blogDBContext.Blogs.Update(blog);
        return await _blogDBContext.SaveChangesAsync() > 0;
    }
    public async Task<bool> DeleteAsync(Blog blog)
    {
        _blogDBContext.Remove(blog);
        return await _blogDBContext.SaveChangesAsync() > 0;
    }
}