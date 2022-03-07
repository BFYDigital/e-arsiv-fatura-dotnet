namespace BFY.Fatura.Configuration
{
    public interface IFaturaServiceConfiguration
    {
        string BaseUrl { get; set; }
        string Currency { get; set; }
        string Language { get; set; }
        string Password { get; set; }
        ServiceType ServiceType { get; set; }
        string Token { get; set; }
        string Username { get; set; }
    }
}