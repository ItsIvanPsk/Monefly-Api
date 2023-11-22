using AutoMapper;
using MonefyWeb.ApplicationService.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Users;
using MonefyWeb.DistributedServices.WebApi.Models;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.Transversal.Aspects;
using MonefyWeb.Transversal.Models;

namespace MonefyWeb.ApplicationService.Application.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserDomain _domain;
        private readonly IMapper _mapper;
        private readonly Transversal.Utils.ILogger _log;

        public UserService(IUserDomain _domain, Transversal.Utils.ILogger _log, IMapper mapper)
        {
            this._domain = _domain;
            this._log = _log;
            _mapper = mapper;
        }

        [Log]
        public UserLoginResponseDto LoginUser(LoginRequestDto request)
        {
            return _mapper.Map<UserLoginResponseDto>(_domain.LoginUser(request));
        }

        [Log]
        public UserRegisterResponseDto RegisterUser(RegisterRequestDto request)
        {
            return _mapper.Map<UserRegisterResponseDto>(_domain.RegisterUser(request));
        }

        public UserDataResponseDto GetUserData(long UserId)
        {
            return _mapper.Map<UserDataResponseDto>(_domain.GetUserData(UserId));
        }
    }
}
