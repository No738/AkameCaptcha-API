using AkameCaptcha.Application.Requests.Queries.GetChallenge.Dto;
using FluentResults;
using MediatR;

namespace AkameCaptcha.Application.Requests.Queries.GetChallenge
{
    public class GetChallengeQuery : IRequestHandler<GetChallengeDto, Result<GetChallengeResponseDto>>
    {
        public Task<Result<GetChallengeResponseDto>> Handle(GetChallengeDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}