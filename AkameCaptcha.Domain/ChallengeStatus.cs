namespace AkameCaptcha.Domain
{
    /// <summary>
    /// Challenge state status
    /// </summary>
    public enum ChallengeStatus
    {
        /// <summary>
        /// Challenge isn't solved
        /// </summary>
        Created = 1,
        
        /// <summary>
        /// Challenge was solved
        /// </summary>
        Solved = 2,
        
        /// <summary>
        /// Challenge has reached his TTL and expired
        /// </summary>
        Expired = 3
    }
}