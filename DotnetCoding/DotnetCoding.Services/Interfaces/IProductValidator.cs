using DotnetCoding.Core.Models;

namespace DotnetCoding.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProductValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="existingProduct"></param>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        ProductValidationResult ValidateProductForUpdate(Product existingProduct, Product newProduct);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        ProductValidationResult ValidateProductForCreate(Product product);
    }
}