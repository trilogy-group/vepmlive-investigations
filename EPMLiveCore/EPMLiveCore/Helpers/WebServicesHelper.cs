using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore.Helpers
{
    public static class WebServicesHelper
    {
        public static ArrayList FarmFeatureUsers(int featureId)
        {
            UserManager userManager = null;

            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    try
                    {
                        var farm = SPFarm.Local;

                        userManager = farm.GetChild<UserManager>($"UserManager{featureId}");
                        if (userManager == null)
                        {
                            var web = SPContext.Current.Web;
                            web.AllowUnsafeUpdates = true;
                            var site = web.Site;
                            site.AllowUnsafeUpdates = true;
                            var app = site.WebApplication;
                            farm = app.Farm;
                            userManager = new UserManager($"UserManager{featureId}", farm, Guid.NewGuid());
                            userManager.Update();
                            farm.Update();
                        }
                    }
                    catch(Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                });

            if (userManager != null)
            {
                return userManager.UserList;
            }

            return new ArrayList();
        }
    }
}
