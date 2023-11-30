using MonefyWeb.DistributedServices.Models.Models.Users;

namespace MonefyWeb.DistributedServices.Models.Models.Accounts
{
    public class AccountDto
    {
        public long Id { get; set; }
        public UserDto User { get; set; }
        public List<AccountMovementDto> Movements { get; set; }
    }
}