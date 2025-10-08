using BlogPostManager.Server.Entities;
using BlogPostManager.Server.Models;

namespace BlogPostManager.Server.IServices;

public interface IUserService
{
    Task<UserResponse> AddAsync(CreateUserRequest createUserRequest);
    Task<UserResponse> GetAsync(GetUserRequest getUserRequest);
    Task<bool> UpdateAsync(UpdateUserRequest updateUserRequest);
    Task<bool> DeleteAsync(Guid id);
}