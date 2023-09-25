using AkameCaptcha.Application.Dto.WebhookSettings;
using AkameCaptcha.Domain;
using FluentResults;
using MediatR;
using Newtonsoft.Json;

namespace AkameCaptcha.Application.Requests.Commands.CreateChallenge.Dto
{
    /// <summary>
    /// Request for challenge creation 
    /// </summary>
    [JsonObject]
    public sealed class CreateChallengeDto : IRequest<Result<Guid>>
    {
        /// <summary>
        /// Captcha provider
        /// </summary>
        [JsonProperty("provider")]
        public ChallengeProvider? Provider { get; init; }
        
        /// <summary>
        /// Challenge life time
        /// </summary>
        [JsonProperty("ttl")]
        public int? TimeToLive { get; init; }
        
        /// <summary>
        /// Redirect URL on successful solution of the challenge (given to the front-end)
        /// </summary>
        [JsonProperty("redirectURL")]
        public required string RedirectUrl { get; init; }
        
        /// <summary>
        /// Settings for webhook on successful solution of a challenge
        /// </summary>
        [JsonProperty("webhookSettings")]
        public required WebhookSettingsDto WebhookSettings { get; init; }
    }
}