namespace MonefyWeb.DomainServices.Models.Models.Users
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
