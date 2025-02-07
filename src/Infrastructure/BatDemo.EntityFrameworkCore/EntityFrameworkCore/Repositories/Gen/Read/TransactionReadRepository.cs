
using Abp.EntityFrameworkCore;
using BatDemo.Entities;
using BatDemo.EntityFrameworkCore;
using BatDemo.Repositories.Gen.Read;
using System;

namespace BatDemo.EntityFrameworkCore.Repositories.Gen.Read
{
    public class TransactionReadRepository : ReadRepository<Transaction, Guid>, ITransactionReadRepository
    {
        public TransactionReadRepository(IDbContextProvider<BatDemoDbContext> dbContextProvider, CustomizedReadOnlyDbContextFactory customDbContextFactory) 
            : base(dbContextProvider, customDbContextFactory)
        {
        }
    }
}
