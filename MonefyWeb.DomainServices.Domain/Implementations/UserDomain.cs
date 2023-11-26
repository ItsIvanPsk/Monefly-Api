using AutoMapper;
using MonefyWeb.DistributedServices.Models.Models.Users;
using MonefyWeb.DistributedServices.WebApi.Models;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.Infraestructure.Repository.Contracts;
using MonefyWeb.Transversal.Models;

namespace MonefyWeb.DomainServices.Domain.Implementations
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _user;
        private readonly IMapper _mapper;
        private readonly Transversal.Utils.ILogger _log;

        public UserDomain(
            IUserRepository _user,
            Transversal.Utils.ILogger _log,
            IMapper mapper
        )
        {
            this._user = _user;
            this._log = _log;
            this._mapper = mapper;
        }

        public UserLoginResponseDto LoginUser(LoginRequestDto request)
        {
            var result = _user.LoginUser(request);
            return _mapper.Map<UserLoginResponseDto>(result);
        }

        public UserRegisterResponseDto RegisterUser(RegisterRequestDto request)
        {
            return _mapper.Map<UserRegisterResponseDto>(_user.RegisterUser(request));
        }

        public UserDataResponseDto GetUserData(long userId)
        {
            return _mapper.Map<UserDataResponseDto>(_user.GetUserData(userId));
        }
    }
}
