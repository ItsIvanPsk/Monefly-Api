using MonefyWeb.DistributedServices.Models.Models.Accounts;
using MonefyWeb.DistributedServices.Models.Models.Movements;

namespace MonefyWeb.ApplicationServices.Application.Contracts
{
    public interface IAccountService
    {
        AccountDto GetAccountByUserId(long userId);
        List<MovementRequestDto> GetMovementsByAccountId(long accountId);
        bool AddMovementToAccount(MovementRequestDto movement);
        List<MovementDetailDto> GetMovementDetailData(long AccountId);
    }
}
