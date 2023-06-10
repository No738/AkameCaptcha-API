using FluentResults;
using MediatR;

namespace AkameCaptcha.Application.Requests.Commands.SolveChallenge.Dto
{
    /// <summary>
    /// Challenge solution
    /// </summary>
    public class SolveChallengeDto : IRequest<Result<SolveChallengeResponseDto>>
    {
        /// <summary>
        /// Response for challenge provider
        /// </summary>
        public string? Token { get; set; }
    }
}