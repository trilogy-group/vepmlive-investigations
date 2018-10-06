using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using TimeSheets.Properties;

namespace TimeSheets
{
    [Guid("275fb0de-192d-4fe0-bec3-31a255025d26")]
    [ToolboxData("<{0}:TimeSheetApprovals runat=server></{0}:TimeSheetApprovals>")]
    [XmlRoot(Namespace = "TimeSheetApprovals")]
    public class TimesheetApprovals : ApprovalsBase, IWebPartPageComponentProvider
    {
        private const string XsltListViewWebPart = "Microsoft.SharePoint.WebPartPages.XsltListViewWebPart";
        private const string ListViewWebPart = "Microsoft.SharePoint.WebPartPages.ListViewWebPart";
        private bool _disabled;

        public TimesheetApprovals()
        {
            FullGridId = ZoneIndex + ZoneID;
        }

        public WebPartContextualInfo WebPartContextualInfo
        {
            get
            {
                var webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                var info = new WebPartContextualInfo();
                var contextualGroup = new WebPartRibbonContextualGroup();
                var ribbonItemTab = new WebPartRibbonTab();
                var ribbonListTab = new WebPartRibbonTab();
                var ribbonTsTab = new WebPartRibbonTab();
                contextualGroup.Id = "Ribbon.ListContextualGroup";
                contextualGroup.Command = "ListContextualGroup";
                contextualGroup.VisibilityContext = $"CustomContextualTab{webPartPageComponentId}.CustomVisibilityContext";

                ribbonItemTab.Id = "Ribbon.ListItem";
                ribbonItemTab.VisibilityContext = $"GridViewListItemContextualTab{webPartPageComponentId}.CustomVisibilityContext";

                ribbonListTab.Id = "Ribbon.List";
                ribbonListTab.VisibilityContext = $"GridViewListContextualTab{webPartPageComponentId}.CustomVisibilityContext";

                ribbonTsTab.Id = "Ribbon.TimesheetApprovals";
                ribbonTsTab.VisibilityContext = $"GridViewListContextualTab{webPartPageComponentId}.CustomVisibilityContext";

                info.ContextualGroups.Add(contextualGroup);
                info.Tabs.Add(ribbonItemTab);
                info.Tabs.Add(ribbonListTab);
                info.Tabs.Add(ribbonTsTab);
                info.PageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                return info;
            }
        }

        protected override void AddContextualTab()
        {
            AddContextualTab(Page, "Ribbon.TimesheetApprovals", Resources.txtTimesheetApprovalsTab);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_disabled)
            {
                return;
            }

            base.OnPreRender(e);
        }

        protected override void CreateChildControls()
        {
            Act = new Act(SPContext.Current.Web);
            Activation = Act.CheckFeatureLicense(ActFeature.Timesheets);

            if (Activation != 0)
            {
                return;
            }

            if (CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSDisableApprovals").Equals(bool.TrueString, StringComparison.OrdinalIgnoreCase))
            {
                _disabled = true;
                return;
            }

            var web = SPContext.Current.Web;
            {
                try
                {
                    SpList = SPContext.Current.List;
                    View = SPContext.Current.ViewContext.View;
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                }

                if (View != null && SpList != null)
                {
                    SPSecurity.RunWithElevatedPrivileges(
                        delegate
                        {
                            try
                            {
                                Connection = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                                Connection.Open();

                                using (var sqlCommand = new SqlCommand(
                                    "SELECT * from TSPERIOD where site_id=@siteid and locked = 0 order by period_id",
                                    Connection)
                                {
                                    CommandType = CommandType.Text
                                })
                                {
                                    sqlCommand.Parameters.AddWithValue("@siteid", web.Site.ID);

                                    using (var dataReader = sqlCommand.ExecuteReader())
                                    {
                                        while (dataReader.Read())
                                        {
                                            Periods.Add(
                                                dataReader.GetInt32(0),
                                                $"{dataReader.GetDateTime(1).ToShortDateString()} - {dataReader.GetDateTime(2).ToShortDateString()}");
                                        }
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                Trace.WriteLine(exception);
                            }
                        });
                }
            }
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            if (Activation != 0)
            {
                output.Write(Act.translateStatus(Activation));
                return;
            }

            if (_disabled)
            {
                output.Write("Timesheet approvals are disabled.");
                return;
            }

            if (Periods.Count <= 0)
            {
                output.Write("No Periods Defined.");

                if (SPContext.Current.ViewContext.View != null)
                {
                    foreach (WebPart webPart in WebPartManager.WebParts)
                    {
                        try
                        {
                            if (webPart.ToString() == XsltListViewWebPart ||
                                webPart.ToString() == ListViewWebPart)
                            {
                                webPart.Visible = false;
                            }
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }
                    }
                }

                return;
            }

            output.Write(Error);

            try
            {
                var web = SPContext.Current.Web;

                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        try
                        {
                            ProcessPageRequest(web);
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }
                    });

                RenderGrid(output, web);

                if (SPContext.Current.ViewContext.View != null)
                {
                    foreach (WebPart webPart in WebPartManager.WebParts)
                    {
                        try
                        {
                            if (webPart.ToString() == XsltListViewWebPart ||
                                webPart.ToString() == ListViewWebPart)
                            {
                                webPart.Visible = false;
                            }
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                output.Write($"Error: {exception.Message}");
                Trace.WriteLine(exception);
            }

            try
            {
                Connection.Close();
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
            }
        }

        protected override void RenderGrid(HtmlTextWriter output, SPWeb web)
        {
            RenderGrid(
                output,
                web,
                "4",
                Resources.txtTimesheetApprovalsRibbonFunctions,
                "gettsapprovals",
                "TimesheetApprovals",
                Resources.txtTSApprovalsJS,
                Resources.txtExcels);

            output.Write("<input type=\"hidden\" name=\"changeRes\" value=\"yes\">");
            output.Write("<input type=\"hidden\" name=\"resourceList\" value=\"\">");
        }

        protected override void AppendDialogWindows(HtmlTextWriter output)
        {
            output.Write("<div id=\"dlgProcessing\" class=\"dialog\"><table width=\"100%\"><tr><td align=\"center\" class=\"ms-sectionheader\">");
            output.Write("<img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/><br />");
            output.Write("<H3 class=\"ms-standardheader\">Processing Timesheets...</h3></td></tr></table></div>");
            output.Write("<div id=\"dlgEmailing\" class=\"dialog\"><table width=\"100%\"><tr><td align=\"center\" class=\"ms-sectionheader\">");
            output.Write("<img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/><br />");
            output.Write("<H3 class=\"ms-standardheader\">Sending Emails...</h3></td></tr></table></div>");
            output.Write("$<div id=\"grid{ID}\" style=\"width:100%;display:none;\" ></div>\r\n\r\n");
            output.Write($"<div  width=\"100%\" id=\"loadinggrid{ID}\" align=\"center\">");
            output.Write("<img src=\"/_layouts/images/gears_anv4.gif\" style=\"vertical-align: middle;\"/> Loading Resources...");
            output.Write("</div>");
            output.Write(
                $"<div id=\"tsnotesgrid{ID}\" style=\"display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width:220px;height:115px\">");

            var disabledValue = Status != OpenStatus
                ? "disabled=\"true\""
                : string.Empty;

            output.Write($"<textarea id=\"tsnotes{FullGridId}\" cols=\"30\" rows=\"6\" class=\"ms-input\" {disabledValue}></textarea>");
            output.Write("<table border=\"0\" width=\"200\"><tr><td align=\"right\">");
            output.Write($"<font class=\"ms-descriptiontext\"><a href=\"javascript:mygrid{FullGridId}.editStop();\">Close</a></font>");
            output.Write("</td></tr></table>");
            output.Write("</div>");
        }
    }
}
