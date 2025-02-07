
using AutoMapper;
using BatDemo.Entities;

namespace BatDemo.Transactions.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionMapProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public TransactionMapProfile()
        {
            CreateMap<TransactionDto, Transaction>();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}
