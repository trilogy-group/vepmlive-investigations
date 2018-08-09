namespace NewsGator.Install.Common.Tasks
{
    /// <summary>
    /// Current status for an IInstallTask item
    /// </summary>
    public enum TaskStatus
    {
        NotStarted = 0,
        InProgress = 1,
        CompleteSuccess = 2,
        CompleteFailed = 3,
        CompleteFailedTerminateOperation = 4
    }
}
