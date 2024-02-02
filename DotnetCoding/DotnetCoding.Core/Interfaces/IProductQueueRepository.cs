using DotnetCoding.Core.Models;

namespace DotnetCoding.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProductQueueRepository : IGenericRepository<ProductQueue>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductQueue>> GetAllQueues();
    }
}