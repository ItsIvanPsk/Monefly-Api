namespace MonefyWeb.DomainServices.Domain.Contracts
{
    public interface IAccountConfigurationDomain
    {
        bool SetAccountConfiguration(AccountConfigurationBe config);

        AccountConfigurationBe GetAccountConfiguration(long AccountId);
    }
}
