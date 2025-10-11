using AutoMapper;
using MediatR;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Providers;
using Tekus.Application.Features.Providers.Requests.Queries;

namespace Tekus.Application.Features.Providers.Handlers.Queries
{
    public class GetAllProvidersQueryHandler : IRequestHandler<GetAllProvidersQuery, List<ProviderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProvidersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProviderDto>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProviderRepository.ListAllAsync();

            return _mapper.Map<List<ProviderDto>>(result.ToList());

        }
    }
}
