using DotnetCoding.Core.Models;

namespace DotnetCoding.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProductQueueService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductQueue>> GetAll();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Approve(Guid id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Reject(Guid id);
    }
}