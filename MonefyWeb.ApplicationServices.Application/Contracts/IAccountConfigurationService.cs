using MonefyWeb.DistributedServices.Models.Models.Account_Configuration;

namespace MonefyWeb.ApplicationServices.Application.Contracts
{
    public interface IAccountConfigurationService
    {
        bool SetAccountConfiguration(AccountConfigurationDto config);

        AccountConfigurationDto GetAccountConfiguration(long AccountId);
    }
}
