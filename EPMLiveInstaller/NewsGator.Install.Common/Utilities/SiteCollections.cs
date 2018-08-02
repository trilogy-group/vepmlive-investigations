using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace NewsGator.Install.Common.Utilities
{
    internal static class SiteCollections
    {
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static bool IsSiteLocked(Guid id)
        {
            var readLocked = false;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var admin = new SPSiteAdministration(id))
                {
                    readLocked = admin.ReadLocked;
                }
            });
            return readLocked;
        }
    }
}
