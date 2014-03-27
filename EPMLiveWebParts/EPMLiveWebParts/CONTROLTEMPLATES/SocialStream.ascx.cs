using System;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using EPMLiveCore;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.CONTROLTEMPLATES
{
    public partial class SocialStream : UserControl
    {
        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e) { }

        #endregion Methods 

        #region Overrides of Control

        protected override void OnPreRender(EventArgs e)
        {
            var context = SPContext.Current;
            var web = context.Web;

            string layoutPath = web.SafeServerRelativeUrl() + "/_layouts/15/epmlive/";

            SPPageContentManager.RegisterStyleFile(layoutPath + "stylesheets/SocialStream.min.css");

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "libraries/jquery.min", "libraries/handlebars-v1.3.0", "@libraries/amplify", "@libraries/bundles/moment",
                "@EPMLive.SocialStream"
            });

            CurrentUserTimeZone = "null";

            try
            {
                var spTimeZone = (web.CurrentUser.RegionalSettings ?? context.RegionalSettings).TimeZone;

                var timeZone = TimeZoneInfo.GetSystemTimeZones().First(t => t.DisplayName.Equals(spTimeZone.Description));

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

        #endregion

        public string CurrentUserTimeZone { get; private set; }
    }
}