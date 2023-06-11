using System.Net;
using System.Net.Mime;
using AkameCaptcha.Application.Dto;
using FluentValidation;

namespace AkameCaptcha.API.Middleware
{
    /// <summary>
    /// Error handler for exceptions during requests
    /// </summary>
    public sealed class ErrorHandlingMiddleware
    {
        private static readonly IEnumerable<string> InternalErrorMessage = new [] { "Failed to produce your request" };
        private readonly RequestDelegate _next;

        /// <inheritdoc cref="ErrorHandlingMiddleware"/>
        /// <param name="next">Next request delegate</param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoking request processing with catching exceptions and converting to an processable result
        /// </summary>
        /// <param name="context">Request context</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) when (FindInnerException(ex) is ValidationException validationException)
            {
                var errorMessages = 
                    validationException.Errors.Select(error => error.ErrorMessage);
                
                await BuildErrorResponse(HttpStatusCode.UnprocessableEntity, errorMessages, context);
            }
            catch
            {
                await BuildErrorResponse(HttpStatusCode.InternalServerError, InternalErrorMessage, context);
            }
        }

        private static Task BuildErrorResponse(HttpStatusCode statusCode, IEnumerable<string> errorMessages, HttpContext context)
        {
            context.Response.StatusCode = (int) statusCode;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            // TODO: Errors logging
            var errorsDto = new ErrorsDto(errorMessages);

            return context.Response.WriteAsJsonAsync(errorsDto);
        }

        private static Exception FindInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;

            return ex;
        }
    }
}