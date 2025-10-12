using MediatR;
using Tekus.Application.DTOs.Dashboard;

namespace Tekus.Application.Features.Dashboard.Requests.Queries
{
    public class GetServicesByCountryQuery : IRequest<List<CountryCountDto>>
    {
    }
}
