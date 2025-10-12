using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.DTOs.Dashboard;

namespace Tekus.Application.Features.Dashboard.Requests.Queries
{
    public class GetProvidersByCountryQuery : IRequest<List<CountryCountDto>>
    {
    }
}
