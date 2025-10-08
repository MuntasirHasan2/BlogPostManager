using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BlogPostManager.Server.Entities;

namespace BlogPostManager.Server.Authentication;

public class TokenGenerator
{
    private readonly IConfiguration _configuration;
    public TokenGenerator()
    {
        var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        _configuration = builder.Build();
    }
    internal string GenerateJwtToken(User user)
    {

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenConfiguration:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.Id)),
            new Claim(ClaimTypes.Role,user.Role.ToString()),
        };
        var token = new JwtSecurityToken(
            issuer: _configuration["TokenConfiguration:Issuer"],
            audience: _configuration["TokenConfiguration:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}