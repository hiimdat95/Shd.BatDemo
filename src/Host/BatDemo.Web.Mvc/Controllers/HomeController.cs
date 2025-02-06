using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using BatDemo.Controllers;

namespace BatDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : BatDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
