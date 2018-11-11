namespace NewsGator.Install.Common.Entities.Flags
{
    /// <summary>
    /// Operation to perform during the installer methods.
    /// </summary>
    internal enum InstallMethod
    {
        None = 0,
        Install = 1,
        Update = 2,
        Uninstall = 3,
        Unknown = 99
    }
}
