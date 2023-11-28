using MonefyWeb.DistributedServices.Models.Models.Users;

namespace MonefyWeb.ApplicationServices.Application.Contracts
{
    public interface IAuthenticationService
    {
        string GenerateToken(UserLoginResponseDto user);
    }
}
