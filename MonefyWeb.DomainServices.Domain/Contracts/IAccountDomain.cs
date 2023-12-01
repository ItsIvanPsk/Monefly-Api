using MonefyWeb.DomainServices.Models.Models.Accounts;
using MonefyWeb.DomainServices.Models.Models.Movements;

namespace MonefyWeb.DomainServices.Domain.Contracts
{
    public interface IAccountDomain
    {
        bool AddMovementToAccount(MovementBe movement);
        AccountBe GetAccountByUserId(long userId);
        List<MovementDetailBe> GetMovementDetailData(long accountId);
        List<MovementBe> GetMovementsByAccountId(long accountId);
    }
}
