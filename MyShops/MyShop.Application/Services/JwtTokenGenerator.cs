using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using My_Shop.Core.Models;
using MyShop.Application.DTOs;

namespace MyShop.Application.Services;

// توضیحات برای خودم هست که بفهمم چیکار کردم

public class JwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Customer customer)
    {
        // خواندن تنظیمات JWT
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];
        var durationInMinutes = int.Parse(jwtSettings["DurationInMinutes"]);

        // ایجاد Claims
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, customer.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, customer.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // ایجاد امضای توکن
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        // ایجاد توکن
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(durationInMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}