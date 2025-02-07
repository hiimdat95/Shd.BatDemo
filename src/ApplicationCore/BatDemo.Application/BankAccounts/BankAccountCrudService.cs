using Abp.Application.Services;
using Abp.Domain.Uow;
using BatDemo.Entities;
using BatDemo.BankAccounts.Dto;
using BatDemo.Repositories.Gen.Read;
using BatDemo.Repositories.Gen.Write;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BatDemo.BankAccounts
{
    /// <summary>
    /// 
    /// </summary>
    public class BankAccountCrudService : BatDemoAppServiceBase, IBankAccountCrudService
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
                if (entity != null)
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
        public async Task<ServiceResponse<BankAccountCrudDto>> CreateAsync(BankAccountCrudDto model)
        {
            try
            {
                var resultValidate = await ValidateExitedAccountNumberAsync(model.AccountNumber);
                if (!resultValidate.Success)
                {
                    return BadRequestWithResult<BankAccountCrudDto>("400", resultValidate.Message);
                }
                var entity = ObjectMapper.Map<BankAccount>(model);
                var id = await _writeRepository.InsertAndGetIdAsync(entity);
                model.Id = id;

                return OkWithResult<BankAccountCrudDto>(model);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message.ToString(), ex);
                return ServerErrorWithResult<BankAccountCrudDto>("500", ex.Message.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [UnitOfWork(isTransactional: false)]
        public async Task<ServiceResponse> ValidateExitedAccountNumberAsync(string accountNumber)
        {
            try
            {
                var lstBankAccount = await _readRepository.GetAllListAsync(x => x.AccountNumber == accountNumber && !x.IsDeleted);
                if (lstBankAccount.Any())
                {
                    return BadRequest("400", "Accout number has been exited. Please input other account number");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message.ToString(), ex);
                return ServerError("500", ex.Message.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [UnitOfWork(isTransactional: false)]
        public async Task<ServiceResponse<BankAccountCrudDto>> UpdateAsync(BankAccountCrudDto model)
        {
            try
            {
                var entity = await _readRepository.GetAsync(model.Id.Value);
                if (entity == null)
                {
                    return NotFoundWithResult<BankAccountCrudDto>("404", "Not found");
                }
                if (!model.AccountNumber.Equals(entity.AccountNumber))
                {
                    var resultValidate = await ValidateExitedAccountNumberAsync(model.AccountNumber);
                    if (!resultValidate.Success)
                    {
                        return BadRequestWithResult<BankAccountCrudDto>("400", resultValidate.Message);
                    }
                }

                ObjectMapper.Map(model, entity);
                using (var unitOfWork = UnitOfWorkManager.Begin())
                {
                    var id = await _writeRepository.InsertOrUpdateAndGetIdAsync(entity);
                    model.Id = id;
                    await UnitOfWorkManager.Current.SaveChangesAsync();
                    await unitOfWork.CompleteAsync();
                    return OkWithResult<BankAccountCrudDto>(model);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message.ToString(), ex);
                return ServerErrorWithResult<BankAccountCrudDto>("500", ex.Message.ToString());
            }
        }
    }
}