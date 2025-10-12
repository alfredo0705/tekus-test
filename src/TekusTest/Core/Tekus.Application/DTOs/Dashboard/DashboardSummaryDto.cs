namespace Tekus.Application.DTOs.Dashboard
{
    public class DashboardSummaryDto
    {
        public int TotalProviders { get; set; }
        public int TotalServices { get; set; }
        public List<CountryCountDto> ServicesByCountry { get; set; } = new();
        public List<CountryCountDto> ProvidersByCountry { get; set; } = new();
    }
}
