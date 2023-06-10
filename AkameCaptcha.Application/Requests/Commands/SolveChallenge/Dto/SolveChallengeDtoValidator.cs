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
        private static readonly WebhookSettingsDtoValidator WebhookSettingsDtoValidator = new ();
        private static readonly UrlValidator UrlValidator = new ();

        /// <inheritdoc cref="SolveChallengeDtoValidator"/>
        public SolveChallengeDtoValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty();
        }
    }
}