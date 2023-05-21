using Multitenant.Core.Entities;
using Multitenant.Core.Interfaces;
using Multitenant.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Multitenant.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(string name, string description, int rate, CancellationToken cancellationToken = default)
        {
            var product = new Product(name, description, rate);
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FindAsync(id, cancellationToken);
        }
    }
}
