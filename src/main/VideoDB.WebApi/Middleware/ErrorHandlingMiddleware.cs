using Evo.WebApi.Exceptions;
using Evo.WebApi.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleException(e, context);
            }
        }

        private async Task HandleException(Exception ex, HttpContext context)
        {
            var response = new ErrorResponse
            {
                Error = ex.Message,
                StackTrace = ex.StackTrace
            };
            context.Response.StatusCode = ex.GetType().Name switch
            {
                "EvoNotFoundException" => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
