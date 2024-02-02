namespace DotnetCoding.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        IProductRepository Products { get; }
        
        /// <summary>
        /// 
        /// </summary>
        IProductQueueRepository ProductQueues { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task BeginTransactionAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
        
        /// <summary>
        /// 
        /// </summary>
        void Rollback();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> Save();
    }
}
