using FluentResults;
using MediatR;

namespace AkameCaptcha.Application.Requests.Queries.GetChallenge.Dto
{
    /// <summary>
    /// DTO for <see cref="GetChallengeQuery"/>>
    /// </summary>
    public sealed class GetChallengeDto : IRequest<Result<GetChallengeResponseDto>>
    {
        /// <summary>
        /// Identifier of challenge
        /// </summary>
        public Guid Id { get; set; }
    }
}