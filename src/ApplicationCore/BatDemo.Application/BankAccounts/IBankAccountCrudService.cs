using Abp.Application.Services;
using BatDemo.BankAccounts.Dto;
using BatDemo.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BatDemo.BankAccounts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBankAccountCrudService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<BankAccount>> GetAllQueryableAsync();
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BankAccountCrudDto> GetDetailAsync(Guid id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ServiceResponse<BankAccountCrudDto>> CreateAsync(BankAccountCrudDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ServiceResponse<BankAccountCrudDto>> UpdateAsync(BankAccountCrudDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<ServiceResponse> ValidateExitedAccountNumberAsync(string accountNumber);
    }
}