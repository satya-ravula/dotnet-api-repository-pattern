using DotnetCoding.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace DotnetCoding.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        private IDbContextTransaction _transaction;

        /// <summary>
        /// 
        /// </summary>
        public IProductRepository Products { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public IProductQueueRepository ProductQueues { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="productRepository"></param>
        /// <param name="productQueueRepository"></param>
        public UnitOfWork(DbContextClass dbContext, IProductRepository productRepository, IProductQueueRepository productQueueRepository)
        {
            _dbContext = dbContext;
            Products = productRepository;
            ProductQueues = productQueueRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                _transaction.Dispose();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
