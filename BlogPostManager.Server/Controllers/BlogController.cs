using Microsoft.AspNetCore.Mvc;
using BlogPostManager.Server.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using BlogPostManager.Server.Models;
using BlogPostManager.Server.IServices;
namespace BlogPostManager.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;
    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }
    [HttpPost]
    public async Task<IActionResult> Add(CreateBlogRequest createBlogRequest)
    {
        return Ok(await _blogService.AddAsync(createBlogRequest));
    }

    [HttpGet("List")]
    public async Task<IActionResult> List()
    {
        return Ok(await _blogService.ListAsync());
    }
}