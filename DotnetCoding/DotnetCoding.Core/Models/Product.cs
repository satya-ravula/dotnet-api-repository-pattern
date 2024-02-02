namespace DotnetCoding.Core.Models
{
    /// <summary>
    /// Defines Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or Sets Product Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Gets or Sets Product Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or Sets Product Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or Sets Product Price
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Gets or Sets Product Posted date
        /// </summary>
        public DateTime PostedDate { get; set; }
        
        /// <summary>
        /// Gets or Sets Product IsActive state
        /// </summary>
        public bool IsActive { get; set; }
    }
}
