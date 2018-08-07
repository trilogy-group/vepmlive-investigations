using System.Collections.ObjectModel;
using NewsGator.Install.Resources;
using NewsGator.Install.Common.Entities.Flags;

namespace NewsGator.Install.Common.Entities.Installer
{
    /// <summary>
    /// List of pre-requisites for the Social Sites Installer
    /// </summary>
    internal static class Prerequisites
    {
        internal static Collection<Prerequisite> Get()
        {
            return new Collection<Prerequisite>()
            {
                new Prerequisite() { Name = Names.FarmAdministrator, Order = 1, RequiredForConsumingFarmInstall = true, RequiredForInstall = true, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteUserIsFarmAdmin },
                new Prerequisite() { Name = Names.LocalAdministrator, Order = 2, RequiredForConsumingFarmInstall = true, RequiredForInstall = true, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteUserIsLocalAdmin },
                new Prerequisite() { Name = Names.SupportedSharePointVersion, Order = 3, RequiredForConsumingFarmInstall = true, RequiredForInstall = true, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteSharePointVersion },
                new Prerequisite() { Name = Names.WebApplicationStarted, Order = 4, RequiredForConsumingFarmInstall = false, RequiredForInstall = false, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteWebApplicationServiceIsStarted },
                new Prerequisite() { Name = Names.MySite, Order = 5, RequiredForConsumingFarmInstall = false, RequiredForInstall = false, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteMySiteHostAvailable },
                new Prerequisite() { Name = Names.UserProfileAvailable, Order = 6, RequiredForConsumingFarmInstall = false, RequiredForInstall = true, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteUserProfileAvailable },
                new Prerequisite() { Name = Names.UserProfileAccess, Order = 7, RequiredForConsumingFarmInstall = false, RequiredForInstall = true, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteUserProfileAccess },
                new Prerequisite() { Name = Names.UserProfileAdmin, Order = 8, RequiredForConsumingFarmInstall = false, RequiredForInstall = true, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteUserProfileAdmin },
                new Prerequisite() { Name = Names.NewerVersionNotInstalled, Order = 9, RequiredForConsumingFarmInstall = false, RequiredForInstall = false, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteNewerVersionNotInstalled },
                new Prerequisite() { Name = Names.UpgradeVersion, Order = 10, RequiredForConsumingFarmInstall = true, RequiredForInstall = true, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteUpgradeVersion },               
                new Prerequisite() { Name = Names.ShellAdmin, Order = 11, RequiredForConsumingFarmInstall = true, RequiredForInstall = true, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteShellAdmin },               
                new Prerequisite() { Name = Names.ModuleVersions, Order = 12, RequiredForConsumingFarmInstall = true, RequiredForInstall = true, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteModuleVersions },
                new Prerequisite() { Name = Names.WMIAccessible, Order = 13, RequiredForConsumingFarmInstall = true, RequiredForInstall = true, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteWMIAvailable },
                new Prerequisite() { Name = Names.ServerRoleSupported, Order = 14, RequiredForConsumingFarmInstall = true, RequiredForInstall = true, Status = PrerequisiteStatus.NotChecked, StatusDescription = string.Empty, Title = UserDisplay.PrerequisiteServerRoleSupported }  
            };
        }

        internal static class Names
        {
            internal const string FarmAdministrator = "FarmAdministrator";
            internal const string LocalAdministrator = "LocalAdministrator";
            internal const string SupportedSharePointVersion = "SupportedSharePointVersion";
            internal const string WebApplicationStarted = "WebApplicationStarted";
            internal const string MySite = "MySite";
            internal const string UserProfileAvailable = "UserProfileAvailable";
            internal const string UserProfileAccess = "UserProfileAccess";
            internal const string UserProfileAdmin = "UserProfileAdmin";
            internal const string NewerVersionNotInstalled = "NewerVersionNotInstalled";
            internal const string UpgradeVersion = "UpgradeVersion";
            internal const string ShellAdmin = "ShellAdmin";
            internal const string ModuleVersions = "ModuleVersions";
            internal const string WMIAccessible = "WMIAccessible";
            internal const string ServerRoleSupported = "ServerRoleSupported";
        }
    }
}
