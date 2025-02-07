using Abp.Application.Services;
using BatDemo.Accounts.Dto;
using BatDemo.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BatDemo.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccountCrudService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<Account>> GetAllQueryableAsync();
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AccountCrudDto> GetDetailAsync(Guid id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid?> CreateAsync(AccountCrudDto model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid?> UpdateAsync(AccountCrudDto model);
    }
}