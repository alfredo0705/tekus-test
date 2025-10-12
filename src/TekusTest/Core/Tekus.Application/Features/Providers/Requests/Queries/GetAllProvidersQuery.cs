using MediatR;
using Tekus.Application.DTOs.Providers;
using Tekus.Application.Helpers;

namespace Tekus.Application.Features.Providers.Requests.Queries
{
    public class GetAllProvidersQuery : IRequest<PagedList<ProviderDto>>
    {
        public PaginationParams Params { get; set; }
    }
}
