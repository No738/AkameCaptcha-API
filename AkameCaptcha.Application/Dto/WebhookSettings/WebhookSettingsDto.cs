using Newtonsoft.Json;

namespace AkameCaptcha.Application.Dto.WebhookSettings
{
    /// <summary>
    /// Webhook settings DTO
    /// </summary>
    [JsonObject]
    public class WebhookSettingsDto
    {
        /// <summary>
        /// URL for webhook
        /// </summary>
        [JsonProperty("webhookURL")]
        public required string WebhookUrl { get; init; }
        
        /// <summary>
        /// Payload for the webhook
        /// </summary>
        [JsonProperty("payload")]
        public string? WebhookPayload { get; init; }
    }
}