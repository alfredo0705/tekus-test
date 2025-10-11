using MediatR;
using Tekus.Application.DTOs.Providers;

namespace Tekus.Application.Features.Providers.Requests.Queries
{
    public class GetProviderByIdQuery : IRequest<ProviderDto>
    {
        public int Id { get; set; }
    }
}
