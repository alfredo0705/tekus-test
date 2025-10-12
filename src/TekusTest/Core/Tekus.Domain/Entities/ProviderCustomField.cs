using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekus.Domain.Entities
{
    public class ProviderCustomField
    {
        public int ProviderId { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public string FieldValue { get; set; } = string.Empty;

        public Provider Provider { get; set; } = null!;
    }
}
