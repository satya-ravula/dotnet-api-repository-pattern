using System.ComponentModel.DataAnnotations;

namespace DotnetCoding.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductCreateUpdateRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Range(0, 10000, ErrorMessage = "Product Price cannot be exceeded $10000")]
        public decimal Price { get; set; }
    }
}