using AutoMapper;
using MediatR;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Providers;
using Tekus.Application.Features.Providers.Requests.Queries;
using Tekus.Application.Helpers;

namespace Tekus.Application.Features.Providers.Handlers.Queries
{
    public class GetAllProvidersQueryHandler : IRequestHandler<GetAllProvidersQuery, PagedList<ProviderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProvidersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<ProviderDto>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProviderRepository.GetAllWithDetailsAsync(request.Params);

            return _mapper.Map<PagedList<ProviderDto>>(result);

        }
    }
}
