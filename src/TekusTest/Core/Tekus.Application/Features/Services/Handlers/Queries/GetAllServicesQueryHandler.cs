using AutoMapper;
using MediatR;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Services;
using Tekus.Application.Features.Services.Requests.Queries;
using Tekus.Application.Helpers;

namespace Tekus.Application.Features.Services.Handlers.Queries
{
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, PagedList<ServiceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllServicesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<ServiceDto>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ServiceRepository.ListAllAsync(
                pageIndex: request.Params.PageNumber, 
                pageSize: request.Params.PageSize, 
                filter: p => p.Name.Contains(request.Params.SearchCriteria));

            return _mapper.Map<PagedList<ServiceDto>>(result);
        }
    }
}
