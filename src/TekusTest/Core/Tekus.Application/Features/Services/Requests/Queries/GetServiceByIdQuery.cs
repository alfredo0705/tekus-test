using MediatR;
using Tekus.Application.DTOs.Services;

namespace Tekus.Application.Features.Services.Requests.Queries
{
    public class GetServiceByIdQuery : IRequest<ServiceDto>
    {
        public int Id { get; set; }
    }
}
