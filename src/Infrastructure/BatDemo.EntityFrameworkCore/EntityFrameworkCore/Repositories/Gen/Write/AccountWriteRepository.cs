
using Abp.EntityFrameworkCore;
using BatDemo.EntityFrameworkCore;
using BatDemo.Entities;
using BatDemo.Repositories.Gen.Write;
using System;

namespace BatDemo.EntityFrameworkCore.Repositories.Gen.Write
{
    public class AccountWriteRepository: WriteRepository<Account, Guid>, IAccountWriteRepository
    {
        public AccountWriteRepository(IDbContextProvider<BatDemoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}