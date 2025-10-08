
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using BlogPostManager.Server.IRepositories;
using BlogPostManager.Server.Repositories;
using BlogPostManager.Server.Services;
using BlogPostManager.Server.IServices;
using BlogPostManager.Server.GlobalException;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5173");
        });
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionHandler>();
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<IBlogService, BlogService>();

var configuration = builder.Configuration;
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["TokenConfiguration:Issuer"],
            ValidAudience = configuration["TokenConfiguration:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenConfiguration:SecretKey"])),
            RoleClaimType = ClaimTypes.Role
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
