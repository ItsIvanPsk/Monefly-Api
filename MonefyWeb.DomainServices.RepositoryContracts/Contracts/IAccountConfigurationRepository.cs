using MonefyWeb.Infraestructure.Models.Models;

namespace MonefyWeb.Infraestructure.Repository.Contracts
{
    public interface IAccountConfigurationRepository
    {
        bool SetAccountConfiguration(AccountConfigurationDm config);

        AccountConfigurationDm GetAccountConfiguration(long AccountId);
    }
}
