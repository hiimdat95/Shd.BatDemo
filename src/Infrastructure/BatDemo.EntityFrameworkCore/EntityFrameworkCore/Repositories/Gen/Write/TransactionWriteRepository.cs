
using Abp.EntityFrameworkCore;
using BatDemo.EntityFrameworkCore;
using BatDemo.Entities;
using BatDemo.Repositories.Gen.Write;
using System;

namespace BatDemo.EntityFrameworkCore.Repositories.Gen.Write
{
    public class TransactionWriteRepository: WriteRepository<Transaction, Guid>, ITransactionWriteRepository
    {
        public TransactionWriteRepository(IDbContextProvider<BatDemoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}