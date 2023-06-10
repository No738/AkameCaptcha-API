using AkameCaptcha.Domain;
using Newtonsoft.Json;

namespace AkameCaptcha.Application.Requests.Queries.GetChallenge.Dto
{
    /// <summary>
    /// DTO with settings of challenge provider
    /// </summary>
    public sealed class ProviderSettingsDto
    {
        /// <inheritdoc cref="ProviderSettingsDto"/>
        /// <param name="key">Challenge provider API key</param>
        /// <param name="provider">Challenge provider type</param>
        public ProviderSettingsDto(string key, CaptchaProvider provider)
        {
            Key = key;
            Provider = provider;
        }
        
        /// <summary>
        /// Challenge provider API key
        /// </summary>
        [JsonProperty("siteKey")]
        public string Key { get; set; }
        
        /// <summary>
        /// Captcha provider
        /// </summary>
        [JsonProperty("type")]
        public CaptchaProvider Provider { get; set; }
    }
}