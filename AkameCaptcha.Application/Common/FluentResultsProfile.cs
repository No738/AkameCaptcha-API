using AkameCaptcha.Application.Dto;
using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace AkameCaptcha.Application.Common
{
    /// <summary>
    /// Profile for converting fluent results to ActionResult
    /// </summary>
    public sealed class FluentResultsProfile : DefaultAspNetCoreResultEndpointProfile
    {
        private const int UnprocessableContentStatusCode = 422;

        /// <summary>
        /// Transform failed result to ActionResult with correct status code
        /// When the result is unsuccessful, we expect that domain/application logic has been broken.
        /// If tech error occurs, it must throw a exception
        /// </summary>
        /// <param name="context">Converting context</param>
        /// <returns>ActionResult response with Unprocessable Content status code</returns>
        public override ActionResult TransformFailedResultToActionResult(
            FailedResultToActionResultTransformationContext context)
        {
            var errorMessages = context.Result.Errors.Select(error => error.Message);
            var errorsDto = new ErrorsDto(errorMessages);
            
            return new ObjectResult(errorsDto)
            {
                StatusCode = UnprocessableContentStatusCode
            };
        }
    }
}