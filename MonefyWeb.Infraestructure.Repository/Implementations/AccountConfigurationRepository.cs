using Microsoft.EntityFrameworkCore;
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
        public AccountConfigurationDm GetAccountConfiguration(long AccountId)
        {
            var result = new AccountConfigurationDm();

            _dbContext.Set<AccountConfigurationDm>()
                .Select(ac => new AccountConfigurationDm
                {
                    CurrencyFormat = ac.CurrencyFormat,
                    CurrencyDefault = ac.CurrencyDefault,
                    FirstDayOfWeek = ac.FirstDayOfWeek,
                    AccountId = ac.AccountId
                })
                .Where(ac => ac.AccountId == AccountId);

            return result;
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
                            FirstDayOfWeek = config.FirstDayOfWeek,
                            AccountId = config.AccountId
                        };
                    } else
                    {
                        existingAccount.AccountConfiguration.CurrencyFormat = config.CurrencyFormat;
                        existingAccount.AccountConfiguration.CurrencyDefault = config.CurrencyDefault;
                        existingAccount.AccountConfiguration.FirstDayOfWeek = config.FirstDayOfWeek;
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
