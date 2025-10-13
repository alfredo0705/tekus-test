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
using Tekus.Application.Helpers;

namespace Tekus.Application.Features.Providers.Handlers.Queries
{
    public class GetAllProvidersListQueryHandler : IRequestHandler<GetAllProvidersListQuery, List<ProviderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProvidersListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProviderDto>> Handle(GetAllProvidersListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProviderRepository.GetAllProvidersList();

            return _mapper.Map<List<ProviderDto>>(result);
        }
    }
}
