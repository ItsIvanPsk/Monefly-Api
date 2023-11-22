using MonefyWeb.DistributedServices.Models.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace MonefyWeb.DistributedServices.Models.Models.Accounts
{
    public class AccountDto
    {
        [Key]
        public long AccountId { get; set; }
        public UserDto User { get; set; }
        public List<AccountMovementDto> Movements { get; set; }
    }
}