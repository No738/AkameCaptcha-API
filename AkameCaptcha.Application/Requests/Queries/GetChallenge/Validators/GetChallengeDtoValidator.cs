using AkameCaptcha.Application.Requests.Queries.GetChallenge.Dto;
using FluentValidation;

namespace AkameCaptcha.Application.Requests.Queries.GetChallenge.Validators
{
    /// <summary>
    /// Validator for <see cref="GetChallengeDto"/>>
    /// </summary>
    public class GetChallengeDtoValidator : AbstractValidator<GetChallengeDto>
    {
        /// <inheritdoc cref="GetChallengeDtoValidator"/>
        public GetChallengeDtoValidator()
        {
            RuleFor(dto => dto.Id)
                .NotEmpty();
        }
    }
}