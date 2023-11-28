using Microsoft.AspNetCore.Mvc;
using MonefyWeb.Transversal.Models;

namespace MonefyWeb.DistributedServices.WebApi.Contracts
{
    public interface IUserController
    {
        IActionResult GetUserData([FromRoute] string version, [FromRoute] long UserId);
        IActionResult Login([FromRoute] string version, LoginRequestDto request);
        IActionResult Register([FromRoute] string version, RegisterRequestDto request);
    }
}