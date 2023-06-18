using FluentResults;
using MediatR;

namespace AkameCaptcha.Application.Requests.Queries.GetChallenge.Dto
{
    /// <summary>
    /// DTO for <see cref="GetChallengeQuery"/>>
    /// </summary>
    public class GetChallengeDto : IRequest<Result<ChallengeResponseDto>>
    {
        /// <summary>
        /// Identifier of challenge
        /// </summary>
        public Guid Id { get; set; }
    }
}