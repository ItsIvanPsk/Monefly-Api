using Microsoft.AspNetCore.Mvc;
using MonefyWeb.DistributedServices.Models.Models.Movements;

namespace MonefyWeb.DistributedServices.WebApi.Contracts
{
    public interface IAccountController
    {
        IActionResult GetAccountDataById([FromQuery] long UserId, [FromRoute] string version);

        IActionResult GetMovementsByAccountId([FromBody] long AccountId, [FromRoute] string version);

        IActionResult AddMovementToAccount([FromBody] MovementRequestDto movement, [FromRoute] string version);

        IActionResult GetMovementDetailData([FromBody] long AccountId, [FromRoute] string version);
    }
}