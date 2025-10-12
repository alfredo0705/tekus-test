using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Dashboard;
using Tekus.Application.Features.Dashboard.Requests.Queries;

namespace Tekus.Application.Features.Dashboard.Handlers.Queries
{
    public class GetProvidersByCountryQueryHandler : IRequestHandler<GetProvidersByCountryQuery, List<CountryCountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProvidersByCountryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CountryCountDto>> Handle(GetProvidersByCountryQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DashboardRepository.GetProvidersByCountry();
        }
    }
}
