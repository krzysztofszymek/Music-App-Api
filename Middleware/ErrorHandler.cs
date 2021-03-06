using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_App_Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_App_Api.Middleware
{
    public class ErrorHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (AlreadyExistsException alreadyExistsException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(alreadyExistsException.Message);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong.");
            }
        }
    }
}
