using MonefyWeb.DistributedServices.WebApi.Models;

namespace MonefyWeb.DomainServices.Models.Models
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
