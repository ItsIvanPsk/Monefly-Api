using Microsoft.EntityFrameworkCore;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Models;
using MonefyWeb.Infraestructure.Models.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;
using MonefyWeb.Transversal.Exceptions;
using MonefyWeb.Transversal.Models;
using System.Data.SqlTypes;

namespace MonefyWeb.Infraestructure.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserDataResponseBe GetUserData(long UserId)
        {
            var userData = new UserDataResponseBe();
            var account = GetAccountData(UserId);

            decimal gastos = account.Movements.Where(m => m.Type == 1).Sum(m => m.Amount);
            decimal ingresos = account.Movements.Where(m => m.Type == 2).Sum(m => m.Amount);

            userData.Id = account.User.Id;
            userData.Username = account.User.Username;
            userData.Email = account.User.Email;
            userData.Balance = ingresos - gastos;

            return userData;
        }

        public UserLoginResponseBe LoginUser(LoginRequestDto request)
        {
            var response = new UserLoginResponseBe();
            var user = _dbContext.Users
                .Where(u => u.Username == request.Name && u.Password == request.Password)
                .Select(c => new UserDm
                {
                    Id = c.Id,
                    Username = c.Username,
                    Password = c.Password,
                }).FirstOrDefault();

            if (user == null)
                return response;


            var accountId = _dbContext.UsersAccounts
                .Where(ua => ua.UserId == user.Id)
                .Select(ua => new AccountDm
                {
                    Id = ua.AccountId
                }).FirstOrDefault();

            if (accountId == null)
                return null;


            response.Status = user.Id > 0;
            response.UserId = user.Id;
            response.AccountId = accountId.Id;

            return response;
        }

        private List<CategoryDm> GetRandomCategories(List<CategoryDm> categories)
        {
            int numberOfRandomCategories = 3;

            var random = new Random();

            var randomIndices = new List<int>();
            while (randomIndices.Count < numberOfRandomCategories)
            {
                int randomIndex = random.Next(0, categories.Count);
                if (!randomIndices.Contains(randomIndex))
                {
                    randomIndices.Add(randomIndex);
                }
            }
            return randomIndices.Select(index => categories[index]).ToList();

        }

        private List<UsersCategoriesDm> GetUserCategories(List<CategoryDm> categories, long UserId)
        {
            var usersCategories = new List<UsersCategoriesDm>();

            foreach (var category in categories)
            {
                usersCategories.Add(new UsersCategoriesDm
                {
                    UserId = UserId,
                    CategoryId = category.Id,
                });
            }

            return usersCategories;
        }

        private List<AccountsCurrenciesDm> GetAccountCurrencies(List<CurrencyDm> currencies, long AccountId)
        {
            var AccountCurrencies = new List<AccountsCurrenciesDm>();

            foreach (var currency in currencies)
            {
                AccountCurrencies.Add(new AccountsCurrenciesDm
                {
                    AccountId = AccountId,
                    CurrencyId = currency.Id
                });
            }

            return AccountCurrencies;
        }

        private List<UsersAccountsDm> GetUserAccounts(long UserId, long AccountId)
        {
            var accounts = new List<UsersAccountsDm>
            {
                new UsersAccountsDm
                {
                    AccountId = AccountId,
                    UserId = UserId
                }
            };

            return accounts;
        }

        public UserRegisterResponseBe RegisterUser(RegisterRequestDto request)
        {
            var response = new UserRegisterResponseBe();
            try
            {
                var categories = GetRandomCategories(_dbContext.Categories.ToList());
                var userCategories = GetRandomCategories(categories);

                if (!userCategories.Any())
                    throw new UserRegistrationException(nameof(userCategories));

                var userEntity = new UserDm
                {
                    Username = request.Name,
                    Password = request.Password,
                    Email = request.Email,
                };

                if (userEntity is null)
                    throw new UserRegistrationException(nameof(userEntity));

                _dbContext.Users.Add(userEntity);
                _dbContext.SaveChanges();

                userEntity.UsersCategories = GetUserCategories(userCategories, userEntity.Id);

                if (userEntity.UsersCategories is null)
                    throw new UserRegistrationException(nameof(userEntity));

                var accountEntity = new List<AccountDm>
                {
                    new AccountDm
                    {
                        UserId = userEntity.Id,
                        Name = request .Name + "'s account",
                        CreationDate = DateTime.Now
                    }
                };

                if (!accountEntity.Any())
                    throw new UserRegistrationException(nameof(accountEntity));

                _dbContext.Accounts.Add(accountEntity.First());
                _dbContext.SaveChanges();

                var currencies = _dbContext.Currencies.Select(c => new CurrencyDm { Id = c.Id, Name = c.Name, Symbol = c.Symbol }).ToList();

                var accountsCurrencies = GetAccountCurrencies(currencies, accountEntity.First().Id);

                if (!accountsCurrencies.Any())
                    throw new UserRegistrationException(nameof(accountsCurrencies));

                var accountConfiguration = new AccountConfigurationDm
                {
                    CurrencyDefault = 1,
                    CurrencyFormat = 1,
                    AccountId = accountEntity.First().Id,
                    FirstWeekDay = 1
                };

                if (accountConfiguration is null)
                    throw new UserRegistrationException(nameof(accountConfiguration));

                var usersAccounts = GetUserAccounts(userEntity.Id, accountEntity.First().Id);

                if (usersAccounts is null)
                    throw new UserRegistrationException(nameof(usersAccounts));

                userEntity.UsersAccounts = usersAccounts;
                userEntity.Accounts = accountEntity;

                _dbContext.Users.Add(userEntity);
                _dbContext.Accounts.Add(accountEntity.First());
                _dbContext.UsersAccounts.Add(usersAccounts.First());
                _dbContext.SaveChanges();

                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;
            }
            return response;
        }

        public AccountDm GetAccountData(long UserId)
        {
            var account = _dbContext.Accounts
                .Include(a => a.User)
                    .Include(a => a.Movements)
                    .FirstOrDefault(a => a.User.Id == UserId);

            if (account != null)
            {
                var userAccount = new AccountDm
                {
                    Id = account.Id,
                    User = new UserDm
                    {
                        Id = account.User.Id,
                        Username = account.User.Username,
                        Email = account.User.Email
                    },
                    Movements = account.Movements.Select(m => new MovementDm
                    {
                        Id = m.Id,
                        AccountId = m.AccountId,
                        Concept = m.Concept,
                        Amount = m.Amount,
                        Date = m.Date,
                        Type = m.Type,
                        PaymentMethod = m.PaymentMethod,
                        CategoryId = m.CategoryId
                    }).ToList()
                };
            }
            else
            {
                throw new SqlNullValueException(nameof(UserId));
            }
            return account;
        }
    }
}
