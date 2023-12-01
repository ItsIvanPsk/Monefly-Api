using System.ComponentModel.DataAnnotations;
using MonefyWeb.Infraestructure.Models.Models.Users;

namespace MonefyWeb.Infraestructure.Models.Models.Categories
{
    public class CategoryDm
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Icon { get; set; }

        [Required]
        public int Type { get; set; }

        public ICollection<MovementDm> Movements { get; set; }
        public ICollection<UsersCategoriesDm> UsersCategories { get; set; }
    }

}

