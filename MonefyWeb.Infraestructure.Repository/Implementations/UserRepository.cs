using Microsoft.EntityFrameworkCore;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;
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

        public UserRegisterResponseBe RegisterUser(RegisterRequestDto request)
        {
            var response = new UserRegisterResponseBe();
            try
            {
                var userEntity = new UserDm
                {
                    Username = request.Name,
                    Password = request.Password,
                    Email = request.Email,
                };

                _dbContext.Users.Add(userEntity);
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
