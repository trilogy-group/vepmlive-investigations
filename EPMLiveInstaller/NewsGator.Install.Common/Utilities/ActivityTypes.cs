using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Resources;

namespace NewsGator.Install.Common.Utilities
{
    internal static class ActivityTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static Collection<Microsoft.Office.Server.ActivityFeed.ActivityType> GetInstalledActivityTypes(OutputManager outputManager)
        {
            SPSite site = null;
            SPServiceContext context = null;

            try
            {                
                site = SPWebService.AdministrationService.WebApplications.First().Sites.First();
                context = SPServiceContext.GetContext(site);

                var am = new Microsoft.Office.Server.ActivityFeed.ActivityManager(null, context);
                var activityTypes = am.ActivityTypes;

                return activityTypes.ToCollection();
            }
            catch (Exception exception)
            {
                if (outputManager != null)
                    outputManager.WriteError(string.Format(CultureInfo.CurrentCulture, Exceptions.ErrorGettingActivityTypes, exception.Message), exception);
            }
            finally
            {
                if (site != null)
                    site.Dispose();
            }

            return null;
        }
    }
}
