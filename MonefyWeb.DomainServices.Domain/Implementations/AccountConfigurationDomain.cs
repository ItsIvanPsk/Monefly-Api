using AutoMapper;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.Infraestructure.Models.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;

namespace MonefyWeb.DomainServices.Domain.Implementations
{
    public class AccountConfigurationDomain : IAccountConfigurationDomain
    {
        private readonly IAccountConfigurationRepository _account;
        private readonly IMapper _mapper;
        private readonly Transversal.Utils.ILogger _log;

        public AccountConfigurationDomain(
            IAccountConfigurationRepository _account,
            Transversal.Utils.ILogger _log,
            IMapper mapper
        )
        {
            this._account = _account;
            this._log = _log;
            this._mapper = mapper;
        }

        public AccountConfigurationBe GetAccountConfiguration(long AccountId)
        {
            return _mapper.Map<AccountConfigurationBe>(_account.GetAccountConfiguration(AccountId));
        }

        public bool SetAccountConfiguration(AccountConfigurationBe config)
        {
            return _account.SetAccountConfiguration(_mapper.Map<AccountConfigurationDm>(config));
        }
    }
}
