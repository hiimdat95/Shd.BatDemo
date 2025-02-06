using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BatDemo.EntityFrameworkCore;
using BatDemo.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BatDemo.Web.Tests
{
    [DependsOn(
        typeof(BatDemoWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BatDemoWebTestModule : AbpModule
    {
        public BatDemoWebTestModule(BatDemoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BatDemoWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BatDemoWebMvcModule).Assembly);
        }
    }
}






