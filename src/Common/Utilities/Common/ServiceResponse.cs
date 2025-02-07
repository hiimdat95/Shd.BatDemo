using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ServiceResponse() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="statusCode"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ServiceResponse(bool success, int statusCode, string code = null, string message = null)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
            Code = code;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ServiceResponse SuccessResult(int statusCode)
        {
            return new ServiceResponse(true, statusCode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="code"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static ServiceResponse ErrorResult(int statusCode, string code, string errorMessage)
        {
            return new ServiceResponse(false, statusCode, code, message: errorMessage);
        }
    }
    /// <summary>
    /// With data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T> : ServiceResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ServiceResponse() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ServiceResponse(bool success, T data, int statusCode, string code = null, string message = null)
            : base(success, statusCode, code, message: message)
        {
            Data = data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static ServiceResponse<T> SuccessResult(T data, int statusCode)
        {
            return new ServiceResponse<T>(true, data, statusCode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="code"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static new ServiceResponse<T> ErrorResult(int statusCode, string code, string errorMessage)
        {
            return new ServiceResponse<T>(false, default, statusCode, code, errorMessage);
        }
    }
}
