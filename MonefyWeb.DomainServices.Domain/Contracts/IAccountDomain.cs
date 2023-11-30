using MonefyWeb.DistributedServices.Models.Models.Accounts;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Models;

namespace MonefyWeb.DomainServices.Domain.Contracts
{
    public interface IAccountDomain
    {
        bool AddMovementToAccount(MovementBe movement);
        AccountBe GetAccountByUserId(long userId);
        List<MovementBe> GetMovementsByAccountId(long accountId);
    }
}
