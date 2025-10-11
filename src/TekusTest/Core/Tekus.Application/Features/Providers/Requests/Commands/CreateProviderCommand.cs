using MediatR;
using Tekus.Application.DTOs.Providers;
using Tekus.Application.Responses;

namespace Tekus.Application.Features.Providers.Requests.Commands
{
    public class CreateProviderCommand : IRequest<BaseCommandResponse>
    {
        public ProviderCreateDto Provider { get; set; }
    }
}
