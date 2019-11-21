using System;
using System.Net;
using System.Threading.Tasks;
using Application.Contracts;
using Microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Microservice.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        

        public ExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            _logger = logger; //log to console (default behavior of mvc core)
            
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IDBLogService dbLogService)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");

                await HandleExceptionAsync(httpContext, ex,  dbLogService);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, IDBLogService dbLogService)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //log error to database
            dbLogService.LogData("Error", exception.Message);

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error."
            }.ToString());
        }
    }
}