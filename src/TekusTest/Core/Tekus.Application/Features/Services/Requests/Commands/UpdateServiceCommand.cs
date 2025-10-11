using MediatR;
using Tekus.Application.DTOs.Services;
using Tekus.Application.Responses;

namespace Tekus.Application.Features.Services.Requests.Commands
{
    public class UpdateServiceCommand : IRequest<BaseCommandResponse>
    {
        public ServiceUpdateDto Service { get; set; }
    }
}
