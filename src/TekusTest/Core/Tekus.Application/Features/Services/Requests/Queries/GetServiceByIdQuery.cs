using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.DTOs.Services;

namespace Tekus.Application.Features.Services.Requests.Queries
{
    public class GetServiceByIdQuery : IRequest<ServiceDto>
    {
        public int Id { get; set; }
    }
}
