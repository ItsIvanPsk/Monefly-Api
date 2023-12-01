using MonefyWeb.Infraestructure.Models.Models.Categories;

namespace MonefyWeb.Infraestructure.Models.Models.Users
{
    public class UsersCategoriesDm
    {
        public long UserId { get; set; }
        public long CategoryId { get; set; }

        public UserDm User { get; set; }
        public CategoryDm Category { get; set; }
    }
}
