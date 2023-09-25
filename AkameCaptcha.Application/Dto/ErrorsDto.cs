using System.Text.Json.Serialization;

namespace AkameCaptcha.Application.Dto
{
    /// <summary>
    /// DTO with errors received while processing the obtained from user data
    /// </summary>
    public sealed class ErrorsDto
    {
        /// <inheritdoc cref="ErrorsDto"/>
        /// <param name="errorMessages">Enumerable of user-friendly error messages</param>
        public ErrorsDto(IEnumerable<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
        
        /// <summary>
        /// User-friendly error messages
        /// </summary>
        [JsonPropertyName("errorMessages")]
        public IEnumerable<string> ErrorMessages { get; } 
    }
}