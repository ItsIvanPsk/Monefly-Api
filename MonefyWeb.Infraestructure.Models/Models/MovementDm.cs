using System.ComponentModel.DataAnnotations;

namespace MonefyWeb.Infraestructure.Models
{
    public class MovementDm
    {
        public long Id { get; set; }
        public long AccountId { get; set; }

        [Required]
        public string Concept { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public int PaymentMethod { get; set; }

        [Required]
        public long CategoryId { get; set; }
        public long CurrencyId { get; set; }

        public virtual AccountDm Account { get; set; }
        public virtual CategoryDm Category { get; set; }
        public virtual CurrencyDm Currency { get; set; }
    }
}
