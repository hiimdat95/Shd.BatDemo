using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using BatDemo.Authorization.Users;
using BatDemo.MultiTenancy;
using Microsoft.AspNetCore.Http;
using Htbc.Constants;

namespace BatDemo
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class BatDemoAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected BatDemoAppServiceBase()
        {
            LocalizationSourceName = BatDemoConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
        #region function base return ServiceResponse
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual ServiceResponse BadRequest(string code = "", string message = "")
        {
            if (code == "")
                code = StatusCodes.Status400BadRequest.ToString();
            if (message == "")
                message = ServiceResponseMessage.BadRequest;
            return ServiceResponse.ErrorResult(StatusCodes.Status400BadRequest, code, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual ServiceResponse Forbidden(string code = "", string message = "")
        {
            if (code == "")
                code = StatusCodes.Status403Forbidden.ToString();
            if (message == "")
                message = ServiceResponseMessage.Forbidden;
            return ServiceResponse.ErrorResult(StatusCodes.Status403Forbidden, code, message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual ServiceResponse NotFound(string code = "", string message = "")
        {
            if (code == "")
                code = StatusCodes.Status404NotFound.ToString();
            if (message == "")
                message = ServiceResponseMessage.NotFound;
            return ServiceResponse.ErrorResult(StatusCodes.Status404NotFound, code, message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual ServiceResponse Ok()
        {
            return ServiceResponse.SuccessResult(StatusCodes.Status200OK);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual ServiceResponse Created()
        {
            return ServiceResponse.SuccessResult(StatusCodes.Status201Created);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual ServiceResponse Unauthorized(string code = "", string message = "")
        {
            if (code == "")
                code = StatusCodes.Status203NonAuthoritative.ToString();
            if (message == "")
                message = ServiceResponseMessage.AuthorError;
            return ServiceResponse.ErrorResult(StatusCodes.Status203NonAuthoritative, code, message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual ServiceResponse ServerError(string code = "", string message = "")
        {
            if (code == "")
                code = StatusCodes.Status500InternalServerError.ToString();
            if (message == "")
                message = ServiceResponseMessage.InternalServerError;
            return ServiceResponse.ErrorResult(StatusCodes.Status500InternalServerError, code, message);
        }

        //========= Return With Result =================

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual ServiceResponse<T> OkWithResult<T>(T data = default)
        {
            return ServiceResponse<T>.SuccessResult(data, StatusCodes.Status200OK);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual ServiceResponse<T> CreatedWithResult<T>(T data = default)
        {
            return ServiceResponse<T>.SuccessResult(data, StatusCodes.Status201Created);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual ServiceResponse<T> BadRequestWithResult<T>(string code = "", string message = "")
        {
            if (code == "")
                code = StatusCodes.Status400BadRequest.ToString();
            if (message == "")
                message = ServiceResponseMessage.BadRequest;
            return ServiceResponse<T>.ErrorResult(StatusCodes.Status400BadRequest, code, message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual ServiceResponse<T> ForbiddenWithResult<T>(string code = "", string message = "")
        {
            if (code == "")
                code = StatusCodes.Status403Forbidden.ToString();
            if (message == "")
                message = ServiceResponseMessage.Forbidden;
            return ServiceResponse<T>.ErrorResult(StatusCodes.Status403Forbidden, code, message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual ServiceResponse<T> NotFoundWithResult<T>(string code = "", string message = "")
        {
            if (code == "")
                code = StatusCodes.Status404NotFound.ToString();
            if (message == "")
                message = ServiceResponseMessage.NotFound;
            return ServiceResponse<T>.ErrorResult(StatusCodes.Status404NotFound, code, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual ServiceResponse<T> UnauthorizedWithResult<T>(string code = "", string message = "")
        {
            if (code == "")
                code = StatusCodes.Status203NonAuthoritative.ToString();
            if (message == "")
                message = ServiceResponseMessage.AuthorError;
            return ServiceResponse<T>.ErrorResult(StatusCodes.Status203NonAuthoritative, code, message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual ServiceResponse<T> ServerErrorWithResult<T>(string code = "", string message = "")
        {
            if (code == "")
                code = StatusCodes.Status500InternalServerError.ToString();
            if (message == "")
                message = ServiceResponseMessage.InternalServerError;
            return ServiceResponse<T>.ErrorResult(StatusCodes.Status500InternalServerError, code, message);
        }

        #endregion function base return ServiceResponse

    }
}








