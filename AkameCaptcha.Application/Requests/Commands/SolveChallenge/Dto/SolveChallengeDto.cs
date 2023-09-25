using FluentResults;
using MediatR;

namespace AkameCaptcha.Application.Requests.Commands.SolveChallenge.Dto
{
    /// <summary>
    /// Challenge solution DTO
    /// </summary>
    public sealed class SolveChallengeDto : IRequest<Result<SolveChallengeResponseDto>>
    {
        /// <summary>
        /// <inheritdoc cref="SolveChallengeDto"/>
        /// </summary>
        /// <param name="token">Response for challenge provider</param>
        public SolveChallengeDto(string token)
        {
            Token = token;
        }
        
        /// <summary>
        /// Response for challenge provider
        /// </summary>
        public string Token { get; }
    }
}