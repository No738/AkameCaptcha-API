namespace AkameCaptcha.Domain
{
    /// <summary>
    /// Type of captcha provider
    /// </summary>
    public enum CaptchaProvider
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
        /// Turnstile provider
        /// </summary>
        Turnstile = 3
    }
}