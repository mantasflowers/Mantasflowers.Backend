using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Mantasflowers.Contracts.Errors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;

namespace Mantasflowers.WebApi.Middleware
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _environment;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next,
            ILogger logger,
            IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleGlobalException(e, context);
                LogException(e.GetBaseException());
            }
        }

        private Task HandleGlobalException(Exception e, HttpContext context)
        {
            context.Response.ContentType = "application/json";

            e = e.GetBaseException();

            var statusCode = HttpStatusCode.InternalServerError;
            string message = _environment.IsProduction() ? "Internal server error" : e.Message;
            string stackTrace = _environment.IsProduction() ? null : e.StackTrace;

            switch (e)
            {
                case ValidationException _:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                default:
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(
                new ErrorResponse
                {
                    Message = message,
                    StackTrace = stackTrace
                }
            ));
        }

        private void LogException<T>(T e)
            where T : Exception
        {
            _logger.Error(
                "Exception {exceptioName} was caught by error middleware with message: {message}",
                e.GetType().Name,
                e.Message);
        }
    }
}