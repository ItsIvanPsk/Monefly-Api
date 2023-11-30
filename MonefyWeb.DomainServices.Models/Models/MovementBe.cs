using MonefyWeb.Transversal.Models;

namespace MonefyWeb.DomainServices.Models.Models
{
    public class MovementBe
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string Concept { get; set; }
        public decimal Amount { get; set; }
        public DateTime MovementDate { get; set; }
        public EMovementType Type { get; set; }
        public EPaymentMethod PaymentMethod { get; set; }
        public long CategoryId { get; set; }
        public long CurrencyId { get; set; }
    }
}
