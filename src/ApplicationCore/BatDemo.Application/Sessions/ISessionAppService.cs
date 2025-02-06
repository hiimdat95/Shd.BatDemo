using System.Threading.Tasks;
using Abp.Application.Services;
using BatDemo.Sessions.Dto;

namespace BatDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}








