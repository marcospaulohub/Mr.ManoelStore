namespace Mr.ManoelStore.Auth
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = "MrManoelStore";
        public string Audience { get; set; } = "MrManoelClients";
        public int ExpirationMinutes { get; set; } = 60;
    }
}
