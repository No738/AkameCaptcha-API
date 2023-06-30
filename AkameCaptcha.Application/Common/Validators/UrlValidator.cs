using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace AkameCaptcha.Application.Common.Validators
{
    /// <summary>
    /// Validator that ensures that the string is a valid URL
    /// <typeparam name="T">The type of validating class</typeparam>
    /// </summary>
    public sealed partial class UrlValidator<T> : PropertyValidator<T, string>
    {
        private const string FailureReasonArgumentName = "FailureReason";
        private static readonly Regex UrlRegex = UrlGeneratedRegex();

        /// <inheritdoc />
        public override string Name => "UrlValidator";

        /// <inheritdoc />
        public override bool IsValid(ValidationContext<T> context, string value)
        {
            return ValidateLength(context, value) && ValidateUrlByRegexMatch(context, value);
        }

        private static bool ValidateUrlByRegexMatch(ValidationContext<T> context, string value)
        {
            var isUrlMatched = UrlRegex.IsMatch(value);
            
            if (!isUrlMatched)
                context.MessageFormatter.AppendArgument(FailureReasonArgumentName, $"must be a URL");

            return isUrlMatched;
        }

        private static bool ValidateLength(ValidationContext<T> context, string value)
        {
            const int MaximumUrlLength = 2048;
            var isUrlLengthCorrect = value.Length <= MaximumUrlLength;

            if (!isUrlLengthCorrect)
                context.MessageFormatter.AppendArgument(FailureReasonArgumentName,
                    $"length must not exceed {MaximumUrlLength} characters");

            return isUrlLengthCorrect;
        }

        /// <inheritdoc />
        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"'{{PropertyName}}' {{{FailureReasonArgumentName}}}.";
        }

        [GeneratedRegex(@"https?:\/\/[-a-zA-Z0-9@:%._\+~#=]{1,2048}\.[a-zA-Z0-9()]{1,6}", RegexOptions.Compiled)]
        private static partial Regex UrlGeneratedRegex();
    }
}