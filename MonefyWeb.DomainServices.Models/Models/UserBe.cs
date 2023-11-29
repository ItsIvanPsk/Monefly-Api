using System.Text.Json.Serialization;

namespace MonefyWeb.DistributedServices.WebApi.Models
{
    public class UserBe
    {
        public long Id { get; set; }
        public string Username { get; set; }

        public UserBe() { }

        public UserBe(long id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
