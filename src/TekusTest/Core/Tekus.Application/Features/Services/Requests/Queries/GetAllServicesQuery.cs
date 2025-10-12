using MediatR;
using Tekus.Application.DTOs.Services;
using Tekus.Application.Helpers;

namespace Tekus.Application.Features.Services.Requests.Queries
{
    public class GetAllServicesQuery : IRequest<PagedList<ServiceDto>>
    {
        public PaginationParams Params { get; set; }
    }
}
