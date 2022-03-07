
namespace BFY.Fatura.Configuration
{
    public class FaturaServiceConfiguration : IFaturaServiceConfiguration
    {
        public string BaseUrl { get; set; }
        public string Language { get; set; } = "tr";
        public string Currency { get; set; } = "TRY";
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public ServiceType ServiceType { get; set; } = ServiceType.Test;
    }
}
