using AutoMapper;
using MediatR;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Services;
using Tekus.Application.Features.Services.Requests.Queries;

namespace Tekus.Application.Features.Services.Handlers.Queries
{
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, List<ServiceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllServicesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ServiceDto>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ServiceRepository.ListAllAsync();

            return _mapper.Map<List<ServiceDto>>(result.ToList());
        }
    }
}
