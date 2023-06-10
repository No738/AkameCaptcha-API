using System.Text.RegularExpressions;
using FluentValidation;

namespace AkameCaptcha.Application.Common.Validators
{
    /// <summary>
    /// Validator that ensures that the string is a URL
    /// </summary>
    public sealed partial class UrlValidator : AbstractValidator<string>
    {
        private static readonly Regex UrlRegex = UrlGeneratedRegex();
        
        /// <inheritdoc cref="UrlValidator"/>
        public UrlValidator()
        {
            const int MaximumUrlLength = 2048;

            RuleFor(url => url)
                .MaximumLength(MaximumUrlLength)
                .Matches(UrlRegex);
        }

        [GeneratedRegex(@"https?:\/\/[-a-zA-Z0-9@:%._\+~#=]{1,2048}\.[a-zA-Z0-9()]{1,6}", RegexOptions.Compiled)]
        private static partial Regex UrlGeneratedRegex();
    }
}