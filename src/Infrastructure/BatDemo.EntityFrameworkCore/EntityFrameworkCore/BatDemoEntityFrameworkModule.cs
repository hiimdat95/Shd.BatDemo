using Abp.Dependency;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using BatDemo.EntityFrameworkCore.Repositories;
using BatDemo.EntityFrameworkCore.Seed;
using BatDemo.Repositories;
using Microsoft.Extensions.Configuration;

namespace BatDemo.EntityFrameworkCore
{
    [DependsOn(
        typeof(BatDemoCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class BatDemoEntityFrameworkModule : AbpModule
    {
        private readonly IConfiguration _configuration;

        public BatDemoEntityFrameworkModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<BatDemoDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        BatDemoDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        BatDemoDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BatDemoEntityFrameworkModule).GetAssembly());
            IocManager.Register<CustomizedReadOnlyDbContextFactory>(DependencyLifeStyle.Transient);
            IocManager.Register<IReadViewRepository, ReadViewRepository>(DependencyLifeStyle.Transient);
            IocManager.Register<ICustomDapperForOracleRepository, CustomDapperForOracleRepository>(DependencyLifeStyle.Transient);
            IocManager.Register<IHttbcConnectionFactory, HttbcConnectionFactory>(DependencyLifeStyle.Transient);
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}






