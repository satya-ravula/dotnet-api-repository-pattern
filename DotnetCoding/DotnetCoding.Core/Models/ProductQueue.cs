namespace DotnetCoding.Core.Models
{
    /// <summary>
    /// Defines Product Queue
    /// </summary>
    public class ProductQueue
    {
        /// <summary>
        /// Gets or Sets Queue Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Gets or Sets Product Name
        /// </summary>
        public string ProductName { get; set; }
        
        /// <summary>
        /// Gets or Sets full product details JSON to hold all new product data
        /// </summary>
        public string ProductData { get; set; }

        /// <summary>
        /// Gets or Sets Requested Reason
        /// </summary>
        public string RequestReason { get; set; }

        /// <summary>
        /// Gets or Sets Requested Date
        /// </summary>
        public DateTime RequestDate { get; set; }
        
        /// <summary>
        /// Gets or Sets Queue Status - CREATE, UPDATE, DELETE
        /// </summary>
        public string Status { get; set; }
    }
}