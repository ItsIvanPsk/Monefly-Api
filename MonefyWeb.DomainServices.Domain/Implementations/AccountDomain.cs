using AutoMapper;
using MonefyWeb.DistributedServices.Models.Models.Accounts;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.Infraestructure.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;
using MonefyWeb.Transversal.Aspects;

namespace MonefyWeb.DomainServices.Domain.Implementations
{
    public class AccountDomain : IAccountDomain
    {
        private readonly IAccountRepository _account;
        private readonly IMapper _mapper;
        private readonly Transversal.Utils.ILogger _log;

        public AccountDomain(
            IAccountRepository _account,
            Transversal.Utils.ILogger _log,
            IMapper mapper
        )
        {
            this._account = _account;
            this._log = _log;
            this._mapper = mapper;
        }

        [Log]
        public bool AddMovementToAccount(MovementDm movement)
        {
            return _account.AddMovementToAccount(movement);
        }

        [Log]
        public AccountDto GetAccountByUserId(long userId)
        {
            return _mapper.Map<AccountDto>(_account.GetAccountByUserId(userId));
        }

        [Log]
        public List<AccountMovementDto> GetMovementsByAccountId(long accountId)
        {
            return _mapper.Map<List<AccountMovementDto>>(_account.GetMovementsByAccountId(accountId));
        }
    }
}
