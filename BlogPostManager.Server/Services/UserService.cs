using BlogPostManager.Server.Entities;
using BlogPostManager.Server.Models;
using BlogPostManager.Server.IServices;
using BCrypt.Net;
using BlogPostManager.Server.Enums;
using BlogPostManager.Server.IRepositories;
using BlogPostManager.Server.Authentication;
using BlogPostManager.Server.CustomExceptions;

namespace BlogPostManager.Server.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly TokenGenerator _generateToken;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _generateToken = new TokenGenerator();
    }

    public async Task<UserResponse> AddAsync(CreateUserRequest createUserRequest)
    {
        var userExist = await _userRepository.GetByEmailAsync(createUserRequest.Email);
        if (userExist is not null)
        {
            throw new BadRequestException("Email already Exists!");
        }
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(createUserRequest.Password);
        var newUser = new User()
        {
            UserName = createUserRequest.UserName,
            Email = createUserRequest.Email,
            PasswordHash = passwordHash,
            Role = Roles.User,
            CreatedAt = DateTime.UtcNow,
        };
        if (!await _userRepository.AddAsync(newUser))
        {
            throw new BadRequestException("An Error has occured while creating Account");
        }
        var token = _generateToken.GenerateJwtToken(newUser);
        return new UserResponse()
        {
            Id = newUser.Id,
            UserName = newUser.UserName,
            Token = token,
        };
    }
    public async Task<UserResponse> GetAsync(GetUserRequest getUserRequest)
    {
        var user = await _userRepository.GetByEmailAsync(getUserRequest.Email);
        if (user is null)
        {
            throw new NotFoundException("Email or Password is incorrect!");
        }
        if (!BCrypt.Net.BCrypt.Verify(getUserRequest.Password, user.PasswordHash))
        {
            throw new NotFoundException("Email or Password is incorrect!");
        }

        var token = _generateToken.GenerateJwtToken(user);
        return new UserResponse()
        {
            Id = user.Id,
            UserName = user.UserName,
            Token = token,
        };
    }
    public async Task<bool> UpdateAsync(UpdateUserRequest updateUserRequest)
    {
        var user = await _userRepository.GetAsync(updateUserRequest.Id);
        if (user is null)
        {
            throw new NotFoundException("User does not exist!");
        }
        user.UpdatedAt = DateTime.UtcNow;
        user.UserName = string.IsNullOrEmpty(updateUserRequest.UserName) ? user.UserName : updateUserRequest.UserName;
        return await _userRepository.UpdateAsync(user);

    }
    public async Task<bool> DeleteAsync(Guid Id)
    {
        var user = await _userRepository.GetAsync(Id);
        if (user is null)
        {
            throw new NotFoundException("User does not exist!");
        }
        return await _userRepository.DeleteAsync(user);
    }
}