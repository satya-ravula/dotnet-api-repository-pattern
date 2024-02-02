using DotnetCoding.Core.Enumerations;
using DotnetCoding.Core.Exceptions;
using DotnetCoding.Core.Extensions;
using DotnetCoding.Core.Interfaces;
using DotnetCoding.Core.Models;
using DotnetCoding.Services.Interfaces;

namespace DotnetCoding.Services;

/// <summary>
/// 
/// </summary>
public class ProductQueueService : IProductQueueService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductService _productService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="productService"></param>
    public ProductQueueService(IUnitOfWork unitOfWork, IProductService productService)
    {
        _unitOfWork = unitOfWork;
        _productService = productService;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<ProductQueue>> GetAll()
    {
        try
        {
            var productQueues = await _unitOfWork.ProductQueues.GetAllQueues();
            return productQueues;
        }
        catch (Exception e)
        {
            // TODO: Log Exceptions
            throw;
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="ProductQueueNotFoundException"></exception>
    /// <exception cref="ProductNotFoundException"></exception>
    public async Task Approve(Guid id)
    {
        var productQueue = await _unitOfWork.ProductQueues.Get(id);
        if (productQueue == null)
        {
            throw new ProductQueueNotFoundException($"Product Queue with ID {id} not found");
        }
        
        var product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(productQueue.ProductData);
        if (product == null)
        {
            throw new ProductNotFoundException($"Product JSON Data Not found with Queue identifier {id}");   
        }
        
        try
        {
            await _unitOfWork.BeginTransactionAsync();
            
            var status = productQueue.Status.ToEnum<ProductQueueStatus>();
            if (status == ProductQueueStatus.Create)
            {
                await _productService.CreateProduct(product);
            }
            else if (status == ProductQueueStatus.Update)
            {
                await _productService.UpdateProduct(product);
            }
            else if(status == ProductQueueStatus.Delete)
            {
                await _productService.DeleteProduct(product.Id, false);
            }
            
            await _unitOfWork.ProductQueues.Delete(productQueue);
            await _unitOfWork.Save();

            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            // TODO: Log Exceptions
            _unitOfWork.Rollback();
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="ProductQueueNotFoundException"></exception>
    public async Task Reject(Guid id)
    {
        var productQueue = await _unitOfWork.ProductQueues.Get(id);
        if (productQueue == null)
        {
            throw new ProductQueueNotFoundException($"Product Queue with ID {id} not found");
        }
        
        try
        {
            await _unitOfWork.ProductQueues.Delete(productQueue);
            await _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            // TODO: Log Exceptions
            throw;
        }
    }
}