using AkameCaptcha.Application.Dto.WebhookSettings;
using FluentValidation;

namespace AkameCaptcha.Application.Common.Validators
{
    /// <summary>
    /// Validator for webhook settings DTO
    /// </summary>
    public sealed class WebhookSettingsDtoValidator : AbstractValidator<WebhookSettingsDto>
    {
        private static readonly UrlValidator<WebhookSettingsDto> UrlValidator = new ();

        /// <inheritdoc cref="WebhookSettingsDtoValidator"/>
        public WebhookSettingsDtoValidator()
        {
            RuleFor(dto => dto.WebhookUrl)
                .SetValidator(UrlValidator);
        }
    }
}