﻿using System;
using System.Collections.Generic;
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
        #region Properties (5) 

        public string CurrentUserAvatar { get; private set; }

        public string CurrentUserDisplayName { get; private set; }

        public string CurrentUserTimeZone { get; private set; }

        public Guid SEID { get; private set; }

        public int ToolbarDisplayItemCount
        {
            get
            {
                try
                {
                    return int.Parse(CoreFunctions.getConfigSetting(SPContext.Current.Web, "epm_ss_toolbar_itemcount"));
                }
                catch { }

                return 0;
            }
        }

        #endregion Properties 

        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e) { }

        #endregion Methods 

        #region Overrides of Control

        protected override void OnPreRender(EventArgs e)
        {
            SPContext context = SPContext.Current;
            SPWeb web = context.Web;

            SEID = Guid.NewGuid();

            string layoutPath = web.SafeServerRelativeUrl() + "/_layouts/15/epmlive/";

            SPPageContentManager.RegisterStyleFile(layoutPath + "stylesheets/SocialStream.min.css");

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "libraries/jquery.min", "libraries/handlebars-v1.3.0", "@libraries/amplify",
                "@libraries/bundles/moment", "@EPMLive.SocialStream"
            });

            SetTimeZone(web, context);

            CurrentUserDisplayName = EPMLiveCore.CoreFunctions.GetSafeUserTitle(Convert.ToString(web.CurrentUser.Name));

            try
            {
                var picture =
                    (string) (web.SiteUserInfoList.Items.GetItemById(web.CurrentUser.ID)["Picture"] ?? string.Empty);
                CurrentUserAvatar = string.IsNullOrEmpty(picture) ? string.Empty : picture.Split(',')[0].Trim();
            }
            catch { }
        }

        private void SetTimeZone(SPWeb web, SPContext context)
        {
            var dictionaryReplace = new Dictionary<string, string>
            {
                { " and ", " & " },
                { "(UTC+00:00)", "(UTC)" }
            };

            CurrentUserTimeZone = Utilities.Extensions.GetCurrentUserTimeZone(web, context, dictionaryReplace);
        }

        #endregion
    }
}