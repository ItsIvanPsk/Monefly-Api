using MonefyWeb.DistributedServices.Models.Models.Accounts;
using MonefyWeb.Infraestructure.Models;

namespace MonefyWeb.DomainServices.Domain.Contracts
{
    public interface IAccountDomain
    {
        bool AddMovementToAccount(MovementDm movement);
        AccountDto GetAccountByUserId(long userId);
        List<AccountMovementDto> GetMovementsByAccountId(long accountId);
    }
}
