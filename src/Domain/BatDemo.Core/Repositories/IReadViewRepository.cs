using System.Linq;
using System.Threading.Tasks;

namespace BatDemo.Repositories
{
    public interface IReadViewRepository
    {
        Task<IQueryable<TEntity>> GetViewAllQueryableAsync<TEntity>() where TEntity : class;
    }
}







