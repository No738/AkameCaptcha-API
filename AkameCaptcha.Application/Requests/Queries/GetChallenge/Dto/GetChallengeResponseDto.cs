using AkameCaptcha.Application.Dto.ProviderSettings;
using AkameCaptcha.Domain;

namespace AkameCaptcha.Application.Requests.Queries.GetChallenge.Dto
{
    /// <summary>
    /// Get challenge response DTO
    /// </summary>
    public sealed class GetChallengeResponseDto
    {
        /// <summary>
        /// Challenge state status
        /// </summary>
        public required ChallengeStatus Status { get; init; }
        
        /// <summary>
        /// Challenge provider settings DTO
        /// </summary>
        public required ProviderSettingsDto ProviderSettings { get; init; }
        
        /// <summary>
        /// Date and time of challenge creation
        /// <remarks>ISO 8601 format</remarks>
        /// </summary>
        public required DateTime CreatedAt { get; init; }
    }
}