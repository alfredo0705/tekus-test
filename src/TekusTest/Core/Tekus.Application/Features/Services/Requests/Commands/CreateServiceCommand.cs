using MediatR;
using Tekus.Application.DTOs.Services;
using Tekus.Application.Responses;

namespace Tekus.Application.Features.Services.Requests.Commands
{
    public class CreateServiceCommand : IRequest<BaseCommandResponse>
    {
        public ServiceCreateDto Service { get; set; }
    }
}
