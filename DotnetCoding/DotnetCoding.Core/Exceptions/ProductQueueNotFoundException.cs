namespace DotnetCoding.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductQueueNotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ProductQueueNotFoundException(string message) : base(message)
        {
        }
    }
}