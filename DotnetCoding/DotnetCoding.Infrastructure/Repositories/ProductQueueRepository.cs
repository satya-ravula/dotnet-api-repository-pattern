using DotnetCoding.Core.Interfaces;
using DotnetCoding.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoding.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductQueueRepository : GenericRepository<ProductQueue>, IProductQueueRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ProductQueueRepository(DbContextClass context) : base(context)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductQueue>> GetAllQueues()
        {
            var query = _dbContext.ProductQueues
                .OrderBy(pq => pq.RequestDate)
                .AsQueryable();

            return await query.ToListAsync();
        }
    }
}