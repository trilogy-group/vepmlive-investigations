namespace NewsGator.Install.Common.Entities.Flags
{
    /// <summary>
    /// Status of an individual prerequisite.
    /// </summary>
    internal enum PrerequisiteStatus
    {
        None = 0,
        NotChecked = 1,
        Passed = 2,
        Failed = 3
    }
}
