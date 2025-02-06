using Abp.EntityFrameworkCore;
using BatDemo.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace BatDemo.EntityFrameworkCore.Repositories
{
    public class ReadViewRepository : IReadViewRepository
    {
        private readonly BatDemoDbContext _context;
        public ReadViewRepository(IDbContextProvider<BatDemoDbContext> dbContextProvider, CustomizedReadOnlyDbContextFactory customReadOnlyDbContextFactory)
        {
            _context = customReadOnlyDbContextFactory.CreateDbContext();
        }

        public Task<IQueryable<TEntity>> GetViewAllQueryableAsync<TEntity>() where TEntity : class
        {
            return Task.FromResult(_context.Set<TEntity>().AsQueryable());
        }
    }
}







