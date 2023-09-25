using AkameCaptcha.Application.Requests.Commands.CreateChallenge.Dto;
using FluentResults;
using MediatR;

namespace AkameCaptcha.Application.Requests.Commands.CreateChallenge
{
    /// <summary>
    /// Create challenge command
    /// </summary>
    public class CreateChallengeCommand : IRequestHandler<CreateChallengeDto, Result<Guid>>
    {
        /// <summary>
        /// Handle create challenge command
        /// </summary>
        /// <param name="request">Request DTO</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Guid of created challenge</returns>
        public Task<Result<Guid>> Handle(CreateChallengeDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}