using Tekus.Application.DTOs.Dashboard;

namespace Tekus.Application.Contracts.Persistence
{
    public interface IDashboardRepository
    {
        Task<DashboardSummaryDto> GetSummary();
    }
}
