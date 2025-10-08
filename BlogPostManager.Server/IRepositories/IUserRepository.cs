using BlogPostManager.Server.Entities;

namespace BlogPostManager.Server.IRepositories;

public interface IUserRepository
{
    Task<bool> AddAsync(User user);
    Task<User?> GetAsync(Guid id);
    Task<User?> GetByNameAsync(string name);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(User user);
}