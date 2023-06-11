using System.Net;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AkameCaptcha.API.Common
{
    /// <summary>
    /// Operation filter for adding default status codes to Swagger
    /// </summary>
    public class DefaultStatusCodesOperationFilter : IOperationFilter
    {
        private static readonly IReadOnlyDictionary<HttpStatusCode, OpenApiResponse> DefaultStatusCodes;

        static DefaultStatusCodesOperationFilter()
        {
            DefaultStatusCodes = new Dictionary<HttpStatusCode, OpenApiResponse>(2)
            {
                {
                    HttpStatusCode.UnprocessableEntity, new OpenApiResponse()
                    {
                        Description = "Received DTO failed to pass validation"
                    }
                },
                {
                    HttpStatusCode.InternalServerError, new OpenApiResponse()
                    {
                        Description = "An unhandled exception occurred while processing the request"
                    }
                }
            };
        }

        /// <summary>
        /// Apply default status codes
        /// </summary>
        /// <param name="operation">Operation object</param>
        /// <param name="context">Context of operation</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            foreach (var defaultResponse in DefaultStatusCodes)
            {
                var statusCode = ((int)defaultResponse.Key).ToString();

                operation.Responses.TryAdd(statusCode, defaultResponse.Value);
            }
        }
    }
}