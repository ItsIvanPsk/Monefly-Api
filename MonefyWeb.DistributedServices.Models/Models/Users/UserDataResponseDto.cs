namespace MonefyWeb.DistributedServices.Models.Models.Users
{
    public class UserDataResponseDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
    }
}
