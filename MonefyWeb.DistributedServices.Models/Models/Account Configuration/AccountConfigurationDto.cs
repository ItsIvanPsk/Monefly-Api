namespace MonefyWeb.DistributedServices.Models.Models.Account_Configuration
{
    public class AccountConfigurationDto
    {
        public int AccountId { get; set; }
        public int CurrencyFormat { get; set; }
        public int CurrencyDefault { get; set; }
        public int FirstWeekDay { get; set; }
    }
}
