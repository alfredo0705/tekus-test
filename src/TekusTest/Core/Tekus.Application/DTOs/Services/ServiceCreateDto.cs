using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekus.Application.DTOs.Services
{
    public class ServiceCreateDto
    {
        public string Name { get; set; }
        public decimal HourlyRate { get; set; }
        public int ProviderId { get; set; }
    }
}
