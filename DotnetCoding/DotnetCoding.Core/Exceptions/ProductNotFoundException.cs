namespace DotnetCoding.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductNotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ProductNotFoundException(string message) : base(message)
        {
        }
    }
}