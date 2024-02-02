using DotnetCoding.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using DotnetCoding.Models;
using DotnetCoding.Core.Models;
using DotnetCoding.Extensions;
using DotnetCoding.Services.Interfaces;

namespace DotnetCoding.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ProductSearchRequest request = null)
        {
            try
            {
                var products = await _productService.GetAllProducts(request);
                if(products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception e)
            {
                // TODO: Log Exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                await _productService.CreateProduct(request.ToProduct());
                // Return simple 201 Created status without content
                return Created(string.Empty, null);
            }
            catch (Exception ex)
            {
                // TODO: Log Exception
                return StatusCode(500, "Internal Server Error");
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] ProductCreateUpdateRequest request)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Invalid Id");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _productService.UpdateProduct(request.ToProduct(id));
                return Ok("Product Updated Successfully");
            }
            catch (ProductNotFoundException ex)
            {
                // Log the exception if needed
                // Return a 404 status with a meaningful error message
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Invalid Id");
                }

                await _productService.DeleteProduct(id);
                return Ok("Product Deleted Successfully");
            }
            catch (ProductNotFoundException ex)
            {
                // Log the exception if needed
                // Return a 404 status with a meaningful error message
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
