using MediatR;
using Tekus.Application.DTOs.Services;

namespace Tekus.Application.Features.Services.Requests.Queries
{
    public class GetAllServicesQuery : IRequest<List<ServiceDto>>
    {
    }
}
