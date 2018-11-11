using System;
using Microsoft.SharePoint;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Security
    {
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPUserToken GetSystemToken(SPSite site)
        {
            if (site == null)
                return null;

            site.CatchAccessDeniedException = false;
            try
            {
                return site.SystemAccount.UserToken;
            }
            catch (UnauthorizedAccessException)
            {
                SPUserToken sysToken = null;
                SPSecurity.RunWithElevatedPrivileges(
                    () =>
                    {
                        using (var superSite = new SPSite(site.ID))
                        {
                            sysToken = superSite.SystemAccount.UserToken;
                        }
                    }
                );
                return sysToken;
            }
        }
    }
}
