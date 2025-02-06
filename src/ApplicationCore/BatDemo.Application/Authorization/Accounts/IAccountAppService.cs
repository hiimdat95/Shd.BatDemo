using System.Threading.Tasks;
using Abp.Application.Services;
using BatDemo.Authorization.Accounts.Dto;

namespace BatDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}








