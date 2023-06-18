using AkameCaptcha.Application.Common.Validators;
using AkameCaptcha.Application.Dto.WebhookSettings;
using FluentValidation;

namespace AkameCaptcha.Application.Requests.Commands.CreateChallenge.Dto
{
    /// <summary>
    /// Validator for <see cref="CreateChallengeDto"/>>
    /// </summary>
    public class CreateChallengeDtoValidator : AbstractValidator<CreateChallengeDto>
    {
        private static readonly UrlValidator<CreateChallengeDto> UrlValidator = new ();
        private static readonly WebhookSettingsDtoValidator WebhookSettingsDtoValidator = new ();

        /// <inheritdoc cref="CreateChallengeDtoValidator"/>
        public CreateChallengeDtoValidator()
        {
            ValidateTimeToLive();
            ValidateCaptchaProvider();
            ValidateRedirectUrl();
            ValidateWebhookSettings();
        }
        
        private void ValidateTimeToLive()
        {
            RuleFor(dto => dto.TimeToLive)
                .GreaterThan(0);
        }
        
        private void ValidateCaptchaProvider()
        {
            RuleFor(dto => dto.Provider)
                .IsInEnum()
                .When(dto => dto.Provider != null);
        }

        private void ValidateRedirectUrl()
        {
            RuleFor(dto => dto.RedirectUrl)
                .SetValidator(UrlValidator);
        }
        
        private void ValidateWebhookSettings()
        {
            RuleFor(dto => dto.WebhookSettings)
                .SetValidator(WebhookSettingsDtoValidator);
        }
    }
}