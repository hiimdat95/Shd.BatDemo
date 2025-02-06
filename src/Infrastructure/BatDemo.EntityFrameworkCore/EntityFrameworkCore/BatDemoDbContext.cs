using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BatDemo.Authorization.Roles;
using BatDemo.Authorization.Users;
using BatDemo.MultiTenancy;

namespace BatDemo.EntityFrameworkCore
{
    public partial class BatDemoDbContext : AbpZeroDbContext<Tenant, Role, User, BatDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public BatDemoDbContext(DbContextOptions<BatDemoDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}





