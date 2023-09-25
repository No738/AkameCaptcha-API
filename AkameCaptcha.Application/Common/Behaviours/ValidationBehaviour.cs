using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace AkameCaptcha.Application.Common.Behaviours
{
    /// <summary>
    /// Validation behaviour
    /// </summary>
    public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TResponse : ResultBase, new() 
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        /// <inheritdoc cref="ValidationBehaviour{TRequest,TResponse}"/>
        /// <param name="validators">Request related validators</param>
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
    
        /// <inheritdoc />
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return next();

            return ValidateRequestAsync(request, next, cancellationToken);
        }

        private async Task<TResponse> ValidateRequestAsync(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var result = await ValidateAsync(context, cancellationToken);
            if (result.IsFailed)
                return result;

            return await next();
        }

        private async Task<TResponse> ValidateAsync(IValidationContext context, CancellationToken cancellationToken)
        {
            var result = new TResponse();
            
            foreach (var validator in _validators)
            {
                var validationResult = await validator.ValidateAsync(context, cancellationToken);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(ConvertValidationFailureToResultError);

                    result.Reasons.AddRange(errors);
                }
            }

            return result;
        }

        private static IError ConvertValidationFailureToResultError(ValidationFailure validationError)
        {
            return new Error(validationError.ErrorMessage);
        }
    }
}