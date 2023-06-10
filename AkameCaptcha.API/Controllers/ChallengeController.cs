using AkameCaptcha.Application.Requests.Commands.CreateChallenge.Dto;
using AkameCaptcha.Application.Requests.Commands.SolveChallenge.Dto;
using AkameCaptcha.Application.Requests.Queries.GetChallenge;
using AkameCaptcha.Application.Requests.Queries.GetChallenge.Dto;
using FluentResults.Extensions.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AkameCaptcha.API.Controllers
{
    /// <summary>
    /// Controller for actions with challenges 
    /// </summary>
    [ApiController]
    [Route("challenge")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class ChallengeController
    {
        private readonly IMediator _mediator;

        /// <inheritdoc cref="ChallengeController"/>
        public ChallengeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets challenge by <see cref="Guid"/>
        /// </summary>
        /// <param name="getChallengeDto">Request DTO</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Returns result with <see cref="ChallengeResponseDto"/></returns>
        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] GetChallengeDto getChallengeDto,
                                                 CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(getChallengeDto, cancellationToken);

            return result.ToActionResult();
        }

        /// <summary>
        /// Creates challenge
        /// </summary>
        /// <param name="createChallengeDto">Request DTO</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Returns result with <see cref="Guid"/> of created challenge</returns>
        [HttpPost("create")]
        public async Task<ActionResult> CreateAsync([FromBody] CreateChallengeDto createChallengeDto, 
                                                    CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(createChallengeDto, cancellationToken);

            return result.ToActionResult();
        }
        
        /// <summary>
        /// Checks the solution of challenge
        /// </summary>
        /// <param name="solveChallengeDto">Request DTO</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Returns result with <see cref="SolveChallengeResponseDto"/></returns>
        [HttpPost("solve")]
        public async Task<ActionResult> SolveAsync([FromQuery] SolveChallengeDto solveChallengeDto,
                                                   CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(solveChallengeDto, cancellationToken);

            return result.ToActionResult();
        }
    }
}