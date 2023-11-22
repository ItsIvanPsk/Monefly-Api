namespace MonefyWeb.DomainServices.Models.Models
{
    public class UserDataResponseBe
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
    }
}
