
using AutoMapper;
using BatDemo.Entities;

namespace BatDemo.BankAccounts.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class BankAccountCrudMapProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public BankAccountCrudMapProfile()
        {
            CreateMap<BankAccountCrudDto, BankAccount>();
            CreateMap<BankAccount, BankAccountCrudDto>().ReverseMap();
        }
    }
}
