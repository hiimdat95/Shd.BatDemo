using Abp.Application.Services;
using Abp.Domain.Uow;
using BatDemo.Entities;
using BatDemo.Accounts.Dto;
using BatDemo.Repositories.Gen.Read;
using BatDemo.Repositories.Gen.Write;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BatDemo.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountCrudService : ApplicationService, IAccountCrudService
    {
        private readonly IAccountWriteRepository _writeRepository;
        private readonly IAccountReadRepository _readRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="readRepository"></param>
        public AccountCrudService(IAccountReadRepository readRepository
                , IAccountWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IQueryable<Account>> GetAllQueryableAsync()
        {
            return _readRepository.GetAllQueryableAsync();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [UnitOfWork(isTransactional: false)]
        public async Task<AccountCrudDto> GetDetailAsync(Guid id)
        {
            try
            {
                var entity = await _readRepository.GetAsync(id);
                if(entity != null)
                {
                    return ObjectMapper.Map<AccountCrudDto>(entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message.ToString(), ex);
                return null;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [UnitOfWork(isTransactional: false)]
        public async Task<Guid?> CreateAsync(AccountCrudDto model)
        {
            try
            {
                var entity = ObjectMapper.Map<Account>(model);
                var id = await _writeRepository.InsertAndGetIdAsync(entity);
                return id;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message.ToString(), ex);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [UnitOfWork(isTransactional: false)]
        public async Task<Guid?> UpdateAsync(AccountCrudDto model)
        {
            try
            {
                var entity = await _readRepository.GetAsync(model.Id.Value);
                if(entity == null)
                {
                    return null;
                }
                ObjectMapper.Map(model, entity);
                using (var unitOfWork = UnitOfWorkManager.Begin())
                {
                    await _writeRepository.InsertOrUpdateAndGetIdAsync(entity);
                    await UnitOfWorkManager.Current.SaveChangesAsync();
                    await unitOfWork.CompleteAsync();
                    return entity.Id;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message.ToString(), ex);
                return null;
            }
        }
    }
}