using AutoMapper;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.DomainServices.Models.Models;
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
        public bool AddMovementToAccount(MovementBe movement)
        {
            return _account.AddMovementToAccount(movement);
        }

        [Log]
        public AccountBe GetAccountByUserId(long userId)
        {
            return _mapper.Map<AccountBe>(_account.GetAccountByUserId(userId));
        }

        public List<MovementDetailBe> GetMovementDetailData(long accountId)
        {
            return _mapper.Map<List<MovementDetailBe>>(_account.GetMovementDetailData(accountId));
        }

        [Log]
        public List<MovementBe> GetMovementsByAccountId(long accountId)
        {
            return _mapper.Map<List<MovementBe>>(_account.GetMovementsByAccountId(accountId));
        }
    }
}
