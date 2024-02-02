using DotnetCoding.Core.Exceptions;
using DotnetCoding.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoding.Controllers
{
    /// <summary>
    /// ProductQueuesController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductQueuesController : ControllerBase
    {
        private readonly IProductQueueService _productQueueService;

        /// <summary>
        /// ProductQueuesController Constructor
        /// </summary>
        /// <param name="productQueueService">IProductQueueService</param>
        public ProductQueuesController(IProductQueueService productQueueService)
        {
            _productQueueService = productQueueService;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns>List of Product Queues</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var productQueues = await _productQueueService.GetAll();
                if (productQueues == null)
                {
                    return NotFound();
                }

                return Ok(productQueues);
            }
            catch (Exception e)
            {
                // TODO: Log Exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// ApproveProduct
        /// </summary>
        /// <param name="id">Queue Id</param>
        /// <returns></returns>
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveProduct(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Invalid Id");
                }

                // Process the approval logic
                await _productQueueService.Approve(id);
                return Ok("Product Approved Successfully");
            }
            catch (ProductQueueNotFoundException ex)
            {
                // TODO: Log Exception
                // Return a 404 status with a meaningful error message
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // TODO: Log Exception
                // Handle exceptions appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}/reject")]
        public async Task<IActionResult> RejectProduct(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Invalid Id");
                }

                await _productQueueService.Reject(id);
                return Ok("Product Rejected Successfully");
            }
            catch (Exception ex)
            {
                // TODO: Log Exception
                // Handle exceptions appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}