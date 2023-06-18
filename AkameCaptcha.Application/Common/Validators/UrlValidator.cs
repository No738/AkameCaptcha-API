using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace AkameCaptcha.Application.Common.Validators
{
    /// <summary>
    /// Validator that ensures that the string is a valid URL
    /// </summary>
    public sealed partial class UrlValidator<T> : PropertyValidator<T, string>
    {
        private const string FailureReasonArgumentName = "FailureReason";
        private static readonly Regex UrlRegex = UrlGeneratedRegex();

        public override string Name => "UrlValidator";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            return ValidateLength(context, value) && ValidateUrlByRegexMatch(context, value);
        }

        private static bool ValidateUrlByRegexMatch(ValidationContext<T> context, string value)
        {
            if (!UrlRegex.IsMatch(value))
            {
                context.MessageFormatter.AppendArgument(FailureReasonArgumentName, $"must be a URL");

                return false;
            }

            return true;
        }

        private static bool ValidateLength(ValidationContext<T> context, string value)
        {
            const int MaximumUrlLength = 2048;
            
            if (value.Length > MaximumUrlLength)
            {
                context.MessageFormatter.AppendArgument(FailureReasonArgumentName,
                    $"length must not exceed {MaximumUrlLength} characters");

                return false;
            }

            return true;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"'{{PropertyName}}' {{{FailureReasonArgumentName}}}.";
        }

        [GeneratedRegex(@"https?:\/\/[-a-zA-Z0-9@:%._\+~#=]{1,2048}\.[a-zA-Z0-9()]{1,6}", RegexOptions.Compiled)]
        private static partial Regex UrlGeneratedRegex();
    }
}