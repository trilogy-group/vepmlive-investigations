using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using EPMLiveCore;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.Web.CommandUI;
using DiagTrace = System.Diagnostics.Trace;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:ResourcePlanningWebpart runat=server></{0}:ResourcePlanningWebpart>")]
    [XmlRoot(Namespace = "GridListView")]
    [Guid("1ad4766b-c8c2-45a0-9751-3c47bed3565e")]
    public partial class ResourcePlanning : WebPart, IWebPartPageComponentProvider
    {
        private void AddContextualTab()
        {
            var currentWeb = SPContext.Current.Web;
            var ribbon = SPRibbon.GetCurrent(Page);

            if (ribbon != null)
            {
                ribbon.Minimized = false;
                ribbon.CommandUIVisible = true;
                const string InitialTabId = "Ribbon.ListItem";

                if (!ribbon.IsTabAvailable(InitialTabId))
                {
                    ribbon.MakeTabAvailable(InitialTabId);
                }
            }

            var language = currentWeb.Language.ToString();

            Ribbon ribbon1 = SPRibbon.GetCurrent(Page);

            var ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(Resources.txtResourcePlannerTab.Replace("#language#", language));
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListContextualGroup._children");

            ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(Resources.gridribbontemplate.Replace("#language#", language));
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");
        }

        public string DelayScript
        {
            get
            {
                var serverRelativeUrl = SPContext.Current.Web.ServerRelativeUrl;
                var webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);
                return $@"
                <script type=""text/javascript"">
                //<![CDATA[
                            function _addCustomPageComponent()
                            {{
                                var _customPageComponent = new ContextualTabWebPart.CustomPageComponent('{webPartPageComponentId}',mygrid{sFullGridId},myDataProcessor{sFullGridId},'{(serverRelativeUrl == "/"
                    ? string.Empty
                    : serverRelativeUrl)}','{HttpContext.Current.Request.Url.AbsolutePath}');

                                var ribbonPageManager = SP.Ribbon.PageManager.get_instance();
                                ribbonPageManager.addPageComponent(_customPageComponent);
                                ribbonPageManager.get_focusManager().requestFocusForComponent(_customPageComponent);
                            }}

                            function _registerCustomPageComponent()
                            {{
                                SP.SOD.registerSod(""GridViewContextualTabPageComponent.js"", "" {SPContext.Current.Web.Url}\/_layouts\/epmlive\/gridlistribbon.aspx"");
                                SP.SOD.executeFunc(""GridViewContextualTabPageComponent.js"", ""ContextualWebPart.CustomPageComponent"", _addCustomPageComponent);
                            }}

                            SP.SOD.executeOrDelayUntilScriptLoaded(_registerCustomPageComponent, ""sp.ribbon.js"");
                //]]>
                </script>";
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            sFullGridId = $"{ZoneIndex}{ZoneID}";
        }

        public WebPartContextualInfo WebPartContextualInfo
        {
            get
            {
                if (SPContext.Current.ViewContext.View != null)
                {
                    var webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                    var info = new WebPartContextualInfo();
                    var contextualGroup = new WebPartRibbonContextualGroup();
                    var ribbonItemTab = new WebPartRibbonTab();
                    var ribbonListTab = new WebPartRibbonTab();
                    var ribbonTsTab = new WebPartRibbonTab();

                    //Create the contextual group object and initialize its values.
                    contextualGroup.Id = "Ribbon.ListContextualGroup";
                    contextualGroup.Command = "ListContextualGroup";
                    contextualGroup.VisibilityContext = $"CustomContextualTab{webPartPageComponentId}.CustomVisibilityContext";

                    ribbonItemTab.Id = "Ribbon.ListItem";
                    ribbonItemTab.VisibilityContext = $"GridViewListItemContextualTab{webPartPageComponentId}.CustomVisibilityContext";

                    ribbonListTab.Id = "Ribbon.List";
                    ribbonListTab.VisibilityContext = $"GridViewListContextualTab{webPartPageComponentId}.CustomVisibilityContext";

                    ribbonTsTab.Id = "Ribbon.ResourcePlanner";
                    ribbonTsTab.VisibilityContext = $"GridViewListContextualTab{webPartPageComponentId}.CustomVisibilityContext";

                    info.ContextualGroups.Add(contextualGroup);
                    info.Tabs.Add(ribbonItemTab);
                    info.Tabs.Add(ribbonListTab);
                    info.Tabs.Add(ribbonTsTab);

                    info.PageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                    return info;
                }

                return null;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            //buildParams();

            getGanttParams();

            var webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);

            if (!Page.ClientScript.IsClientScriptBlockRegistered(GetType(), $"listviewwebpart{webPartPageComponentId}"))
            {
                Page.ClientScript.RegisterClientScriptBlock(
                    GetType(),
                    $"listviewwebpart{webPartPageComponentId}",
                    $"<script language=\"javascript\">var mygrid{sFullGridId};var G2antt1{ZoneIndex}{ZoneID};</script>");
            }

            if (SPContext.Current.ViewContext.View != null)
            {
                AddContextualTab();

                var clientScript = Page.ClientScript;

                clientScript.RegisterClientScriptBlock(GetType(), "ContextualWebPart", DelayScript);
            }
        }

        public override void Dispose()
        {
            if (resWeb != null)
            {
                if (resWeb.ID != SPContext.Current.Web.ID)
                {
                    resWeb.Close();
                }
            }

            base.Dispose();
        }

        protected override void CreateChildControls()
        {
            act = new Act(SPContext.Current.Web);
            activation = act.CheckFeatureLicense(ActFeature.ResourcePlanner);

            if (activation != 0)
            {
                return;
            }

            strAction = Page.Request["action"];

            curWeb = SPContext.Current.Web;

            {
                resUrl = CoreFunctions.getConfigSetting(curWeb, "EPMLiveResourceURL");

                if (!string.IsNullOrWhiteSpace(resUrl))
                {
                    try
                    {
                        if (!resUrl.Equals(curWeb.ServerRelativeUrl, StringComparison.OrdinalIgnoreCase))
                        {
                            if (resUrl.StartsWith("/"))
                            {
                                resWeb = curWeb.Site.OpenWeb(resUrl);
                            }
                            else
                            {
                                using (var tempSite = new SPSite(resUrl))
                                {
                                    resWeb = tempSite.OpenWeb();

                                    if (!resWeb.Url.Equals(resUrl, StringComparison.OrdinalIgnoreCase))
                                    {
                                        resWeb = null;
                                    }
                                }
                            }
                        }
                        else
                        {
                            resWeb = curWeb;
                        }

                        if (resWeb != null)
                        {
                            try
                            {
                                reslist = resWeb.Lists["Resources"];
                            }
                            catch (Exception exception)
                            {
                                DiagTrace.WriteLine(exception);
                            }

                            if (reslist == null)
                            {
                                error = "Error: Resource list was not found.";
                            }
                            else
                            {
                                resview = reslist.DefaultView;
                                var viewListBuilder = new StringBuilder();

                                foreach (SPView spView in resview.Views)
                                {
                                    if (!spView.Hidden)
                                    {
                                        viewListBuilder.Append(
                                            spView.DefaultView
                                                ? $"<option selected value=\"{spView.Title.Replace(" ", "%20")}\">{spView.Title}</option>"
                                                : $"<option value=\"{spView.Title.Replace(" ", "%20")}\">{spView.Title}</option>");
                                    }
                                }

                                viewList = viewListBuilder.ToString();

                                lnk = new LinkButton();
                                lnk.Click += lnk_Click;
                                lnk.OnClientClick = $"Javascript:return postResources{ZoneIndex}{ZoneID}();";
                                lnk.Text = "<img src=\"/_layouts/images/epmlivegantt.GIF\" border=\"0\" style=\"vertical-align: middle;\"> View Resource Plan";
                                Controls.Add(lnk);
                            }

                            rcList = SPContext.Current.List;
                            var view = SPContext.Current.ViewContext.View;

                            toolbar = new ViewToolBar
                            {
                                TemplateName = "GanttViewToolBar"
                            };

                            var context = SPContext.GetContext(Context, view.ID, rcList.ID, curWeb);
                            toolbar.RenderContext = context;

                            Controls.Add(toolbar);

                            foreach (Control control in toolbar.Controls)
                            {
                                processControls(control, $"{ZoneIndex}{ZoneID}", view.ServerRelativeUrl, curWeb);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        DiagTrace.WriteLine(exception);
                    }
                }
            }
        }

        private void lnk_Click(object sender, EventArgs e)
        {
            Page.Response.Cookies.Remove(EpmLiveResourcePlanResources);
            Page.Request.Cookies.Remove(EpmLiveResourcePlanResources);

            var myCookie = new HttpCookie(EpmLiveResourcePlanResources)
            {
                ["resources"] = Page.Request["resourceList"],
                Expires = DateTime.Now.AddMinutes(30)
            };

            Page.Response.Cookies.Add(myCookie);

            strAction = string.Empty;
        }
    }
}