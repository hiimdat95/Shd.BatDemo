
using AutoMapper;
using BatDemo.Entities;

namespace BatDemo.Accounts.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class CfgChiTieuDetailMapProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public CfgChiTieuDetailMapProfile()
        {
            CreateMap<AccountCrudDto, Account>();
            CreateMap<Account, AccountCrudDto>().ReverseMap();
        }
    }
}
