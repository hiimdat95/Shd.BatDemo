
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using BatDemo.Controllers;
using BatDemo.Transactions;
using BatDemo.Transactions.Dto;
using System;
using System.Threading.Tasks;

namespace BatDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class TransactionController : BatDemoControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route($"transaction")]
        public ActionResult Index()
        {
            return View();
        }
        
        /// 
        /// </summary>
        /// <returns></returns>
        [Route($"transaction/create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.IsView = false;
            TransactionDto entity = new TransactionDto();
            return View("Detail", entity);
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="id"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        [Route($"transaction/detail")]
        public async Task<ActionResult> Detail(Guid? id, bool? view)
        {
            ViewBag.IsView = view ?? false;
            TransactionDto entity = new TransactionDto();
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