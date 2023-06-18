using AkameCaptcha.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AkameCaptcha.API.Common
{
    /// <summary>
    /// Action filter for correct validation errors
    /// </summary>
    public class ValidationActionFilter : IAsyncActionFilter
    {
        /// <summary>
        /// If model state is not valid, converting response into <see cref="ErrorsDto"/>
        /// </summary>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsDto = GetErrorsDto(context.ModelState);
                context.Result = new JsonResult(errorsDto);
            
                return;
            }
            
            await next();
        }

        private static ErrorsDto GetErrorsDto(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(modelStateValue => 
                GetErrorMessages(modelStateValue.Errors));
            
            return new ErrorsDto(errors);
        }
        
        private static IEnumerable<string> GetErrorMessages(IEnumerable<ModelError> modelErrorCollection)
        {
            var errorMessages = modelErrorCollection.Select(FindErrorMessage)
                                                    .Where(errorMessage => errorMessage != null);
            
            return (IEnumerable<string>) errorMessages;
        }
        
        private static string? FindErrorMessage(ModelError error)
        {
            if (error.ErrorMessage != string.Empty)
                return error.ErrorMessage;
        
            return error.Exception?.Message;
        }
    }
}