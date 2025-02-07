using Abp.Application.Services;
using BatDemo.Transactions.Dto;
using BatDemo.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BatDemo.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITransactionService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<Transaction>> GetAllQueryableAsync();
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TransactionDto> GetDetailAsync(Guid id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ServiceResponse<TransactionDto>> CreateAsync(TransactionDto model);
    }
}