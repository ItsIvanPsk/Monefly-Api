namespace MonefyWeb.DomainServices.Models.Models.Users
{
    public class UserLoginResponseBe
    {
        public bool Status { get; set; } = false;
        public long UserId { get; set; }
        public long AccountId { get; set; }
    }
}
