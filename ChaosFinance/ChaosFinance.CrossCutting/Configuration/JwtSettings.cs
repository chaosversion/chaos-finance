namespace ChaosFinance.CrossCutting.Configuration
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public int ExpirationDays { get; set; } = 3;
    }
}
