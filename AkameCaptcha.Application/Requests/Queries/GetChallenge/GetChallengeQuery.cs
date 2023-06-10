using AkameCaptcha.Application.Requests.Queries.GetChallenge.Dto;
using FluentResults;
using MediatR;

namespace AkameCaptcha.Application.Requests.Queries.GetChallenge
{
    public class GetChallengeQuery : IRequestHandler<GetChallengeDto, Result<ChallengeResponseDto>>
    {
        public Task<Result<ChallengeResponseDto>> Handle(GetChallengeDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}