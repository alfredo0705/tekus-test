using MediatR;
using Tekus.Application.DTOs.Providers;
using Tekus.Application.Responses;

namespace Tekus.Application.Features.Providers.Requests.Commands
{
    public class UpdateProviderCommand : IRequest<BaseCommandResponse>
    {
        public ProviderUpdateDto Provider { get; set; }
    }
}
