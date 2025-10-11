using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.DTOs.Services;
using Tekus.Application.Responses;

namespace Tekus.Application.Features.Services.Requests.Commands
{
    public class UpdateServiceCommand : IRequest<BaseCommandResponse>
    {
        public ServiceUpdateDto Service { get; set; }
    }
}
