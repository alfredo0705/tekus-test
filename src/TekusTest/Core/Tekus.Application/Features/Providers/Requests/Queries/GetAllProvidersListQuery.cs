using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.DTOs.Providers;

namespace Tekus.Application.Features.Providers.Requests.Queries
{
    public class GetAllProvidersListQuery : IRequest<List<ProviderDto>>
    {
    }
}
