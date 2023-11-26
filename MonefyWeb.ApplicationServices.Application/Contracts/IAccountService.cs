using MonefyWeb.DistributedServices.Models.Models.Movements;
using MonefyWeb.DomainServices.Models.Models;

namespace MonefyWeb.ApplicationServices.Application.Contracts
{
    public interface IAccountService
    {
        AccountBe GetAccountByUserId(long userId);
        List<MovementBe> GetMovementsByAccountId(long accountId);
        bool AddMovementToAccount(MovementRequestDto movement);
    }
}
