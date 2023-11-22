using System.ComponentModel.DataAnnotations;

namespace MonefyWeb.Infraestructure.Models
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