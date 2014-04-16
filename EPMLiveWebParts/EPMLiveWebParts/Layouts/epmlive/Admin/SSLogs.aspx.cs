using System;
using System.Linq;
using System.Web.Script.Serialization;
using EPMLiveCore;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.Layouts.epmlive.Admin
{
    public partial class SSLogs : LayoutsPageBase
    {
        #region Properties (1) 

        public string CurrentUserTimeZone { get; private set; }

        #endregion Properties 

        #region Methods (2) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            string layoutPath = SPContext.Current.Web.SafeServerRelativeUrl() + "/_layouts/15/epmlive/";

            SPPageContentManager.RegisterStyleFile(layoutPath + "stylesheets/SocialStream.Logs.min.css");
            SPPageContentManager.RegisterStyleFile(layoutPath + "javascripts/libraries/highlight/styles/vs.css");

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "libraries/jquery.min", "libraries/handlebars-v1.3.0",
                "@libraries/amplify", "@libraries/bundles/moment",
                "libraries/highlight/highlight.pack", "@EPMLive.SocialStream.Logs"
            });

            SetTimeZone(SPContext.Current.Web, SPContext.Current);
        }

        // Private Methods (1) 

        private void SetTimeZone(SPWeb web, SPContext context)
        {
            CurrentUserTimeZone = "null";

            try
            {
                SPTimeZone spTimeZone = (web.CurrentUser.RegionalSettings ?? context.RegionalSettings).TimeZone;
                string spTzName = spTimeZone.Description.Replace(" and ", " & ");

                TimeZoneInfo timeZone = (from tz in TimeZoneInfo.GetSystemTimeZones()
                    let tzName = tz.DisplayName.Replace(" and ", " & ")
                    where tzName.Equals(spTzName)
                    select tz).First();

                var timeZoneInfo = new
                {
                    id = timeZone.Id,
                    displayName = timeZone.DisplayName,
                    olsonName = timeZone.OlsonName(),
                    standardName = timeZone.StandardName,
                    daylightName = timeZone.DaylightName,
                    baseUtcOffset = timeZone.BaseUtcOffset,
                    supportsDaylightSavingTime = timeZone.SupportsDaylightSavingTime
                };

                CurrentUserTimeZone = new JavaScriptSerializer().Serialize(timeZoneInfo);
            }
            catch { }
        }

        #endregion Methods 
    }
}