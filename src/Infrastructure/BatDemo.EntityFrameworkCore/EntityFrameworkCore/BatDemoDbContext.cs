using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BatDemo.Authorization.Roles;
using BatDemo.Authorization.Users;
using BatDemo.MultiTenancy;
using BatDemo.Entities;

namespace BatDemo.EntityFrameworkCore
{
    public partial class BatDemoDbContext : AbpZeroDbContext<Tenant, Role, User, BatDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public BatDemoDbContext(DbContextOptions<BatDemoDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ACCOUNT_PK");
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("TRANSACTION_PK");
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");


                entity.HasOne(d => d.FromAccount).WithMany(p => p.TransactionFroms)
                    .HasForeignKey(d => d.FromAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRANSACTION_FROMACCOUNT_ACCOUNT_FK");        
                entity.HasOne(d => d.ToAccount).WithMany(p => p.TransactionTos)
                    .HasForeignKey(d => d.ToAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRANSACTION_TOACCOUNT_ACCOUNT_FK");
            });
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}





