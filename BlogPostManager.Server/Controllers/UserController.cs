using Microsoft.AspNetCore.Mvc;
using BlogPostManager.Server.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using BlogPostManager.Server.Models;
using BlogPostManager.Server.IServices;
namespace BlogPostManager.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateUserRequest createUserRequest)
    {
        return Ok(await _userService.AddAsync(createUserRequest));
    }

    [Authorize(Roles = "Admin,User")]
    [HttpGet]
    public async Task<IActionResult> GetUser(GetUserRequest getUserRequest)
    {
        return Ok(await _userService.GetAsync(getUserRequest));
    }

    [Authorize(Roles = "Admin,User")]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserRequest updateUserRequest)
    {
        if (await _userService.UpdateAsync(updateUserRequest))
        {
            return Ok("Updated");
        }
        return BadRequest("An Error has occured while deleting!");
    }

    [Authorize(Roles = "Admin,User")]
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _userService.DeleteAsync(id))
        {
            return NoContent();
        }
        return BadRequest("An Error has occured while deleting!");
    }
}