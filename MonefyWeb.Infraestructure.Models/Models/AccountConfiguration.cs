namespace MonefyWeb.Infraestructure.Models.Models
{
    public class AccountConfiguration
    {
        public long Id { get; set; }
        public int CurrencyFormat { get; set; }
        public int CurrencyDefault { get; set; }
        public int FirstWeekDay { get; set; }
        public long AccountId { get; set; }
        public AccountDm Account { get; set; }
    }
}
