using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Users;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.Transversal.Aspects;
using MonefyWeb.Transversal.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MonefyWeb.ApplicationServices.Application.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserDomain _domain;
        private readonly IMapper _mapper;
        private readonly Transversal.Utils.ILogger _log;
        private readonly string secretKey;

        public UserService(IUserDomain _domain, Transversal.Utils.ILogger _log, IMapper mapper, IConfiguration configuration)
        {
            this._domain = _domain;
            this._log = _log;
            _mapper = mapper;
            secretKey = configuration.GetSection("JwtDemo").GetSection("SecretKey").ToString();
        }

        [Log]
        public UserLoginResponseDto LoginUser(LoginRequestDto request)
        {
            var result = _domain.LoginUser(request);
            return _mapper.Map<UserLoginResponseDto>(result);
        }

        [Log]
        public UserRegisterResponseDto RegisterUser(RegisterRequestDto request)
        {
            return _mapper.Map<UserRegisterResponseDto>(_domain.RegisterUser(request));
        }

        public UserDataResponseDto GetUserData(long UserId)
        {
            var result = _mapper.Map<UserDataResponseDto>(_domain.GetUserData(UserId));
            if (result != new UserDataResponseDto() || result != null)
            {
                var keyBytes = Encoding.UTF8.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.Username));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string createdToken = tokenHandler.WriteToken(tokenConfig);

                return result;
            }
            return result;
        }
    }
}