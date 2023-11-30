namespace MonefyWeb.Infraestructure.Models.Models
{
    public class AccountsCurrenciesDm
    {
        public long AccountId { get; set; }
        public long CurrencyId { get; set; }
        public virtual AccountDm Account { get; set; }
        public virtual CurrencyDm Currency { get; set; }
    }
}
