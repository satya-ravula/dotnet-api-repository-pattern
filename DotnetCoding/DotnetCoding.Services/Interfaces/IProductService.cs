using DotnetCoding.Core.Models;

namespace DotnetCoding.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetAllProducts(ProductSearchRequest request);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProduct(Guid id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task CreateProduct(Product product);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task UpdateProduct(Product product);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="approvalNeeded"></param>
        /// <returns></returns>
        Task DeleteProduct(Guid id, bool approvalNeeded = true);
    }
}
