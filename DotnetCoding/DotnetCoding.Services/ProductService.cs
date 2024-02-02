
using DotnetCoding.Core.Enumerations;
using DotnetCoding.Core.Exceptions;
using DotnetCoding.Core.Interfaces;
using DotnetCoding.Core.Models;
using DotnetCoding.Services.Interfaces;

namespace DotnetCoding.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductValidator _productValidator;

        public ProductService(IUnitOfWork unitOfWork, IProductValidator productValidator)
        {
            _unitOfWork = unitOfWork;
            _productValidator = productValidator;
        }

        public async Task<IEnumerable<Product>> GetAllProducts(ProductSearchRequest request)
        {
            try
            {
                var products = await _unitOfWork.Products.GetAll(request);
                return products;
            }
            catch (Exception ex)
            {
                // TODO: Log Exceptions
                throw;
            }
        }

        public async Task<Product> GetProduct(Guid id)
        {
            try
            {
                var product = await _unitOfWork.Products.Get(id);
                return product;
            }
            catch (Exception ex)
            {
                // TODO: Log Exceptions
                throw;
            }
        }

        public async Task CreateProduct(Product product)
        {
            try
            {
                var validationResult = _productValidator.ValidateProductForCreate(product);
                if (validationResult.IsValid)
                {
                    product.Id = Guid.NewGuid();
                    product.IsActive = true;
                    product.PostedDate = DateTime.UtcNow;
                    await _unitOfWork.Products.Add(product);
                    await _unitOfWork.Save();
                }
                else
                {
                    var productQueue = BuildProductQueue(product, ProductQueueStatus.Create, validationResult.Message);
                    await _unitOfWork.ProductQueues.Add(productQueue);
                    await _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                // TODO: Log Exceptions
                throw;
            }
        }

        public async Task UpdateProduct(Product product)
        {
            var existingProduct = await _unitOfWork.Products.Get(product.Id);
            if (existingProduct == null)
            {
                throw new ProductNotFoundException($"Product with ID {product.Id} not found");
            }
            
            try
            {
                var validationResult = _productValidator.ValidateProductForUpdate(existingProduct, product);
                if (validationResult.IsValid)
                {
                    product.IsActive = validationResult.IsValid;
                    product.PostedDate = DateTime.UtcNow;
                    await _unitOfWork.Products.Update(product);
                    await _unitOfWork.Save();
                }
                else
                {
                    var productQueue = BuildProductQueue(product, ProductQueueStatus.Update, validationResult.Message);
                    await _unitOfWork.ProductQueues.Add(productQueue);
                    await _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                // TODO: Log Exceptions
                throw;
            }
        }
        
        public async Task DeleteProduct(Guid id, bool approvalNeeded = true)
        {
            var existingProduct = await _unitOfWork.Products.Get(id);
            if (existingProduct == null)
            {
                throw new ProductNotFoundException($"Product with ID {id} not found");
            }
            
            try
            {
                if (approvalNeeded) //Approval needed
                {
                    var productQueue = BuildProductQueue(existingProduct, ProductQueueStatus.Delete, $"Delete product approval request");
                    await _unitOfWork.ProductQueues.Add(productQueue);
                    await _unitOfWork.Save();
                }
                else
                {
                    await _unitOfWork.Products.Delete(existingProduct);
                    await _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                // TODO: Log Exceptions
                throw;
            }
        }

        private static ProductQueue BuildProductQueue(Product product, ProductQueueStatus status, string reason)
        {
            var productQueue = new ProductQueue
            {
                Id = Guid.NewGuid(),
                ProductName = product.Name,
                ProductData = Newtonsoft.Json.JsonConvert.SerializeObject(product),
                RequestDate = DateTime.UtcNow,
                RequestReason = reason,
                Status = status.ToString(),
            };
            return productQueue;
        }
    }
}
