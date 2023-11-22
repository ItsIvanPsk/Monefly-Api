using MonefyWeb.DistributedServices.WebApi.Models;

namespace MonefyWeb.DomainServices.Models.Models
{
    public class AccountBe
    {
        public long AccountId { get; set; }
        public UserBe User { get; set; }
        public List<MovementBe> Movements { get; set; }
    }
}
