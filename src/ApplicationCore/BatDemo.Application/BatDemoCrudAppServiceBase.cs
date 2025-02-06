using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using BatDemo.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace BatDemo
{
    public abstract class BatDemoCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TPageResultRequestDto, TCreateDto, TUpdateDto>
        : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TPageResultRequestDto, TCreateDto, TUpdateDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TPageResultRequestDto : class
        where TCreateDto : class
        where TUpdateDto : IEntityDto<TPrimaryKey>
    {
        private readonly IReadRepository<TEntity, TPrimaryKey> _readRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="readRepository"></param>
        protected BatDemoCrudAppServiceBase(
            IRepository<TEntity, TPrimaryKey> repository,
            IReadRepository<TEntity, TPrimaryKey> readRepository
            ) : base(repository)
        {
            _readRepository = readRepository;
        }

        /* Write data
         * Sửa dụng các hàm base CUD Repository base mặc định của ABP
         */




        /* Read data
         * Sử dụng Respository Readonly
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [UnitOfWork(isTransactional: false)]
        public override async Task<TEntityDto> GetAsync(EntityDto<TPrimaryKey> input)
        {
            CheckGetPermission();

            var entity = await GetEntityByIdAsync(input.Id);
            return MapToEntityDto(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IQueryable<TEntity>> GetAllQueryableAsync()
        {
            CheckGetAllPermission();

            var query = _readRepository.GetAllQueryableAsync();
            return query;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<PagedResultDto<TEntityDto>> GetAllAsync(TPageResultRequestDto input)
        {
            CheckGetAllPermission();

            var query = await _readRepository.GetAllAsync();

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TEntityDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }
        protected override Task<TEntity> GetEntityByIdAsync(TPrimaryKey id)
        {
            return _readRepository.GetAsync(id);
        }
    }
}








