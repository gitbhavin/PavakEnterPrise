namespace PVK.DTO.Account
{
    public class AccountResponse
    {
        public string Userid { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Expiration { get; set; }
        public bool Status { get; set; }

    }
}
