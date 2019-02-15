using System;
using EPMLiveCore;
using Microsoft.SharePoint;
using SystemTrace = System.Diagnostics.Trace;

namespace EPMLiveWorkPlanner
{
    internal class ConfigHelper
    {
        public static void GetConfigSettings(
            SPWeb web,
            ref SPList lstProjectCenter,
            ref SPList lstTaskCenter,
            ref bool useResourcePool,
            ref string resourcePoolUrl,
            ref string resourceList,
            ref string wpFields)
        {
            if (web == null)
            {
                throw new ArgumentNullException(nameof(web));
            }

            var lockWeb = CoreFunctions.getLockedWeb(web);

            if (lockWeb == Guid.Empty || lockWeb == web.ID)
            {
                GetConfigSettings(
                    web,
                    web,
                    out lstProjectCenter,
                    out lstTaskCenter,
                    ref useResourcePool,
                    out resourcePoolUrl,
                    out resourceList,
                    out wpFields);
            }
            else
            {
                using (var site = SPContext.Current.Site)
                {
                    using (var webSite = site.OpenWeb(lockWeb))
                    {
                        GetConfigSettings(
                            web,
                            webSite,
                            out lstProjectCenter,
                            out lstTaskCenter,
                            ref useResourcePool,
                            out resourcePoolUrl,
                            out resourceList,
                            out wpFields);
                    }
                }
            }
        }

        private static void GetConfigSettings(
            SPWeb web,
            SPWeb webSite,
            out SPList lstProjectCenter,
            out SPList lstTaskCenter,
            ref bool useResourcePool,
            out string resourcePoolUrl,
            out string resourceList,
            out string wpFields)
        {
            lstProjectCenter = web.Lists[CoreFunctions.getConfigSetting(webSite, "EPMLiveWPProjectCenter")];
            lstTaskCenter = web.Lists[CoreFunctions.getConfigSetting(webSite, "EPMLiveWPTaskCenter")];

            try
            {
                useResourcePool = bool.Parse(CoreFunctions.getConfigSetting(webSite, "EPMLiveWPUseResPool"));
            }
            catch (Exception exception)
            {
                SystemTrace.WriteLine(exception.ToString());
            }

            resourcePoolUrl = CoreFunctions.getConfigSetting(webSite, "EPMLiveResourceURL", true, false);
            resourceList = CoreFunctions.getConfigSetting(webSite, "EPMLiveResourcePool");
            wpFields = CoreFunctions.getConfigSetting(webSite, "EPMLiveWorkPlannerFields");
        }
    }
}