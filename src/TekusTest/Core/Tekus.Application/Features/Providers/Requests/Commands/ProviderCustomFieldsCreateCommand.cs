using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.DTOs.Providers;
using Tekus.Application.Responses;

namespace Tekus.Application.Features.Providers.Requests.Commands
{
    public class ProviderCustomFieldsCreateCommand : IRequest<BaseCommandResponse>
    {
        public ProviderCustomFieldsCreateDto ProviderCustomField {  get; set; }
    }
}
