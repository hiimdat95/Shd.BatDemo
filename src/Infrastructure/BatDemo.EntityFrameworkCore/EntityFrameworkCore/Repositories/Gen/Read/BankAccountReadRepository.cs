
using Abp.EntityFrameworkCore;
using BatDemo.Entities;
using BatDemo.EntityFrameworkCore;
using BatDemo.Repositories.Gen.Read;
using System;

namespace BatDemo.EntityFrameworkCore.Repositories.Gen.Read
{
    public class BankAccountReadRepository : ReadRepository<BankAccount, Guid>, IBankAccountReadRepository
    {
        public BankAccountReadRepository(IDbContextProvider<BatDemoDbContext> dbContextProvider, CustomizedReadOnlyDbContextFactory customDbContextFactory) 
            : base(dbContextProvider, customDbContextFactory)
        {
        }
    }
}
