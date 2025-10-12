using MediatR;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Dashboard;
using Tekus.Application.Features.Dashboard.Requests.Queries;

namespace Tekus.Application.Features.Dashboard.Handlers.Queries
{
    public class GetDashboardSummaryQueryHandler : IRequestHandler<GetDashboardSummaryQuery, DashboardSummaryDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDashboardSummaryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DashboardSummaryDto> Handle(GetDashboardSummaryQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DashboardRepository.GetSummary();
        }
    }
}
