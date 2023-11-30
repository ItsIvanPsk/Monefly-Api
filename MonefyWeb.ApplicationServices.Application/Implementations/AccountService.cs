using AutoMapper;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Accounts;
using MonefyWeb.DistributedServices.Models.Models.Movements;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Transversal.Aspects;

namespace MonefyWeb.ApplicationServices.Application.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDomain _domain;
        private readonly IMapper _mapper;
        private readonly Transversal.Utils.ILogger _log;

        public AccountService(IAccountDomain _domain, Transversal.Utils.ILogger _log, IMapper mapper)
        {
            this._domain = _domain;
            this._log = _log;
            _mapper = mapper;
        }

        [Log]
        public bool AddMovementToAccount(MovementRequestDto accountId)
        {
            return _domain.AddMovementToAccount(_mapper.Map<MovementBe>(accountId));
        }

        [Log]
        public AccountDto GetAccountByUserId(long userId)
        {
            return _mapper.Map<AccountDto>(_domain.GetAccountByUserId(userId));
        }

        [Log]
        public List<MovementRequestDto> GetMovementsByAccountId(long accountId)
        {
            return _mapper.Map<List<MovementRequestDto>>(_domain.GetMovementsByAccountId(accountId));
        }
    }
}
