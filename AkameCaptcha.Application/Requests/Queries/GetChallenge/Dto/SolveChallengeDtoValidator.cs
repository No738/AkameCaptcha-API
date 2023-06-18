using AkameCaptcha.Application.Common.Validators;
using AkameCaptcha.Application.Dto.WebhookSettings;
using AkameCaptcha.Application.Requests.Commands.SolveChallenge.Dto;
using FluentValidation;

namespace AkameCaptcha.Application.Requests.Queries.GetChallenge.Dto
{
    /// <summary>
    /// Validator for <see cref="GetChallengeDto"/>>
    /// </summary>
    public class GetChallengeDtoValidator : AbstractValidator<GetChallengeDto>
    {
        /// <inheritdoc cref="SolveChallengeDtoValidator"/>
        public GetChallengeDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}