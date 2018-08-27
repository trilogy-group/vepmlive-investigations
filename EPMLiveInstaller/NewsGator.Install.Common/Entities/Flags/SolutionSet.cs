namespace NewsGator.Install.Common.Entities.Flags
{
    /// <summary>
    /// Group in which a NewsGator Social Sites Solution belongs to.
    /// </summary>
	public enum SolutionSet
	{
		None = 0,
		SocialPlatform = 1,
		IdeaStream = 2,
		Spotlight = 3,
		VideoStream = 4,
		Enrich = 5,
		NewsStream = 6,
		CanadaCommon = 8,
		EnrichVideoScenarios = 9,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "ScreenCast")]
        VideoScreenCast = 10,
		PivotViewer = 11,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Comm")]
        InterComm = 14,
		Innovation = 15,
        Scorecard = 16,
		Unknown = 99
	}
}
