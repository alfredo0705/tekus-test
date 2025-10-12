using Tekus.Application.DTOs.Dashboard;

namespace Tekus.Application.Contracts.Persistence
{
    public interface IDashboardRepository
    {
        Task<DashboardSummaryDto> GetSummary();
        Task<List<CountryCountDto>> GetServicesByCountry();
        Task<List<CountryCountDto>> GetProvidersByCountry();
    }
}
