using DotnetCoding.Core.Models;
using DotnetCoding.Services.Interfaces;

namespace DotnetCoding.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductValidator : IProductValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="existingProduct"></param>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        public ProductValidationResult ValidateProductForUpdate(Product existingProduct, Product newProduct)
        {
            var validationResult = new ProductValidationResult { IsValid = true };

            ValidatePriceExceedsLimit(newProduct.Price, validationResult);

            if (validationResult.IsValid)
            {
                ValidatePriceIncreasedByMoreThanAllowedPercent(existingProduct.Price, newProduct.Price,
                    validationResult);
            }

            return validationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ProductValidationResult ValidateProductForCreate(Product product)
        {
            var validationResult = new ProductValidationResult { IsValid = true };
            ValidatePriceExceedsLimit(product.Price, validationResult);
            return validationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldPrice"></param>
        /// <param name="newPrice"></param>
        /// <param name="validationResult"></param>
        private void ValidatePriceIncreasedByMoreThanAllowedPercent(decimal oldPrice, decimal newPrice,
            ProductValidationResult validationResult)
        {
            if (newPrice > oldPrice * 1.5m)
            {
                validationResult.IsValid = false;
                validationResult.Message =
                    $"Exceeds 50% than older price. Old price: {oldPrice} and New price: {newPrice}";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        /// <param name="validationResult"></param>
        private void ValidatePriceExceedsLimit(decimal price, ProductValidationResult validationResult)
        {
            if (price > 5000)
            {
                validationResult.IsValid = false;
                validationResult.Message = $"Exceeds product price limit $5000. Requested price: {price}";
            }
        }
    }
}