using MonefyWeb.Transversal.Models;

namespace MonefyWeb.DomainServices.Models.Models
{
    public class MovementBe
    {
        public long Movement_Id { get; set; }
        public long Account_Id { get; set; }
        public string Concept { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public EMovementType Type { get; set; }
        public EPaymentMethod PaymentMethod { get; set; }
        public long CategoryId { get; set; }
    }
}
