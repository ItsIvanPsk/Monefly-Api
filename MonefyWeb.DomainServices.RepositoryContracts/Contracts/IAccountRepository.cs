using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Models;

namespace MonefyWeb.Infraestructure.Repository.Contracts
{
    public interface IAccountRepository
    {
        bool AddMovementToAccount(MovementDm movement);
        AccountDm GetAccountByUserId(long userId);
        List<MovementDm> GetMovementsByAccountId(long accountId);
    }
}
