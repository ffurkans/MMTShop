using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MMT.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MMT.Web.API.Middlewares
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<CustomExceptionMiddleware> logger)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                if (ex is MMTException || ex is MMTArgumentNullException)
                {
                    await HandleMMTExceptionAsync(context, ex);
                }
                else
                {
                    await HandleMMTExceptionAsync(context, ex);
                }
                logger.LogError(ex, ex.Message);
            }
        }

        private Task HandleMMTExceptionAsync(HttpContext context, Exception exception)
        {
            string result = null;
            context.Response.ContentType = "application/json";
            if (exception is MMTException || exception is MMTArgumentNullException)
            {
                result = new ErrorDetails()
                {
                    Message = exception.Message,
                    StatusCode = (int)HttpStatusCode.BadRequest
                }.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                result = new ErrorDetails()
                {
                    Message = "Runtime Error",
                    StatusCode = (int)HttpStatusCode.BadRequest
                }.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return context.Response.WriteAsync(result);
        }
    }
}
