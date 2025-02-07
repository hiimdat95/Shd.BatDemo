
using Abp.EntityFrameworkCore;
using BatDemo.EntityFrameworkCore;
using BatDemo.Entities;
using BatDemo.Repositories.Gen.Write;
using System;

namespace BatDemo.EntityFrameworkCore.Repositories.Gen.Write
{
    public class BankAccountWriteRepository: WriteRepository<BankAccount, Guid>, IBankAccountWriteRepository
    {
        public BankAccountWriteRepository(IDbContextProvider<BatDemoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}