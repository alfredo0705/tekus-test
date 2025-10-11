using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Domain.Entities;

namespace Tekus.Application.Contracts.Persistence
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
    }
}
