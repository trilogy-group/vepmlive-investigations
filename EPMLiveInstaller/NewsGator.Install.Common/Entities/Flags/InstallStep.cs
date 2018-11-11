namespace NewsGator.Install.Common.Entities.Flags
{
    /// <summary>
    /// Current step of the interface installer.
    /// </summary>
    internal enum InstallStep
    {
        None = 0,
        Modules = 1,
        WebApps = 2,
        Options = 3,
        Databases = 4,
        ServiceApplications = 5,
        ModuleOptions = 6,
        InstallSummary = 7,
        Install = 8
    }
}
