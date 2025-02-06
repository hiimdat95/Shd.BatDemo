using BatDemo.Configuration;
using BatDemo.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BatDemo.EntityFrameworkCore
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomizedReadOnlyDbContextFactory
    {
        private readonly DbContextOptions<BatDemoDbContext> _options;
        private BatDemoDbContext _onlyOneDbContext;

        public CustomizedReadOnlyDbContextFactory(IOptions<DbContextOptions<BatDemoDbContext>> options)
        {
            var builder = new DbContextOptionsBuilder<BatDemoDbContext>();
            BatDemoDbContextConfigurer.Configure(builder, BatDemo.Utils.ConfigurationManager.AppSetting.GetConnectionString("ReadonlyDb"));

            _options = builder.Options;
        }

        public BatDemoDbContext CreateDbContext()
        {
            _onlyOneDbContext ??= new BatDemoDbContext(_options);

            return _onlyOneDbContext;
        }
    }
}







