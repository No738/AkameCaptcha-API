using AkameCaptcha.Application.Requests.Commands.SolveChallenge.Dto;
using FluentValidation;

namespace AkameCaptcha.Application.Requests.Commands.SolveChallenge.Validators
{
    /// <summary>
    /// Validator for <see cref="SolveChallengeDto"/>>
    /// </summary>
    public class SolveChallengeDtoValidator : AbstractValidator<SolveChallengeDto>
    {
        /// <inheritdoc cref="SolveChallengeDtoValidator"/>
        public SolveChallengeDtoValidator()
        {
            RuleFor(dto => dto.Token)
                .NotEmpty();
        }
    }
}