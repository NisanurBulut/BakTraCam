using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using BakTraCam.Common.Helper.Extensions.Definitions;

namespace BakTraCam.Service.WebApi.Helpers
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
     
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                
                await _next(context).ConfigureAwait(false);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = exception is IJsonFormatter jf ?
                jf.ToJson() :
                new DefaultJsonFormatter(exception).ToJson();

           

            var code = exception is IStatusCodeProvider cp ? cp.StatusCode : new DefaultStatusCodeProvider().StatusCode;

            // context.Response.ContentType = "application/json"
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(result);
        }
    }
}
