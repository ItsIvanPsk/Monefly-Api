using MonefyWeb.DomainServices.Models.Models.Movements;
using MonefyWeb.DomainServices.Models.Models.Users;

namespace MonefyWeb.DomainServices.Models.Models.Accounts
{
    public class AccountBe
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public UserBe User { get; set; }
        public List<MovementBe> Movements { get; set; }
    }
}
