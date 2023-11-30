using MonefyWeb.Infraestructure.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace MonefyWeb.Infraestructure.Models
{
    public class CurrencyDm
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Symbol { get; set; }
        public virtual ICollection<MovementDm> Movements { get; set; }
        public virtual ICollection<AccountsCurrenciesDm> AccountsCurrencies { get; set; }
    }
}