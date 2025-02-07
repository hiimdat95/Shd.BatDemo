using Abp.Application.Services;
using Abp.Domain.Uow;
using BatDemo.Entities;
using BatDemo.BankAccounts.Dto;
using BatDemo.Repositories.Gen.Read;
using BatDemo.Repositories.Gen.Write;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BatDemo.BankAccounts
{
    /// <summary>
    /// 
    /// </summary>
    public class BankAccountCrudService : ApplicationService, IBankAccountCrudService
    {
        private readonly IBankAccountWriteRepository _writeRepository;
        private readonly IBankAccountReadRepository _readRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="readRepository"></param>
        public BankAccountCrudService(IBankAccountReadRepository readRepository
                , IBankAccountWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IQueryable<BankAccount>> GetAllQueryableAsync()
        {
            return _readRepository.GetAllQueryableAsync();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [UnitOfWork(isTransactional: false)]
        public async Task<BankAccountCrudDto> GetDetailAsync(Guid id)
        {
            try
            {
                var entity = await _readRepository.GetAsync(id);
                if(entity != null)
                {
                    return ObjectMapper.Map<BankAccountCrudDto>(entity);
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
        public async Task<Guid?> CreateAsync(BankAccountCrudDto model)
        {
            try
            {
                var entity = ObjectMapper.Map<BankAccount>(model);
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
        public async Task<Guid?> UpdateAsync(BankAccountCrudDto model)
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