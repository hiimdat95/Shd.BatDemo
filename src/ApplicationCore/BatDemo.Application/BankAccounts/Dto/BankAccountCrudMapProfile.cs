
using AutoMapper;
using BatDemo.Entities;

namespace BatDemo.BankAccounts.Dto
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
            CreateMap<BankAccountCrudDto, BankAccount>();
            CreateMap<BankAccount, BankAccountCrudDto>().ReverseMap();
        }
    }
}
