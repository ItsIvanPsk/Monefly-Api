using System.Text.Json.Serialization;

namespace MonefyWeb.DistributedServices.Models.Models.Users
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
