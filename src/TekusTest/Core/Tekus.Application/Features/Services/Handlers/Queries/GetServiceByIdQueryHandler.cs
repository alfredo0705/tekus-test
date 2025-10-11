using AutoMapper;
using MediatR;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Services;
using Tekus.Application.Features.Services.Requests.Queries;

namespace Tekus.Application.Features.Services.Handlers.Queries
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, ServiceDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetServiceByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceDto> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ServiceRepository.GetByIdAsync(request.Id);

            return _mapper.Map<ServiceDto>(result);
        }
    }
}
