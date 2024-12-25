using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyShop.Domain.Models;

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
        try
        {
            // خواندن تنظیمات JWT
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"] ?? throw new InvalidOperationException("JWT Key is not configured"));
            var issuer = jwtSettings["Issuer"] ?? "DefaultIssuer";
            var audience = jwtSettings["Audience"] ?? "DefaultAudience";
            var durationInMinutes = int.TryParse(jwtSettings["DurationInMinutes"], out var duration) ? duration : 60;

            // ایجاد Claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, customer.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, customer.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Customer") // افزودن نقش
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
        catch (Exception ex)
        {
            // مدیریت خطاها
            throw new InvalidOperationException("An error occurred while generating the JWT token.", ex);
        }
    }
}
