using AutoMapper;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Account_Configuration;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.Transversal.Aspects;

namespace MonefyWeb.ApplicationServices.Application.Implementations
{
    public class AccountConfigurationService : IAccountConfigurationService
    {
        private readonly IAccountConfigurationDomain _domain;
        private readonly IMapper _mapper;
        private readonly Transversal.Utils.ILogger _log;

        public AccountConfigurationService(IAccountConfigurationDomain _domain, Transversal.Utils.ILogger _log, IMapper _mapper)
        {
            this._domain = _domain;
            this._log = _log;
            this._mapper = _mapper;
        }

        [Log]
        public AccountConfigurationDto GetAccountConfiguration(long AccountId)
        {
            return _mapper.Map<AccountConfigurationDto>(_domain.GetAccountConfiguration(AccountId));
        }

        [Log]
        public bool SetAccountConfiguration(AccountConfigurationDto config)
        {
            return _domain.SetAccountConfiguration(_mapper.Map<AccountConfigurationBe>(config));
        }
    }
}
