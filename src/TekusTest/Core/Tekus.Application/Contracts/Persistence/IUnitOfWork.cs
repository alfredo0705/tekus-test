using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekus.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IProviderRepository ProviderRepository { get; }
        IServiceRepository ServiceRepository { get; }

        Task SaveAsync();
        bool HasChanges();
    }
}
