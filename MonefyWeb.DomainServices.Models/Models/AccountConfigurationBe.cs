namespace MonefyWeb.DomainServices.Domain.Contracts
{
    public class AccountConfigurationBe
    {
        public int AccountId { get; set; }
        public int CurrencyFormat { get; set; }
        public int CurrencyDefault { get; set; }
        public int FirstWeekDay { get; set; }
    }
}