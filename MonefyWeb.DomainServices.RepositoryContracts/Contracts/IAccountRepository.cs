using MonefyWeb.DomainServices.Models.Models.Movements;
using MonefyWeb.Infraestructure.Models;
using MonefyWeb.Infraestructure.Models.Models.Accounts;

namespace MonefyWeb.Infraestructure.Repository.Contracts
{
    public interface IAccountRepository
    {
        bool AddMovementToAccount(MovementBe movement);
        AccountDm GetAccountByUserId(long userId);
        List<MovementDetailDm> GetMovementDetailData(long accountId);
        List<MovementDm> GetMovementsByAccountId(long accountId);
    }
}
