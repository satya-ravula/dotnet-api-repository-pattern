using DotnetCoding.Models;
using DotnetCoding.Core.Models;

namespace DotnetCoding.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ProductRequestExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Product ToProduct(this ProductCreateUpdateRequest request)
        {
            return request.ToProduct(Guid.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Product ToProduct(this ProductCreateUpdateRequest request, Guid id)
        {
            return new Product
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };
        }
    }
}