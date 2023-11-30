using AutoMapper;
using Microsoft.Extensions.Configuration;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Users;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.Transversal.Aspects;
using MonefyWeb.Transversal.Models;

namespace MonefyWeb.ApplicationServices.Application.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserDomain _domain;
        private readonly IMapper _mapper;
        private readonly Transversal.Utils.ILogger _log;

        public UserService(IUserDomain _domain, Transversal.Utils.ILogger _log, IMapper mapper, IConfiguration configuration)
        {
            this._domain = _domain;
            this._log = _log;
            _mapper = mapper;
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

        [Log]
        public UserDataResponseDto GetUserData(long UserId)
        {
            return _mapper.Map<UserDataResponseDto>(_domain.GetUserData(UserId));
        }
    }
}