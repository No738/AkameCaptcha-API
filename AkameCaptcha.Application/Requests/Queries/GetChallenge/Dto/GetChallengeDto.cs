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
        /// <inheritdoc cref="GetChallengeDto"/>
        /// </summary>
        /// <param name="id">Identifier of challenge</param>
        public GetChallengeDto(Guid id)
        {
            Id = id;
        }
        
        /// <summary>
        /// Identifier of challenge
        /// </summary>
        public Guid Id { get; }
    }
}