using Microsoft.AspNetCore.Mvc;
using MonefyWeb.DistributedServices.Models.Models.Account_Configuration;
using MonefyWeb.DistributedServices.Models.Models.Movements;

namespace MonefyWeb.DistributedServices.WebApi.Contracts
{
    public interface IAccountConfigurationController
    {
        IActionResult SetAccountConfiguration(AccountConfigurationDto config, string version);

        IActionResult GetAccountConfiguration(long AccountId, string version);
    }
}