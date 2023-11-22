using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Models;

namespace MonefyWeb.Infraestructure.Repository.Contracts
{
    public interface IAccountRepository
    {
        bool AddMovementToAccount(MovementDm movement);
        AccountBe GetAccountByUserId(long userId);
        List<MovementBe> GetMovementsByAccountId(long accountId);
    }
}
