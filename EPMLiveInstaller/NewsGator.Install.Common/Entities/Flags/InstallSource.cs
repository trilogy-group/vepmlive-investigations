namespace NewsGator.Install.Common.Entities.Flags
{
    /// <summary>
    /// Method used to invoke the installer.
    /// </summary>
    internal enum InstallSource
    {
        None = 0,
        Cmdlet = 1,
        Interface = 2,
        Unknown = 99
    }
}
