using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using BatDemo.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BatDemo.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class ReadRepository<TEntity, TPrimaryKey> : EfCoreRepositoryBase<BatDemoDbContext, TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
    {
        public readonly BatDemoDbContext _context;
        protected ReadRepository(IDbContextProvider<BatDemoDbContext> dbContextProvider, CustomizedReadOnlyDbContextFactory customDbContextFactory) : base(dbContextProvider)
        {
            _context = customDbContextFactory.CreateDbContext();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IQueryable<TEntity>> GetAllQueryableAsync()
        {
            return Task.FromResult(_context.Set<TEntity>().AsNoTracking());
        }
    }
    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="AbpProjectNameRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class ReadRepository<TEntity> : ReadRepository<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        protected ReadRepository(IDbContextProvider<BatDemoDbContext> dbContextProvider, CustomizedReadOnlyDbContextFactory customDbContextFactory)
            : base(dbContextProvider, customDbContextFactory)
        {
        }
        // Do not add any method here, add to the class above (since this inherits it)!!!
    }
}







