using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Model;

namespace UserService.Helpers
{
    public class TokenHelper
    {
        public string GenerateToken(User u)
        {
            // Define security key and credentials
            var secretKey = "!@$#@%WEFSEFD^$%#$%^^%^&$E$%SDFDFY$%$%#$^";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Add claims
            var claims = new[]
            {
            new Claim("usernmame", u.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
//user.wheelfactory.net
//order.whellfactory.net
            // Create token
            var token = new JwtSecurityToken(
                issuer: "wheelfactory",
                audience: "wheelfactory",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            // Return token string
            return new JwtSecurityTokenHandler().WriteToken(token);

            
        }
    }
}
