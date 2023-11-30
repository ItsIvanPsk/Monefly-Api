using MonefyWeb.DistributedServices.Models.Models.Account_Configuration;
using MonefyWeb.Infraestructure.Models.Models;

namespace MonefyWeb.DomainServices.Domain.Contracts
{
    public interface IAccountConfigurationDomain
    {
        bool SetAccountConfiguration(AccountConfigurationBe config);

        AccountConfigurationBe GetAccountConfiguration(long AccountId);
    }
}
