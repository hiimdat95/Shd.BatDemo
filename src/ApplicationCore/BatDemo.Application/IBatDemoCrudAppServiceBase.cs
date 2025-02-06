using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BatDemo
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TPageResultRequestDto"></typeparam>
    /// <typeparam name="TCreateDto"></typeparam>
    /// <typeparam name="TUpdateDto"></typeparam>
    public interface IBatDemoCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TPageResultRequestDto, TCreateDto, TUpdateDto> 
        : IAsyncCrudAppService<TEntityDto, TPrimaryKey, TPageResultRequestDto, TCreateDto, TUpdateDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TPageResultRequestDto : class
        where TCreateDto : class
        where TUpdateDto : IEntityDto<TPrimaryKey>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<TEntity>> GetAllQueryableAsync();
    }
}






