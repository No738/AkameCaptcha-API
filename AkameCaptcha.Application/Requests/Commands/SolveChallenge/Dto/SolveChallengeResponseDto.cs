using Newtonsoft.Json;

namespace AkameCaptcha.Application.Requests.Commands.SolveChallenge.Dto
{
    /// <summary>
    /// Response DTO for <see cref="SolveChallengeCommand"/>>
    /// </summary>
    public sealed class SolveChallengeResponseDto
    {
        /// <inheritdoc cref="SolveChallengeResponseDto"/>
        /// <param name="redirectUrl">Redirect URL on successful solution of the challenge</param>
        public SolveChallengeResponseDto(string redirectUrl)
        {
            RedirectUrl = redirectUrl;
        }

        [JsonProperty("redirectURL")]
        public string RedirectUrl { get; set; }
    }
}