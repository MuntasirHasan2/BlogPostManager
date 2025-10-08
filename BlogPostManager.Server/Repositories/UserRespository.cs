using BlogPostManager.Server.IRepositories;
using BlogPostManager.Server.Entities;
using BlogPostManager.Server.BlogDBContexts;
using Microsoft.EntityFrameworkCore;


namespace BlogPostManager.Server.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BlogDBContext _blogDBContext;
    public UserRepository()
    {
        _blogDBContext = new BlogDBContext();
    }

    public async Task<bool> AddAsync(User user)
    {
        await _blogDBContext.Users.AddAsync(user);
        return await _blogDBContext.SaveChangesAsync() > 0;
    }

    public async Task<User?> GetAsync(Guid id)
    {
        return await _blogDBContext.Users.FindAsync(id);
    }

    public async Task<User?> GetByNameAsync(string name)
    {
        return await _blogDBContext
                    .Users
                    .FirstOrDefaultAsync(n => n.UserName == name);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _blogDBContext
                    .Users
                    .FirstOrDefaultAsync(n => n.Email == email);
    }

    public async Task<bool> UpdateAsync(User user)
    {
        _blogDBContext.Users.Update(user);
        return await _blogDBContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(User user)
    {
        _blogDBContext.Users.Remove(user);
        return await _blogDBContext.SaveChangesAsync() > 0;
    }
}