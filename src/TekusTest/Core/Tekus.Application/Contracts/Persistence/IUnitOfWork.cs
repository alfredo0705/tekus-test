namespace Tekus.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IProviderRepository ProviderRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IDashboardRepository DashboardRepository { get; }

        Task SaveAsync();
        bool HasChanges();
    }
}
