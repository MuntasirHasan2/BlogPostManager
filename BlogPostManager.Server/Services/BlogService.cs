using BlogPostManager.Server.Entities;
using BlogPostManager.Server.Models;
using BlogPostManager.Server.IServices;
using BlogPostManager.Server.IRepositories;
using BlogPostManager.Server.CustomExceptions; 

namespace BlogPostManager.Server.Services;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _blogRepository;
    public BlogService(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
    public async Task<bool> AddAsync(CreateBlogRequest createBlogRequest)
    {
        Blog blog = new Blog()
        {
            Id = createBlogRequest.Id,
            Title = createBlogRequest.Title,
            Description = createBlogRequest.Description,
            CategoryId = createBlogRequest.CategoryId,
            Content = createBlogRequest.Content,
            MainImage = createBlogRequest.MainImage,
            Images = createBlogRequest.Images,
            CreationDate = DateTime.UtcNow,
            UserId = createBlogRequest.UserId
        };
        return await _blogRepository.AddAsync(blog);
    }
    public async Task<BlogResponse> GetAsync(int id)
    {
        var blog = await _blogRepository.GetAsync(id);
        if (blog == null)
        {
            throw new NotFoundException("Blog does not exist!");
        }
        return ToDTO(blog);
    }
    public async Task<List<BlogResponse>> ListAsync()
    {
        var blogList = await _blogRepository.ListAsync();
        List<BlogResponse> list = new List<BlogResponse>();
        foreach (var blog in blogList)
        {
            list.Add(ToDTO(blog));
        }
        return list;
    }
    public async Task<List<BlogResponse>> ListByUserIdAsync(Guid UserId)
    {
        var blogList = await _blogRepository.ListByUserIdAsync(UserId);
        List<BlogResponse> list = new List<BlogResponse>();
        foreach (var blog in blogList)
        {
            list.Add(ToDTO(blog));
        }
        return list;
    }
    public async Task<List<BlogResponse>> ListByCategoryAsync(int CategoryId)
    {
        var blogList = await _blogRepository.ListByCategoryAsync(CategoryId);
        List<BlogResponse> list = new List<BlogResponse>();
        foreach (var blog in blogList)
        {
            list.Add(ToDTO(blog));
        }
        return list;
    }
    public async Task<bool> UpdateAsync(UpdateBlogRequest updateBlogRequest)
    {
        var blog = await _blogRepository.GetAsync(updateBlogRequest.Id);
        if (blog is null)
        {
            throw new NotFoundException("Blog cannot be found!");
        }
        blog.Title = string.IsNullOrEmpty(updateBlogRequest.Title) ? blog.Title : updateBlogRequest.Title;
        blog.Description =  string.IsNullOrEmpty(updateBlogRequest.Description) ? blog.Description : updateBlogRequest.Description;
        blog.Content = string.IsNullOrEmpty(updateBlogRequest.Content) ? blog.Content : updateBlogRequest.Content;
        blog.UpdatedDate = DateTime.Now;

        return await _blogRepository.UpdateAsync(blog);

    }
    public async Task<bool> DeleteAsync(int id)
    {
        var blog = await _blogRepository.GetAsync(id);
        if (blog is null)
        {
            throw new NotFoundException("Blog cannot be found!");
        }
        return await _blogRepository.DeleteAsync(blog);
    }

    private BlogResponse ToDTO(Blog blog)
    {
        var LastModifiedDate = blog.UpdatedDate != null ? blog.UpdatedDate : blog.CreationDate;
        return new BlogResponse()
        {
            Id = blog.Id,
            Title = blog.Title,
            Description = blog.Description,
            CategoryId = blog.CategoryId,
            Content = blog.Content,
            MainImage = blog.MainImage,
            LastModifiedDate = LastModifiedDate,
            UserId = blog.UserId,
        };
    }
}

