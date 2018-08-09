namespace NewsGator.Install.Common.Entities.Flags
{
    /// <summary>
    /// Type of NewsGator Social Sites Service Application.
    /// </summary>
    public enum ServiceApplicationType
    {
        None = 0,
        SocialPlatform = 1,
        NewsStream = 2,
        VideoStream = 3,
        Learning = 4,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Comm")]
        InterComm = 5,
		Innovation = 6,
        Unknown = 99
    }
}
