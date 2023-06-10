using AkameCaptcha.Domain;

namespace AkameCaptcha.Application.Requests.Queries.GetChallenge.Dto
{
    public class ChallengeResponseDto
    {
        /// <summary>
        /// Challenge state status
        /// </summary>
        public required ChallengeStatus Status { get; set; }
        
        /// <summary>
        /// Challenge provider settings DTO
        /// </summary>
        public required ProviderSettingsDto ProviderSettings { get; set; }
        
        /// <summary>
        /// Date and time of challenge creation
        /// <remarks>ISO 8601 format</remarks>
        /// </summary>
        public required DateTime CreatedAt { get; set; }
    }
}