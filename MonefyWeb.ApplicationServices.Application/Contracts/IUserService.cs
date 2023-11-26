using MonefyWeb.DistributedServices.Models.Models.Users;
using MonefyWeb.DistributedServices.WebApi.Models;
using MonefyWeb.Transversal.Models;

namespace MonefyWeb.ApplicationServices.Application.Contracts
{
    public interface IUserService
    {
        UserLoginResponseDto LoginUser(LoginRequestDto request);
        UserRegisterResponseDto RegisterUser(RegisterRequestDto request);
        UserDataResponseDto GetUserData(long userId);
    }
}
