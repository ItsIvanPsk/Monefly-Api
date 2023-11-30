using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Models;

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
