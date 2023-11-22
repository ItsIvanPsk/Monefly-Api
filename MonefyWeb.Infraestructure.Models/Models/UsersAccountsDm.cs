namespace MonefyWeb.Infraestructure.Models
{
    public class UsersAccountsDm
    {
        public long UserId { get; set; }
        public long AccountId { get; set; }

        public UserDm User { get; set; }
        public AccountDm Account { get; set; }
    }

}
