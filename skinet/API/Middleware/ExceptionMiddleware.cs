using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.OpenApi.Exceptions;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        /*keep in MIND middlewares form a pipeline , so every request passes through this piple line,
        so each middleware does something and passes it to the next middleware
        such as , logging station , authentification stations ...*/
        /*this middleware is for exception handling !!!!!!!!! */
        public RequestDelegate _next;
        public ILogger<ExceptionMiddleware> _logger;
        public IHostEnvironment _env ;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env) 
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType ="application/json"; // since the error will be in a json format
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response= _env.IsDevelopment()
                ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message,
                ex.StackTrace.ToString())
                : new ApiException((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions{PropertyNamingPolicy= JsonNamingPolicy.CamelCase};
                var json=JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }

        }

        
    }
}