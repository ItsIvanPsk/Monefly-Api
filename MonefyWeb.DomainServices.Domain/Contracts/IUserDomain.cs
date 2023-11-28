using MonefyWeb.DistributedServices.Models.Models.Users;
using MonefyWeb.Transversal.Models;

namespace MonefyWeb.DomainServices.Domain.Contracts
{
    public interface IUserDomain
    {
        UserLoginResponseDto LoginUser(LoginRequestDto request);
        UserRegisterResponseDto RegisterUser(RegisterRequestDto request);
        UserDataResponseDto GetUserData(long userId);
    }
}
