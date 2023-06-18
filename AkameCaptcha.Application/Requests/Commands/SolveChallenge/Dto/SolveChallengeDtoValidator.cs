using AkameCaptcha.Application.Common.Validators;
using AkameCaptcha.Application.Dto.WebhookSettings;
using FluentValidation;

namespace AkameCaptcha.Application.Requests.Commands.SolveChallenge.Dto
{
    /// <summary>
    /// Validator for <see cref="SolveChallengeDto"/>>
    /// </summary>
    public class SolveChallengeDtoValidator : AbstractValidator<SolveChallengeDto>
    {
        /// <inheritdoc cref="SolveChallengeDtoValidator"/>
        public SolveChallengeDtoValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty();
        }
    }
}