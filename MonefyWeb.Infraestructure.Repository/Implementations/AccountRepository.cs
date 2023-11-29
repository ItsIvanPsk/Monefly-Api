using Microsoft.EntityFrameworkCore;
using MonefyWeb.DistributedServices.WebApi.Models;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;
using MonefyWeb.Transversal.Aspects;
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
        public bool AddMovementToAccount(MovementDm movement)
        {
            var dateTime = DateTime.Now;
            var movementEntity = new MovementDm
            {
                Id = movement.Id,
                AccountId = movement.AccountId,
                Concept = movement.Concept,
                Amount = movement.Amount,
                Date = dateTime,
                Type = movement.Type,
                PaymentMethod = movement.PaymentMethod,
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
