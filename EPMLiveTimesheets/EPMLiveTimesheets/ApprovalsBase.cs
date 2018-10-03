using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using Exception = System.Exception;

namespace TimeSheets
{
    public abstract partial class ApprovalsBase : WebPart
    {
        private const string LblFilter = "lblFilter";
        private const string LblFilterText = "lblFilterText";
        private const string NewMenu = "MICROSOFT.SHAREPOINT.WEBCONTROLS.NEWMENU";
        private const string ActionsMenu = "MICROSOFT.SHAREPOINT.WEBCONTROLS.ACTIONSMENU";
        private const string EditInGridButton = "EditInGridButton";
        private const string ExportToDatabase = "ExportToDatabase";
        private const string ExportToSpreadSheet = "ExportToSpreadsheet";
        private const string ViewRss = "ViewRSS";
        private const string SubscribeButton = "SubscribeButton";
        private const string ContextualWebPart = "ContextualWebPart";
        private const string LanguageId = "#language#";
        private const string NewPeriod = "NewPeriod";
        private const string EpmLiveTsPeriod = "EPMLiveTSPeriod";
        private const string PeriodText = "period";
        private const string ClosedStatus = "Closed";
        private const string WebControlsLabel = "System.Web.UI.WebControls.Label";
        protected static readonly string OpenStatus = "Open";

        protected abstract void AddContextualTab();
        protected abstract void AppendDialogWindows(HtmlTextWriter output);
        protected abstract void RenderGrid(HtmlTextWriter output, SPWeb web);

        protected string FullGridId { get; set; }
        protected string FullParamList { get; set; }
        protected int Period { get; set; }
        protected SqlConnection Connection { get; set; }
        protected SortedList Periods { get; set; } = new SortedList();
        protected string CurrentPeriodName { get; set; }
        protected string NextPeriod { get; set; }
        protected string PreviousPeriod { get; set; }
        protected string AllPeriods { get; set; }
        protected string Status { get; set; } = string.Empty;
        protected SPView View { get; set; }
        protected SPList SpList { get; set; }
        protected int Activation { get; set; }
        protected string Error { get; set; }
        protected Act Act { get; set; }

        public string PropList
        {
            get
            {
                return SPContext.Current.List.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url;
            }
        }

        public string PropView
        {
            get
            {
                return SPContext.Current.ViewContext.View.Title;
            }
        }

        protected virtual void SetToolBarControlsVisible()
        {
            // Intentionally left blank
        }

        protected static void AddContextualTab(Page page, string initialTabId, string approvalsTab)
        {
            var ribbon = SPRibbon.GetCurrent(page);

            if (ribbon != null)
            {
                ribbon.Minimized = false;
                ribbon.CommandUIVisible = true;

                if (!ribbon.IsTabAvailable(initialTabId))
                {
                    ribbon.MakeTabAvailable(initialTabId);
                }
            }

            var language = SPContext.Current.Web.Language.ToString();

            Microsoft.Web.CommandUI.Ribbon ribbon1 = SPRibbon.GetCurrent(page);

            var ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(approvalsTab.Replace(LanguageId, language));
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListContextualGroup._children");

            ribbonExtensions.LoadXml(Properties.Resources.flexible2);
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");

            ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml("<Button Id=\"Ribbon.List.Datasheet.Print\" Sequence=\"10\" Command=\"PrintGrid\" Image16by16=\"/_layouts/epmlive/images/print.gif\" Image32by32=\"/_layouts/epmlive/images/printmenu.gif\" LabelText=\"Print\" ToolTipTitle=\"Print\" ToolTipDescription=\"\" TemplateAlias=\"o1\"/>");
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.List.Share.Controls._children");

            ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(Properties.Resources.txtTimesheetTemplate.Replace(LanguageId, language));
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");
        }

        public void ProcessControls(Control parentControl, string zoneIndex, string viewUrl, SPWeb curWeb)
        {
            foreach (Control childControl in parentControl.Controls)
            {
                if (childControl.ToString() == WebControlsLabel)
                {
                    if (childControl.ID == LblFilter)
                    {
                        try
                        {
                            var lblFilterText = (Label)parentControl.FindControl(LblFilterText);
                            var lblLink = (Label)childControl;
                            lblLink.Text = $"<a href=\"Javascript:switchFilter{zoneIndex}(\'{lblFilterText.ClientID}\');\">";
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }
                    }
                }

                if (childControl.ToString().Equals(NewMenu, StringComparison.OrdinalIgnoreCase))
                {
                    childControl.Visible = false;
                }

                if (childControl.ToString().Equals(ActionsMenu, StringComparison.OrdinalIgnoreCase))
                {
                    var menu = (ActionsMenu)childControl;

                    var menuItems = new[] {EditInGridButton, ExportToDatabase, ExportToSpreadSheet, ViewRss, SubscribeButton};

                    foreach (var menuItem in menuItems)
                    {
                        try
                        {
                            menu.GetMenuItem(menuItem).Visible = false;
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }
                    }

                    menu.AddMenuItem(
                        "PrintGrid",
                        "Print Grid",
                        "/_layouts/epmlive/images/printmenu.GIF",
                        "View printable list.",
                        string.Empty,
                        $"printgrid{zoneIndex}()");
                }

                ProcessControls(childControl, zoneIndex, viewUrl, curWeb);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            BuildParams();

            var webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);

            if (!Page.ClientScript.IsClientScriptBlockRegistered(GetType(), $"listviewwebpart{webPartPageComponentId}"))
            {
                Page.ClientScript.RegisterClientScriptBlock(
                    GetType(),
                    $"listviewwebpart{webPartPageComponentId}",
                    $"<script language=\"javascript\">var mygrid{FullGridId};</script>");
            }

            AddContextualTab();

            var clientScript = Page.ClientScript;
            clientScript.RegisterClientScriptBlock(GetType(), ContextualWebPart, this.DelayScript);
        }

        private void BuildParams()
        {
            AppendParam("List", PropList);
            AppendParam("View", PropView);
            AppendParam("FilterField", Page.Request["FilterField1"]);
            AppendParam("FilterValue", Page.Request["FilterValue1"]);
            AppendParam("GridName", FullGridId);
            AppendParam("AGroups", "|");
            AppendParam("Expand", "False");

            var gridGanttSettings = new GridGanttSettings(SpList);

            AppendParam("Start", gridGanttSettings.StartDate);
            AppendParam("Finish", gridGanttSettings.DueDate);
            AppendParam("Percent", gridGanttSettings.Progress);
            AppendParam("WBS", gridGanttSettings.WBS);
            AppendParam("Milestone", gridGanttSettings.Milestone);
            AppendParam("Executive", gridGanttSettings.Executive.ToString());
            AppendParam("Info", gridGanttSettings.Information);
            AppendParam("LType", gridGanttSettings.ItemLink);
            AppendParam("RLists", gridGanttSettings.RollupLists);
            AppendParam("RSites", gridGanttSettings.RollupSites.Replace("\r\n", ","));
            AppendParam("HideNew", gridGanttSettings.HideNewButton.ToString());
            AppendParam("UsePerf", gridGanttSettings.Performance.ToString());
            AppendParam("AllowEdit", gridGanttSettings.AllowEdit.ToString());
            AppendParam("EditDefault", gridGanttSettings.EditDefault.ToString());
            AppendParam("ShowInsert", gridGanttSettings.ShowInsert.ToString());
            AppendParam("UseNew", gridGanttSettings.UseNewMenu.ToString());
            AppendParam("DisableNew", gridGanttSettings.DisableNewItemMod.ToString());
            AppendParam("NewName", gridGanttSettings.NewMenuName);
            AppendParam("UsePopup", gridGanttSettings.UsePopup.ToString());
            AppendParam("Requests", gridGanttSettings.EnableRequests.ToString());

            FullParamList = FullParamList.Substring(1);
            var toEncodeAsBytes = Encoding.ASCII.GetBytes(FullParamList);
            FullParamList = Convert.ToBase64String(toEncodeAsBytes);
        }

        private void AppendParam(string param, string val)
        {
            FullParamList += $"\n{param}\t{val}";
        }

        protected void ProcessPageRequest(SPWeb web)
        {
            if (!string.IsNullOrWhiteSpace(Page.Request[NewPeriod]))
            {
                Page.Response.Cookies.Remove(EpmLiveTsPeriod);
                Page.Request.Cookies.Remove(EpmLiveTsPeriod);

                var myCookie = new HttpCookie(EpmLiveTsPeriod)
                {
                    [PeriodText] = Page.Request[NewPeriod],
                    Expires = DateTime.Now.AddMinutes(30)
                };

                Page.Response.Cookies.Add(myCookie);
            }

            var period = string.Empty;

            if (Page.Request.Cookies[EpmLiveTsPeriod] != null)
            {
                period = Page.Request.Cookies[EpmLiveTsPeriod][PeriodText];
            }

            if (string.IsNullOrWhiteSpace(period))
            {
                using (var sqlCommand = new SqlCommand(
                    "SELECT period_id from TSPERIOD where period_start<=@dtchecked and period_end>=@dtchecked and locked = 0 and site_id=@siteid",
                    Connection)
                {
                    CommandType = CommandType.Text
                })
                {
                    sqlCommand.Parameters.AddWithValue("@dtchecked", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@siteid", web.Site.ID);

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        Period = dataReader.Read()
                            ? dataReader.GetInt32(0)
                            : int.Parse(Periods.GetKey(0).ToString());
                    }
                }
            }
            else
            {
                Period = int.Parse(period);
            }

            var tempAllPeriods = new StringBuilder(AllPeriods);

            foreach (DictionaryEntry dictionaryEntry in Periods)
            {
                tempAllPeriods.Append($",{dictionaryEntry.Value}|{dictionaryEntry.Key}");

                if (Period == (int)dictionaryEntry.Key)
                {
                    CurrentPeriodName = dictionaryEntry.Value.ToString();

                    if (Periods.IndexOfKey(dictionaryEntry.Key) > 0)
                    {
                        PreviousPeriod = Periods.GetKey(Periods.IndexOfKey(dictionaryEntry.Key) - 1).ToString();
                    }

                    if (Periods.IndexOfKey(dictionaryEntry.Key) < Periods.Count - 1)
                    {
                        NextPeriod = Periods.GetKey(Periods.IndexOfKey(dictionaryEntry.Key) + 1).ToString();
                    }
                }
            }

            AllPeriods = tempAllPeriods.ToString();

            if (AllPeriods.Length > 0)
            {
                AllPeriods = AllPeriods.Substring(1);
            }

            using (var command = new SqlCommand("SELECT locked from TSPERIOD where period_id=@periodid and site_id=@site_id", Connection)
            {
                CommandType = CommandType.Text
            })
            {
                command.Parameters.AddWithValue("@periodid", Period);
                command.Parameters.AddWithValue("@site_id", web.Site.ID);

                using (var executeReader = command.ExecuteReader())
                {
                    Status = OpenStatus;

                    if (executeReader.Read())
                    {
                        if (executeReader.GetBoolean(0))
                        {
                            Status = ClosedStatus;
                            SetToolBarControlsVisible();
                        }
                    }
                }
            }
        }

        public string DelayScript
        {
            get
            {
                var url = SPContext.Current.Web.ServerRelativeUrl;
                var webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);
                return @"
                <script type=""text/javascript"">
                //<![CDATA[
                            function _addCustomPageComponent()
                            {
                                var _customPageComponent = new ContextualTabWebPart.CustomPageComponent('" + webPartPageComponentId + @"',mygrid" + FullGridId + ",null,'" + ((url == "/") ? "" : url) + @"','" + HttpContext.Current.Request.Url.AbsolutePath + @"');

                                var ribbonPageManager = SP.Ribbon.PageManager.get_instance();
                                ribbonPageManager.addPageComponent(_customPageComponent);
                                ribbonPageManager.get_focusManager().requestFocusForComponent(_customPageComponent);
                            }

                            function _registerCustomPageComponent()
                            {
                                SP.SOD.registerSod(""GridViewContextualTabPageComponent.js"", "" " + SPContext.Current.Web.Url + @"\/_layouts\/epmlive\/gridlistribbon.aspx"");
                                SP.SOD.executeFunc(""GridViewContextualTabPageComponent.js"", ""ContextualWebPart.CustomPageComponent"", _addCustomPageComponent);
                            }

                            SP.SOD.executeOrDelayUntilScriptLoaded(_registerCustomPageComponent, ""sp.ribbon.js"");
                //]]>
                </script>";
            }
        }
    }
}
