
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using BatDemo.Controllers;
using BatDemo.BankAccounts;
using BatDemo.BankAccounts.Dto;
using System;
using System.Threading.Tasks;

namespace BatDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class BankAccountController : BatDemoControllerBase
    {
        private readonly IBankAccountCrudService _service;

        public BankAccountController(IBankAccountCrudService service)
        {
            _service = service;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route($"bank-account")]
        public ActionResult Index()
        {
            return View();
        }
        
        /// 
        /// </summary>
        /// <returns></returns>
        [Route($"bank-account/create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.IsView = false;
            BankAccountCrudDto entity = new BankAccountCrudDto();
            return View("Detail", entity);
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="id"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        [Route($"bank-account/detail")]
        public async Task<ActionResult> Detail(Guid? id, bool? view)
        {
            ViewBag.IsView = view ?? false;
            BankAccountCrudDto entity = new BankAccountCrudDto();
            if (id.HasValue) 
            {
                entity = await _service.GetDetailAsync(id.Value);
                if (entity == null)
                {

                    return Redirect("/404");
                    
                }
            }
            return View(entity);
        }
    }
}