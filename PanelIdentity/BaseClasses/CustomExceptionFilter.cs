using System;
using System.Net;
using Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PanelIdentity.BaseClasses
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var status = HttpStatusCode.InternalServerError;
            var message = string.Empty;

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Authorize";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "AServerErrorOccurred";
                status = HttpStatusCode.NotImplemented;
            }
            else if (exceptionType == typeof(InternalServerException))
            {
                message = context.Exception.Message;
                status = HttpStatusCode.InternalServerError;
            }
            else
            {
                message = context.Exception.Message;
                status = HttpStatusCode.NotFound;
            }

            context.ExceptionHandled = true;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            var err = message; // + " " + context.Exception.StackTrace;
            response.WriteAsync(err);
        }
    }
}