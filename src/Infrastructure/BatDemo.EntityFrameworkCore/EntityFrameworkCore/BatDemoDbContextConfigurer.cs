using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BatDemo.EntityFrameworkCore
{
    public static class BatDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BatDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BatDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}








