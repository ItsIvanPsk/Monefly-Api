namespace MonefyWeb.Infraestructure.Models
{
    public class AccountDm
    {
        public long Id { get; set; }
        public long UserId { get; set; }

        public UserDm User { get; set; }
        public ICollection<MovementDm> Movements { get; set; }
        public ICollection<UsersAccountsDm> UsersAccounts { get; set; }
    }

}