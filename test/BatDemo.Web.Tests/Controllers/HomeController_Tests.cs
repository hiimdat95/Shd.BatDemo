using System.Threading.Tasks;
using BatDemo.Models.TokenAuth;
using BatDemo.Web.Controllers;
using Shouldly;
using Xunit;

namespace BatDemo.Web.Tests.Controllers
{
    public class HomeController_Tests: BatDemoWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}






