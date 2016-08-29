using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using EPMLiveCore.API;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.WebPartsHelper;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using WebPart = System.Web.UI.WebControls.WebParts.WebPart;

namespace EPMLiveCore.Layouts.epmlive.Upgraders
{
    public partial class WE432Upgrader : LayoutsPageBase
    {
        #region Fields (1) 

        private List<HtmlGenericControl> _messages;

        #endregion Fields 

        #region Methods (10) 

        // Protected Methods (2) 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var reportBiz = new ReportBiz(SPContext.Current.Site.ID);

                if (reportBiz.SiteExists()) return;

                NotConfiguredLabel.Visible = true;
                ConfiguredLabel.Visible = false;
                UpgradeButton.Enabled = false;
                UpgradeButton.CssClass += " button-green-disabled";
            }
            else
            {
                TitleLiteral.Text = "WorkEngine 4.3.2 Upgrader - Completed";
                ConfiguredLabel.Visible = false;
                UpgradeButton.Visible = false;
            }
        }

        protected void UpgradeButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                _messages = new List<HtmlGenericControl>();

                LogHeader("General Upgrade");

                SPSecurity.RunWithElevatedPrivileges(() => GeneralUpgrade(SPContext.Current.Web.Site.ID));

                LogHeader("Reporting Database Upgrade");

                foreach (HtmlGenericControl htmlGenericControl in new UpgradeReportingDBHelper().Upgrade())
                {
                    _messages.Add(htmlGenericControl);
                }
            }
            catch (Exception exception)
            {
                MessageLabel.ForeColor = Color.Red;

                foreach (
                    string message in
                        exception.Message.Split(new[] {"\r", "\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries))
                {
                    MessageLabel.Text += message + "<br/>";
                }

                MessageLabel.Visible = true;
            }
            finally
            {
                foreach (HtmlGenericControl htmlGenericControl in _messages)
                {
                    MessagePanel.Controls.Add(htmlGenericControl);
                }
            }
        }

        // Private Methods (8) 

        private void AddColumns(SPWeb web)
        {
            SPList list = web.Lists["My Work"];

            LogMessage("Adding 'Complete' column to My Work.");

            if (!list.Fields.ContainsFieldWithInternalName("Complete"))
            {
                var completeField =
                    (SPFieldBoolean) list.Fields.CreateNewField(SPFieldType.Boolean.ToString(), "Complete");

                list.Fields.Add(completeField);
                list.Update();

                LogMessage("-- Column was successfully added.");
            }
            else
            {
                LogMessage("-- Column already exists.");
            }

            LogMessage("Adding 'Timesheet' column to My Work.");

            if (!list.Fields.ContainsFieldWithInternalName("Timesheet"))
            {
                var timesheetField =
                    (SPFieldBoolean) list.Fields.CreateNewField(SPFieldType.Boolean.ToString(), "Timesheet");

                list.Fields.Add(timesheetField);
                list.Update();

                LogMessage("-- Column was successfully added.");
            }
            else
            {
                LogMessage("-- Column already exists.");
            }
        }

        private static void ConfigureMyWorkViews()
        {
            SPWeb configWeb = Utils.GetConfigWeb();

            List<MyWorkGridView> myWorkGridViews = MyWork.GetGlobalViews(configWeb).ToList();

            MyWorkGridView defaultView = myWorkGridViews.FirstOrDefault(view => view.Id.Equals("dv"));

            if (defaultView != null)
            {
                if (!defaultView.Cols.Split(',').Any(col => col.Split(':')[0].ToLower().Equals("workingon")))
                {
                    defaultView.Cols = defaultView.Cols + ",WorkingOn:95";

                    MyWork.SaveGlobalViews(defaultView, configWeb);
                }
            }

            myWorkGridViews = MyWork.GetGlobalViews(configWeb).ToList();

            bool workingOnViewExists = myWorkGridViews.Any(view => view.Name.Trim().ToLower().Equals("working on it"));

            if (!workingOnViewExists)
            {
                MyWorkGridView workingOnView = myWorkGridViews.FirstOrDefault(view => view.Id.Equals("dv"));

                if (workingOnView != null)
                {
                    workingOnView.Name = "Working On It";
                    workingOnView.Id = workingOnView.Name.Md5().ToLower();
                    workingOnView.Filters = "0|WorkingOn:1:11";
                    workingOnView.Default = false;

                    MyWork.SaveGlobalViews(workingOnView, configWeb);
                }
            }
        }

        private void GeneralUpgrade(Guid siteId)
        {
            try
            {
                using (var site = new SPSite(siteId))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        web.AllowUnsafeUpdates = true;

                        AddColumns(web);
                        UpgradeMyWork();

                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            catch (Exception exception)
            {
                LogError(exception.Message);
            }
        }

        private void LogError(string message)
        {
            var htmlGenericControl = new HtmlGenericControl("div") {InnerHtml = message};
            htmlGenericControl.Style.Add(HtmlTextWriterStyle.Color, "red");

            _messages.Add(htmlGenericControl);
        }

        private void LogHeader(string message)
        {
            _messages.Add(new HtmlGenericControl("h2") {InnerHtml = message});
        }

        private void LogMessage(string message)
        {
            _messages.Add(new HtmlGenericControl("div") {InnerHtml = message});
        }

        private static void UpdateMyWorkWebPart(SPWeb spWeb)
        {
            using (
                SPLimitedWebPartManager webPartManager = spWeb.GetLimitedWebPartManager("MyWork.aspx",
                    PersonalizationScope.Shared))
            {
                //foreach (object webPart in webPartManager.WebParts.Cast<object>().Where(webPart => webPart is MyWorkWebPart))
                foreach (object webPart in webPartManager.WebParts.Cast<object>().Where(webPart => WebPartsReflector.IsWebpartMyWorkWebPart(webPart)))
                {
                    //((MyWorkWebPart) webPart).Height = string.Empty;
                    WebPartsReflector.SetWebPartProperty(webPart, "Height", string.Empty);
                    webPartManager.SaveChanges((WebPart) webPart);
                }
            }
        }

        private void UpgradeMyWork()
        {
            LogMessage("Upgrading My Work WebPart.");

            using (var spSite = new SPSite(SPContext.Current.Site.ID))
            {
                SPWebCollection spWebCollection = spSite.AllWebs;
                for (int i = 0; i < spWebCollection.Count; i++)
                {
                    using (SPWeb web = spWebCollection[i])
                    {
                        using (SPWeb spWeb = spSite.OpenWeb(web.ID))
                        {
                            LogMessage("-- Web: " + spWeb.ServerRelativeUrl);

                            spWeb.AllowUnsafeUpdates = true;

                            UpdateMyWorkWebPart(spWeb);
                            ConfigureMyWorkViews();

                            spWeb.AllowUnsafeUpdates = false;
                        }
                    }
                }
            }
        }

        #endregion Methods 
    }
}