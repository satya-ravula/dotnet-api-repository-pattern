using Microsoft.EntityFrameworkCore;
using DotnetCoding.Core.Models;

namespace DotnetCoding.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Product> Products { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DbSet<ProductQueue> ProductQueues { get; set; }
    }
}
