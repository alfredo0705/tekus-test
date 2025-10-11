using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Providers;
using Tekus.Application.Features.Providers.Requests.Queries;

namespace Tekus.Application.Features.Providers.Handlers.Queries
{
    public class GetProviderByIdQueryHandler : IRequestHandler<GetProviderByIdQuery, ProviderDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProviderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProviderDto> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProviderRepository.GetByIdAsync(request.Id);

            return _mapper.Map<ProviderDto>(result);
        }
    }
}
