using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using TimeSheets.Properties;

namespace TimeSheets
{
    [Guid("9C192BDD-0A80-4217-A54E-2245CFA79342")]
    [ToolboxData("<{0}:PMApprovals runat=server></{0}:PMApprovals>")]
    [XmlRoot(Namespace = "PMApprovals")]
    public class PMApprovals : ApprovalsBase, IWebPartPageComponentProvider
    {
        private const string TimeSheetText = "Timesheet";
        private const string EpmLiveTsPeriod = "EPMLiveTSPeriod";
        private readonly TimesheetMenu _timeSheetMenu = new TimesheetMenu();
        private ViewToolBar _viewToolbar;
        private DropDownList _dropDownList;
        private ImageButton _buttonNext;
        private ImageButton _buttonPrev;

        public PMApprovals()
        {
            FullGridId = ZoneIndex + ZoneID;
        }

        public WebPartContextualInfo WebPartContextualInfo
        {
            get
            {
                var webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);
                var webPartContextualInfo = new WebPartContextualInfo();
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

                ribbonTsTab.Id = "Ribbon.TimesheetPMApprovals";
                ribbonTsTab.VisibilityContext = $"GridViewListContextualTab{webPartPageComponentId}.CustomVisibilityContext";

                webPartContextualInfo.ContextualGroups.Add(contextualGroup);
                webPartContextualInfo.Tabs.Add(ribbonItemTab);
                webPartContextualInfo.Tabs.Add(ribbonListTab);
                webPartContextualInfo.Tabs.Add(ribbonTsTab);
                webPartContextualInfo.PageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                return webPartContextualInfo;
            }
        }

        protected override void AddContextualTab()
        {
            AddContextualTab(Page, "Ribbon.TimesheetPMApprovals", Resources.txtTimesheetPMApprovalsTab);
        }

        protected override void CreateChildControls()
        {
            Act = new Act(SPContext.Current.Web);
            Activation = Act.CheckFeatureLicense(ActFeature.Timesheets);

            if (Activation != 0)
            {
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
                    _viewToolbar = new ViewToolBar
                    {
                        TemplateName = "TSViewToolBar"
                    };

                    var context = SPContext.GetContext(Context, View.ID, SpList.ID, SPContext.Current.Web);
                    _viewToolbar.RenderContext = context;

                    Controls.Add(_viewToolbar);

                    foreach (Control control in _viewToolbar.Controls)
                    {
                        ProcessControls(control, FullGridId, View.ServerRelativeUrl, web);
                    }

                    _timeSheetMenu.Text = TimeSheetText;
                    _timeSheetMenu.TemplateName = "ToolbarPMMenu";
                    _timeSheetMenu.ToolTip = TimeSheetText;
                    _timeSheetMenu.MenuControl.Text = TimeSheetText;
                    _timeSheetMenu.GetMenuItem("ApproveItems").ClientOnClickScript = $"approve{FullGridId}();";
                    _timeSheetMenu.GetMenuItem("RejectItems").ClientOnClickScript = $"reject{FullGridId}();";

                    _viewToolbar.Controls[0].Controls[1].Controls[0].Controls.AddAt(6, _timeSheetMenu);

                    SPSecurity.RunWithElevatedPrivileges(
                        delegate
                        {
                            try
                            {
                                using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
                                {
                                    sqlConnection.Open();

                                    using (var sqlCommand = new SqlCommand(
                                        "SELECT * from TSPERIOD where site_id=@siteid and locked = 0 order by period_id",
                                        sqlConnection)
                                    {
                                        CommandType = CommandType.Text
                                    })
                                    {
                                        sqlCommand.Parameters.AddWithValue("@siteid", web.Site.ID);

                                        using (var dataReader = sqlCommand.ExecuteReader())
                                        {
                                            while (dataReader.Read())
                                            {
                                                _dropDownList.Items.Add(
                                                    new ListItem(
                                                        $"{dataReader.GetDateTime(1).ToShortDateString()} - {dataReader.GetDateTime(2).ToShortDateString()}",
                                                        dataReader.GetInt32(0).ToString()));
                                                Periods.Add(
                                                    dataReader.GetInt32(0),
                                                    $"{dataReader.GetDateTime(1).ToShortDateString()} - {dataReader.GetDateTime(2).ToShortDateString()}");
                                            }
                                        }

                                        _dropDownList.SelectedValue = Period.ToString();
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                Trace.WriteLine(exception);
                            }
                        });

                    if (Page.IsPostBack)
                    {
                        Page.Response.Cookies[EpmLiveTsPeriod].Value = _dropDownList.SelectedValue;
                        Page.Response.Cookies[EpmLiveTsPeriod].Expires = DateTime.Now.AddMinutes(30);
                    }

                    _dropDownList.ID = "ddlPeriod";
                    _dropDownList.SelectedIndexChanged += ddl_SelectedIndexChanged;
                    _dropDownList.AutoPostBack = true;
                    _dropDownList.EnableViewState = true;

                    _buttonNext.Click += btn_Click;
                    _buttonNext.ImageUrl = "/_layouts/epmlive/images/right.gif";
                    _buttonNext.EnableViewState = true;

                    _buttonPrev.Click += btnPrev_Click;
                    _buttonPrev.ImageUrl = "/_layouts/epmlive/images/left.gif";
                    _buttonPrev.EnableViewState = true;

                    var pnl = new Panel();
                    pnl.Controls.Add(
                        new LiteralControl(
                            "<table border=\"0\"><tr><td class=\"ms-toolbar\" valign=\"center\"><div class=\"ms-buttoninactivehover\" onmouseover=\"this.className='ms-buttonactivehover'\" onmouseout=\"this.className='ms-buttoninactivehover'\">"));
                    pnl.Controls.Add(_buttonPrev);
                    pnl.Controls.Add(new LiteralControl("</div></td><td valign=\"center\">"));
                    pnl.Controls.Add(_dropDownList);
                    pnl.Controls.Add(
                        new LiteralControl(
                            "</td><td valign=\"center\"><div class=\"ms-buttoninactivehover\" onmouseover=\"this.className='ms-buttonactivehover'\" onmouseout=\"this.className='ms-buttoninactivehover'\">"));
                    pnl.Controls.Add(_buttonNext);
                    pnl.Controls.Add(new LiteralControl("</div></td></tr></table>"));

                    _viewToolbar.Controls[0].Controls[1].Controls[0].Controls.AddAt(7, pnl);
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            _dropDownList = new DropDownList();
            _buttonNext = new ImageButton();
            _buttonPrev = new ImageButton();
            base.OnInit(e);
        }

        void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.Response.Cookies.Remove(EpmLiveTsPeriod);
            Page.Request.Cookies.Remove(EpmLiveTsPeriod);

            var myCookie = new HttpCookie(EpmLiveTsPeriod)
            {
                ["period"] = _dropDownList.SelectedValue,
                Expires = DateTime.Now.AddMinutes(30)
            };

            Page.Response.Cookies.Add(myCookie);
        }

        void btnPrev_Click(object sender, ImageClickEventArgs e)
        {
            Page.Response.Cookies.Remove(EpmLiveTsPeriod);
            Page.Request.Cookies.Remove(EpmLiveTsPeriod);

            var myCookie = new HttpCookie(EpmLiveTsPeriod)
            {
                ["period"] = (int.Parse(_dropDownList.SelectedValue) - 1).ToString(),
                Expires = DateTime.Now.AddMinutes(30)
            };

            Page.Response.Cookies.Add(myCookie);
        }

        void btn_Click(object sender, ImageClickEventArgs e)
        {
            Page.Response.Cookies.Remove(EpmLiveTsPeriod);
            Page.Request.Cookies.Remove(EpmLiveTsPeriod);

            var myCookie = new HttpCookie(EpmLiveTsPeriod)
            {
                ["period"] = (int.Parse(_dropDownList.SelectedValue) + 1).ToString(),
                Expires = DateTime.Now.AddMinutes(30)
            };

            Page.Response.Cookies.Add(myCookie);
        }

        protected override void SetToolBarControlsVisible()
        {
            _viewToolbar.Controls[0].Controls[1].Controls[0].Controls[6].Visible = false;
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            if (Activation != 0)
            {
                output.Write(Act.translateStatus(Activation));
                return;
            }

            if (_dropDownList.Items.Count <= 0)
            {
                output.Write("No Periods Defined.");
                return;
            }

            output.Write(Error);

            try
            {
                var web = SPContext.Current.Web;
                {
                    web.Site.CatchAccessDeniedException = false;
                    EnsureChildControls();

                    if (SpList != null && View != null)
                    {
                        SPSecurity.RunWithElevatedPrivileges(
                            delegate
                            {
                                try
                                {
                                    Connection = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                                    Connection.Open();

                                    ProcessPageRequest(web);

                                    var label = new Label
                                    {
                                        ID = "lblTimesheetStatus",
                                        Text = $"&nbsp;&nbsp;Period Status: <span id=\"divStatus\" class=\"ms-descriptiontext\">{Status}</span>"
                                    };
                                    _viewToolbar.Controls[0].Controls[1].Controls[0].Controls.Add(label);

                                    _dropDownList.SelectedValue = Period.ToString();

                                    if (_dropDownList.SelectedIndex == 0)
                                    {
                                        _buttonPrev.Visible = false;
                                    }

                                    if (_dropDownList.SelectedIndex == _dropDownList.Items.Count - 1)
                                    {
                                        _buttonNext.Visible = false;
                                    }

                                    _viewToolbar.RenderControl(output);

                                    RenderGrid(output, web);

                                    Connection.Close();
                                }
                                catch (Exception exception)
                                {
                                    output.Write($"Error: {exception.Message}");
                                    Trace.WriteLine(exception);
                                }
                            });
                    }

                    if (SPContext.Current.ViewContext.View != null)
                    {
                        foreach (WebPart webPart in WebPartManager.WebParts)
                        {
                            try
                            {
                                if (webPart.ToString() == "Microsoft.SharePoint.WebPartPages.XsltListViewWebPart" ||
                                    webPart.ToString() == "Microsoft.SharePoint.WebPartPages.ListViewWebPart")
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
            }
            catch (Exception exception)
            {
                output.Write($"Error (Render WebPart): {exception.Message}");
                Trace.WriteLine(exception);
            }
        }

        protected override void RenderGrid(HtmlTextWriter output, SPWeb web)
        {
            RenderGrid(
                output,
                web,
                "2",
                Resources.txtTimesheetPMApprovalsRibbonFunctions,
                "getpmapprovals",
                "TimesheetPMApprovals",
                Resources.txtPMApprovalsJS,
                Resources.txtExcels,
                true);
        }

        protected override void AppendDialogWindows(HtmlTextWriter output)
        {
            output.Write(
                $"<div id=\"tsnotesgrid{ID}\" style=\"display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width:200px;height:100px\">");
            output.Write($"<textarea id=\"tsnotes{FullGridId}\" cols=\"30\" rows=\"6\" class=\"ms-input\"></textarea>");
            output.Write("<table border=\"0\" width=\"200\"><tr><td align=\"right\">");
            output.Write($"<font class=\"ms-descriptiontext\"><a href=\"javascript:mygrid{FullGridId}.editStop();\">Close</a></font>");
            output.Write("</td></tr></table>");
            output.Write("</div>");

            output.Write(
                "<div id=\"dlgProcessing\" class=\"dialog\"><table width=\"100%\"><tr><td align=\"center\" class=\"ms-sectionheader\"><img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/>");
            output.Write("<br /><H3 class=\"ms-standardheader\">Processing Items...</h3></td></tr></table></div>");
            output.Write(
                "<div id=\"dlgEmailing\" class=\"dialog\"><table width=\"100%\"><tr><td align=\"center\" class=\"ms-sectionheader\"><img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/>");
            output.Write("<br /><H3 class=\"ms-standardheader\">Sending Emails...</h3></td></tr></table></div>");
            output.Write($"<div id=\"grid{ID}\" style=\"width:100%;display:none;\" ></div>\r\n\r\n");

            output.Write($"<div  width=\"100%\" id=\"loadinggrid{ID}\" align=\"center\">");
            output.Write("<img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading Items...");
            output.Write("</div>");
        }
    }
}
