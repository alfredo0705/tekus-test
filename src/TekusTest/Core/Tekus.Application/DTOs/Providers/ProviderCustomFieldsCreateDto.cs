using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekus.Application.DTOs.Providers
{
    public class ProviderCustomFieldsCreateDto
    {
        public int ProviderId { get; set; }
        public List<CustomFieldDto> Fields { get; set; } = new();
    }
}
