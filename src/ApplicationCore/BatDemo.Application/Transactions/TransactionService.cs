using Abp.Application.Services;
using Abp.Domain.Uow;
using BatDemo.Entities;
using BatDemo.Transactions.Dto;
using BatDemo.Repositories.Gen.Read;
using BatDemo.Repositories.Gen.Write;
using System;
using System.Linq;
using System.Threading.Tasks;
using static BatDemo.Utils.Enums.TransactionEnum;
using BatDemo.Utils.Enums;

namespace BatDemo.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionService : BatDemoAppServiceBase, ITransactionService
    {
        private readonly ITransactionWriteRepository _writeRepository;
        private readonly ITransactionReadRepository _readRepository;
        private readonly IBankAccountReadRepository _bankAccountReadRepository;
        private readonly IBankAccountWriteRepository _bankAccountWriteRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="readRepository"></param>
        /// <param name="bankAccountReadRepository"></param>
        /// <param name="bankAccountWriteRepository"></param>
        /// 
        public TransactionService(ITransactionReadRepository readRepository
                , ITransactionWriteRepository writeRepository
            , IBankAccountReadRepository bankAccountReadRepository
            , IBankAccountWriteRepository bankAccountWriteRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _bankAccountReadRepository = bankAccountReadRepository;
            _bankAccountWriteRepository = bankAccountWriteRepository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IQueryable<Transaction>> GetAllQueryableAsync()
        {
            return _readRepository.GetAllQueryableAsync();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [UnitOfWork(isTransactional: false)]
        public async Task<TransactionDto> GetDetailAsync(Guid id)
        {
            try
            {
                var entity = await _readRepository.GetAsync(id);
                if(entity != null)
                {
                    return ObjectMapper.Map<TransactionDto>(entity);
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
        public async Task<ServiceResponse<TransactionDto>> CreateAsync(TransactionDto model)
        {
            try
            {
                
                using var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeAsyncFlowOption.Enabled);

                var fromAccount = await _bankAccountReadRepository.FirstOrDefaultAsync(x=>x.Id == model.FromAccountId);
                var toAccount = await _bankAccountReadRepository.FirstOrDefaultAsync(x => x.Id == model.ToAccountId);
                
                if (fromAccount == null || toAccount == null)
                    return NotFoundWithResult<TransactionDto>("404", "One or both accounts not found");
                model.FromAccountNumber = fromAccount.AccountNumber;
                model.FromAccountHolderName = fromAccount.AccountHolderName;
                model.ToAccountNumber = toAccount.AccountNumber;
                model.ToAccountHolderName = toAccount.AccountHolderName;
                if (fromAccount.Balance  < model.Amount)
                    return BadRequestWithResult<TransactionDto>("Insufficient funds");

                // Block số tiền trước khi xử lý
                model.Status = TransactionStatusEnum.Pending;
                fromAccount.BlockedAmount += model.Amount;
                fromAccount.Balance -= model.Amount; // Tạm trừ số dư
                using (var unitOfWork = UnitOfWorkManager.Begin())
                {
                    var entity = ObjectMapper.Map<Transaction>(model);
                    var id = await _writeRepository.InsertAndGetIdAsync(entity);

                    model.Id = id;
                    await _bankAccountWriteRepository.UpdateAsync(fromAccount);
                    var entityAfterInsert = await _readRepository.FirstOrDefaultAsync(x => x.Id == id);
                    await unitOfWork.CompleteAsync();
                    try
                    {
                        // Nếu giao dịch thành công, cập nhật số dư tài khoản đích
                        toAccount.Balance += model.Amount;
                        entityAfterInsert.Status = TransactionStatusEnum.Completed;
                        fromAccount.BlockedAmount += model.Amount;

                        await _bankAccountWriteRepository.UpdateAsync(toAccount);
                        await _writeRepository.UpdateAsync(entityAfterInsert);

                        transactionScope.Complete();

                        return OkWithResult<TransactionDto>(model);
                    }
                    catch (Exception)
                    {
                        // Nếu có lỗi, hoàn lại tiền bị block
                        fromAccount.Balance += model.Amount;
                        entityAfterInsert.Status = TransactionStatusEnum.Failed;
                        fromAccount.BlockedAmount += model.Amount;

                        await _bankAccountWriteRepository.UpdateAsync(fromAccount);
                        await _writeRepository.UpdateAsync(entityAfterInsert);
                        return ServerErrorWithResult<TransactionDto>("500", "Transaction failed due to an error.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message.ToString(), ex);
                return ServerErrorWithResult<TransactionDto>("500", ex.Message.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [UnitOfWork(isTransactional: false)]
        public async Task<Guid?> UpdateAsync(TransactionDto model)
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