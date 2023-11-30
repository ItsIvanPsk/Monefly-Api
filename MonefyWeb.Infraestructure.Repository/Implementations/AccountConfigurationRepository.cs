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
                var existingAccount = _dbContext.AccountConfigurations.FirstOrDefault(a => a.AccountId == config.AccountId);
                if (existingAccount != null)
                {
                    existingAccount.CurrencyDefault = config.CurrencyDefault;
                    existingAccount.CurrencyFormat = config.CurrencyFormat;
                    existingAccount.FirstWeekDay = config.FirstWeekDay;
                    _dbContext.SaveChanges();
                    return true;
                } else
                {
                    var newAccountConfiguration = new AccountConfigurationDm
                    {
                        CurrencyDefault = config.CurrencyDefault,
                        CurrencyFormat = config.CurrencyFormat,
                        FirstWeekDay = config.FirstWeekDay,
                        AccountId = config.AccountId
                    };

                    _dbContext.AccountConfigurations.Add(newAccountConfiguration);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
