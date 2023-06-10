using AkameCaptcha.Application.Common.Validators;
using FluentValidation;

namespace AkameCaptcha.Application.Dto.WebhookSettings
{
    /// <summary>
    /// Validator for webhook settings DTO
    /// </summary>
    public sealed class WebhookSettingsDtoValidator : AbstractValidator<WebhookSettingsDto>
    {
        private static readonly UrlValidator UrlValidator = new ();

        /// <inheritdoc cref="WebhookSettingsDtoValidator"/>
        public WebhookSettingsDtoValidator()
        {
            RuleFor(dto => dto.WebhookUrl)
                .SetValidator(UrlValidator);
        }
    }
}