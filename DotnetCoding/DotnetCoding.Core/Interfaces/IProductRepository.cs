using DotnetCoding.Core.Models;

namespace DotnetCoding.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProductRepository : IGenericRepository<Product>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetAll(ProductSearchRequest request);
    }
}
