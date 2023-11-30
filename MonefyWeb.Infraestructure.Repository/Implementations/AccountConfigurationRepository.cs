using Microsoft.EntityFrameworkCore;
using MonefyWeb.DistributedServices.WebApi.Models;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Models;
using MonefyWeb.Infraestructure.Models.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;
using MonefyWeb.Transversal.Aspects;
using System.Data.SqlTypes;

namespace MonefyWeb.Infraestructure.Repository.Implementations
{
    public class AccountConfigurationRepository : IAccountConfigurationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountConfigurationRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [Log]
        [Timer]
        public AccountConfigurationDm GetAccountConfiguration(long accountId)
        {
            var result = new AccountConfigurationDm();

            var accountConfiguration = _dbContext.AccountConfigurations
                .Where(ac => ac.AccountId == accountId)
                .Select(ac => new AccountConfigurationDm
                {
                    Id = ac.Id,
                    AccountId = ac.AccountId,
                    CurrencyDefault = ac.CurrencyDefault,
                    CurrencyFormat = ac.CurrencyFormat,
                    FirstWeekDay = ac.FirstWeekDay
                })
                .FirstOrDefault();

            if (accountConfiguration != null)
            {
                return accountConfiguration;
            }
            else
            {
                throw new Exception("No account configuration associated with given account id has been found!");
            }
        }

        [Log]
        [Timer]
        public bool SetAccountConfiguration(AccountConfigurationDm config)
        {
            try
            {
                var existingAccount = _dbContext.Accounts.FirstOrDefault(a => a.Id == config.AccountId);

                if (existingAccount != null)
                {
                    if (existingAccount.AccountConfiguration == null)
                    {
                        existingAccount.AccountConfiguration = new AccountConfigurationDm
                        {
                            CurrencyDefault = config.CurrencyDefault,
                            CurrencyFormat = config.CurrencyFormat,
                            FirstWeekDay = config.FirstWeekDay,
                            AccountId = config.AccountId
                        };
                    } else
                    {
                        existingAccount.AccountConfiguration.CurrencyFormat = config.CurrencyFormat;
                        existingAccount.AccountConfiguration.CurrencyDefault = config.CurrencyDefault;
                        existingAccount.AccountConfiguration.FirstWeekDay = config.FirstWeekDay;
                    }

                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return false;
        }
    }
}
