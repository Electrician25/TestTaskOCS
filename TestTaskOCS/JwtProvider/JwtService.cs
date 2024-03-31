using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TestTaskOCS.Interfaces;

namespace TestTaskOCS.JwtProvider
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptions _options;

        public JwtService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken()
        {
            var signing = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                signingCredentials: signing,
                expires: DateTime.UtcNow.AddHours(_options.ExpatisHours));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}