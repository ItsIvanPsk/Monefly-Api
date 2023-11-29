using MonefyWeb.Infraestructure.Models.Models;

namespace MonefyWeb.Infraestructure.Models
{
    public class AccountDm
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual UserDm User { get; set; }
        public virtual AccountConfigurationDm AccountConfiguration { get; set; }
        public virtual ICollection<MovementDm> Movements { get; set; }
        public virtual ICollection<UsersAccountsDm> UsersAccounts { get; set; }
        public virtual ICollection<AccountsCurrenciesDm> AccountsCurrencies { get; set; }
    }

}