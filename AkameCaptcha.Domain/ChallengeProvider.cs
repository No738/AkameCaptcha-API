namespace AkameCaptcha.Domain
{
    /// <summary>
    /// Type of captcha provider
    /// </summary>
    public enum ChallengeProvider
    {
        /// <summary>
        /// hCaptcha provider
        /// </summary>
        hCaptcha = 1,
        
        /// <summary>
        /// reCAPTCHA provider
        /// </summary>
        reCAPTCHA = 2,
        
        /// <summary>
        /// Cloudflare Turnstile provider
        /// </summary>
        Turnstile = 3
    }
}