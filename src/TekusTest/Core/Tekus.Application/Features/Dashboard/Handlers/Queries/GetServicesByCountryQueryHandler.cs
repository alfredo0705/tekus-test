using MediatR;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Dashboard;
using Tekus.Application.Features.Dashboard.Requests.Queries;

namespace Tekus.Application.Features.Dashboard.Handlers.Queries
{
    public class GetServicesByCountryQueryHandler : IRequestHandler<GetServicesByCountryQuery, List<CountryCountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetServicesByCountryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CountryCountDto>> Handle(GetServicesByCountryQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DashboardRepository.GetServicesByCountry();
        }
    }
}
