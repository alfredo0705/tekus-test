using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.Contracts.Persistence;
using Tekus.Domain.Entities;

namespace Tekus.Persistence.Repositories
{
    public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(TekusDbContext context) : base(context) { }
    }
}
