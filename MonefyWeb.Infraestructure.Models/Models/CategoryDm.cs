using System.ComponentModel.DataAnnotations;

namespace MonefyWeb.Infraestructure.Models
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

