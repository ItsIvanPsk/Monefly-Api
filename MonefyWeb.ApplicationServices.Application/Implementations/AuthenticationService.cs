using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Users;

namespace MonefyWeb.ApplicationServices.Application.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string secretKey;

        public AuthenticationService(IConfiguration configuration)
        {
            secretKey = configuration.GetSection("JwtDemo").GetSection("SecretKey").ToString();
        }

        public string GenerateToken(UserLoginResponseDto user)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim("UserId", user.UserId.ToString()));
            claims.AddClaim(new Claim("AccountId", user.AccountId.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string createdToken = tokenHandler.WriteToken(tokenConfig);

            return createdToken;
        }
    }
}
