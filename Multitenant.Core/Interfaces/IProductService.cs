using Multitenant.Core.Entities;

namespace Multitenant.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(string name, string description, int rate, CancellationToken cancellationToken = default);
        Task<Product> GetByIdAsync(Guid id, CancellationToken cancellation = default);
        Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
