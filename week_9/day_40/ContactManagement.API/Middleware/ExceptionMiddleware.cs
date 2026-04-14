using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using ContactManagement.API.Models;
using ContactManagement.API.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ContactManagement.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;


        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Exception Occurred");

                await HandleExceptionAsync(context,e);
            }
        }
        private  Task HandleExceptionAsync(HttpContext context,Exception e)
        {
            var response = new ErrorResponse
            {
                Message = "something wrong",
                Time = DateTime.UtcNow
            };

            switch (e)
            {
                case NotFoundException:
                    response.StatusCode =(int)HttpStatusCode.NotFound;
                    response.Message = e.Message;
                    break;

                case BadRequestException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = e.Message;
                    break;

                default :
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;        
            }
            context.Response.ContentType="application/json";
            context.Response.StatusCode=response.StatusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}