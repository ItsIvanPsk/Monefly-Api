using Microsoft.EntityFrameworkCore;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;
using MonefyWeb.Transversal.Aspects;
using MonefyWeb.Transversal.Models;
using System.Data.SqlTypes;

namespace MonefyWeb.Infraestructure.Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [Log]
        public bool AddMovementToAccount(MovementBe movement)
        {
            var movementEntity = new MovementDm
            {
                Id = movement.Id,
                AccountId = movement.AccountId,
                Concept = movement.Concept,
                Amount = movement.Amount,
                Date = movement.MovementDate,
                Type = (int)movement.Type,
                PaymentMethod = (int)movement.PaymentMethod,
                CategoryId = movement.CategoryId,
                CurrencyId = movement.CurrencyId
            };

            _dbContext.Movements.Add(movementEntity);
            _dbContext.SaveChanges();

            return true;
        }

        [Log]
        public AccountDm GetAccountByUserId(long userId)
        {
            var account = _dbContext.Accounts
                .Include(a => a.User)
                .Include(a => a.Movements)
                .FirstOrDefault(a => a.User.Id == userId);

            if (account != null)
            {
                return new AccountDm
                {
                    Id = account.Id,
                    Name = account.Name,
                    User = new UserDm
                    {
                        Id = account.User.Id,
                        Username = account.User.Username
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
                        CategoryId = m.CategoryId,
                        CurrencyId = m.CurrencyId
                    }).ToList()
                };
            }
            else
            {
                throw new SqlNullValueException(nameof(userId));
            }
        }

        public List<MovementDetailDm> GetMovementDetailData(long accountId)
        {
            var result = new List<MovementDetailDm>();
            var movements = _dbContext.Movements
                .Where(m => m.AccountId == accountId).ToList();

            foreach (var movement in movements)
            {
                result.Add(new MovementDetailDm
                {
                    Amount = movement.Amount,
                    MovementDate = movement.Date,
                    Type = (EMovementType)movement.Type,
                    Concept = movement.Concept,
                    PaymentMethod = (EPaymentMethod)movement.PaymentMethod,
                    CategoryId = movement.CategoryId,
                    CategoryName = _dbContext.Categories.Where(c => c.Id == accountId).Select(c => c.Name).First(),
                    CurrencyId = movement.CurrencyId
                });
            }

            return result;
        }

        [Log]
        public List<MovementDm> GetMovementsByAccountId(long userId)
        {
            var accountId = _dbContext.Accounts
                .Where(a => a.UserId == userId)
                .Select(a => a.UserId)
                .FirstOrDefault();

            if (accountId != 0)
            {
                var movements = _dbContext.Movements
                    .Where(m => m.AccountId == accountId)
                    .Select(m => new MovementDm
                    {
                        Id = m.Id,
                        AccountId = m.Account.Id,
                        Concept = m.Concept,
                        Amount = m.Amount,
                        Date = m.Date,
                        Type = m.Type,
                        PaymentMethod = m.PaymentMethod,
                        CategoryId = m.Category.Id
                    })
                    .ToList();

                return movements;
            }
            else
            {
                throw new Exception("No user associated account has been found!");
            }
        }
    }
}
