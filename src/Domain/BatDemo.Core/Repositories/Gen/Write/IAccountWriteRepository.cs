using BatDemo.Entities;
using BatDemo.Repositories;
using System;

namespace BatDemo.Repositories.Gen.Write
{
    public interface IAccountWriteRepository: IWriteRepository<Account, Guid>
    {
    }
}


