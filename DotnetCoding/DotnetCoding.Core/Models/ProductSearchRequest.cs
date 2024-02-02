namespace DotnetCoding.Core.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductSearchRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string? ProductName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal? MinPrice { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxPrice { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? MinPostedDate { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? MaxPostedDate { get; set; }
    }
}