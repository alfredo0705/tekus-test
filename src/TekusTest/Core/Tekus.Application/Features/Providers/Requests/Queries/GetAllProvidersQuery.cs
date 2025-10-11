using MediatR;
using Tekus.Application.DTOs.Providers;

namespace Tekus.Application.Features.Providers.Requests.Queries
{
    public class GetAllProvidersQuery : IRequest<List<ProviderDto>>
    {
    }
}
