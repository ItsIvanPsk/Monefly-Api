using System.ComponentModel.DataAnnotations;
using MonefyWeb.Infraestructure.Models.Models.Accounts;

namespace MonefyWeb.Infraestructure.Models.Models.Users
{
    public class UserDm
    {
        public long Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<AccountDm> Accounts { get; set; }
        public ICollection<UsersCategoriesDm> UsersCategories { get; set; }
        public ICollection<UsersAccountsDm> UsersAccounts { get; set; }
    }
}