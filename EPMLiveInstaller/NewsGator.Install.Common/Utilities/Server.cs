using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Server
    {
        /// <summary>
        /// Validate an SPServerRole based on its numeric valid.
        /// 
        /// SP2010/SP2013: WebFrontEnd = 1, Application = 2, SingleServer = 3
        /// SP2016: WebFrontEnd = 1, Application = 2, SingleServer = 3, SingleServerFarm = 4, DistributedCache = 5, Search = 6, Custom = 8
        /// </summary>
        /// <param name="role">SPServerRole to check.</param>
        /// <returns>Valid SPServerRole.</returns>
        internal static bool ValidSPServerRole(SPServerRole role)
        {
            // Filter out "invalid" role.
            return (int) role > 0;
        }

        /// <summary>
        /// Validate an SPServerRole based on its numeric value to determine if Sitrion Social can be deployed to it.
        /// 
        /// SP2010/SP2013: Application = 2
        /// SP2016: Application = 2, SingleServerFarm = 4
        /// </summary>
        /// <param name="role">SPServerRole to check.</param>
        /// <returns>Valid SPServerRole for Sitrion Social deployment.</returns>
        internal static bool ValidSPServerRoleForDeployment(SPServerRole role)
        {
            // Filter out "SingleServer" and "Invalid"
            return !(new int[] {0, 3}).Contains((int) role);
        }
    }
}
