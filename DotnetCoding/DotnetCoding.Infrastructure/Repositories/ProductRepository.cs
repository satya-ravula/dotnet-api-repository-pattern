using DotnetCoding.Core.Interfaces;
using DotnetCoding.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoding.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public ProductRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAll(ProductSearchRequest request)
        {
            var query = _dbContext.Products
                .Where(p => p.IsActive && (request == null ||
                                           (string.IsNullOrEmpty(request.ProductName) || p.Name.Contains(request.ProductName, StringComparison.OrdinalIgnoreCase)) &&
                                           (!request.MinPrice.HasValue || p.Price >= request.MinPrice.Value) &&
                                           (!request.MaxPrice.HasValue || p.Price <= request.MaxPrice.Value) &&
                                           (!request.MinPostedDate.HasValue || p.PostedDate >= request.MinPostedDate.Value) &&
                                           (!request.MaxPostedDate.HasValue || p.PostedDate <= request.MaxPostedDate.Value)))
                .OrderByDescending(p => p.PostedDate);

            return await query.ToListAsync();
        }
    }
}
