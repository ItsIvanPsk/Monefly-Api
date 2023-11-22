namespace MonefyWeb.DistributedServices.WebApi.Models
{
    public class UserBe
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public UserBe() { }

        public UserBe(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
