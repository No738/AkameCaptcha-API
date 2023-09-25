using AkameCaptcha.Application.Requests.Commands.SolveChallenge.Dto;
using FluentResults;
using MediatR;

namespace AkameCaptcha.Application.Requests.Commands.SolveChallenge
{
    /// <summary>
    /// Solve challenge command
    /// </summary>
    public class SolveChallengeCommand : IRequestHandler<SolveChallengeDto, Result<SolveChallengeResponseDto>>
    {
        /// <summary>
        /// Handle solve challenge command
        /// </summary>
        /// <param name="request">Request DTO</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result with response</returns>
        public Task<Result<SolveChallengeResponseDto>> Handle(SolveChallengeDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}