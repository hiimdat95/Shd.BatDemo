using Abp.Application.Services;
using BatDemo.MultiTenancy.Dto;

namespace BatDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}









