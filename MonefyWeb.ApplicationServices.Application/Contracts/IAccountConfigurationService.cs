using Microsoft.AspNetCore.Mvc;
using MonefyWeb.DistributedServices.Models.Models.Account_Configuration;
using MonefyWeb.DistributedServices.Models.Models.Accounts;
using MonefyWeb.DistributedServices.Models.Models.Movements;
using MonefyWeb.DomainServices.Domain.Contracts;

namespace MonefyWeb.ApplicationServices.Application.Contracts
{
    public interface IAccountConfigurationService
    {
        bool SetAccountConfiguration(AccountConfigurationDto config);

        AccountConfigurationDto GetAccountConfiguration(long AccountId);
    }
}
