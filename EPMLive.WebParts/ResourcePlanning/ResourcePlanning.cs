using System;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

using System.Text;

using System.Text.RegularExpressions;

using System.Collections;

using System.Xml;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:ResourcePlanningWebpart runat=server></{0}:ResourcePlanningWebpart>")]
    [XmlRoot(Namespace = "GridListView")]
    [Guid("1ad4766b-c8c2-45a0-9751-3c47bed3565e")]
    public class ResourcePlanning : Microsoft.SharePoint.WebPartPages.WebPart, IWebPartPageComponentProvider
    {
        private SPList reslist = null;
        private SPList rcList;
        private SPView resview = null;
        private string resUrl;
        int activation;

        private ViewToolBar toolbar;
        private SPWeb resWeb;
        private SPWeb curWeb;
        private string viewList = "";
        private string strCurrentView;
        private string strAction = "";

        private LinkButton lnk;
        private EPMLiveCore.Act act;

        private string sResourceList = "";

        string error = "";
        string sParams = "";

        private string sFullGridId = "";

        private void AddContextualTab()
        {

            SPWeb web = SPContext.Current.Web;
            var ribbon = SPRibbon.GetCurrent(Page);
            if (ribbon != null)
            {
                ribbon.Minimized = false;
                ribbon.CommandUIVisible = true;
                const string initialTabId = "Ribbon.ListItem";
                if (!ribbon.IsTabAvailable(initialTabId))
                    ribbon.MakeTabAvailable(initialTabId);


            }

            string language = web.Language.ToString();

            Microsoft.Web.CommandUI.Ribbon ribbon1 = SPRibbon.GetCurrent(this.Page);

            XmlDocument ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(Properties.Resources.txtResourcePlannerTab.Replace("#language#", language));
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListContextualGroup._children");

            ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(Properties.Resources.gridribbontemplate.Replace("#language#", language));
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");

        }

        public string DelayScript
        {
            get
            {
                string url = SPContext.Current.Web.ServerRelativeUrl;
                string webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);
                return @"
                <script type=""text/javascript"">
                //<![CDATA[
                            function _addCustomPageComponent()
                            {
                                var _customPageComponent = new ContextualTabWebPart.CustomPageComponent('" + webPartPageComponentId + @"',mygrid" + sFullGridId + ",myDataProcessor" + sFullGridId + @",'" + ((url == "/") ? "" : url) + @"','" + HttpContext.Current.Request.Url.AbsolutePath + @"');

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

        protected override void OnLoad(EventArgs e)
        {
            sFullGridId = this.ZoneIndex + this.ZoneID;


        }

        public WebPartContextualInfo WebPartContextualInfo
        {
            get
            {
                if (SPContext.Current.ViewContext.View != null)
                {
                    string webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                    WebPartContextualInfo info = new WebPartContextualInfo();
                    WebPartRibbonContextualGroup contextualGroup = new WebPartRibbonContextualGroup();
                    WebPartRibbonTab ribbonItemTab = new WebPartRibbonTab();
                    WebPartRibbonTab ribbonListTab = new WebPartRibbonTab();
                    WebPartRibbonTab ribbonTsTab = new WebPartRibbonTab();
                    //Create the contextual group object and initialize its values.
                    contextualGroup.Id = "Ribbon.ListContextualGroup";
                    contextualGroup.Command = "ListContextualGroup";
                    contextualGroup.VisibilityContext = "CustomContextualTab" + webPartPageComponentId + ".CustomVisibilityContext";

                    ribbonItemTab.Id = "Ribbon.ListItem";
                    ribbonItemTab.VisibilityContext = "GridViewListItemContextualTab" + webPartPageComponentId + ".CustomVisibilityContext";

                    ribbonListTab.Id = "Ribbon.List";
                    ribbonListTab.VisibilityContext = "GridViewListContextualTab" + webPartPageComponentId + ".CustomVisibilityContext";

                    ribbonTsTab.Id = "Ribbon.ResourcePlanner";
                    ribbonTsTab.VisibilityContext = "GridViewListContextualTab" + webPartPageComponentId + ".CustomVisibilityContext";

                    info.ContextualGroups.Add(contextualGroup);
                    info.Tabs.Add(ribbonItemTab);
                    info.Tabs.Add(ribbonListTab);
                    info.Tabs.Add(ribbonTsTab);
                    
                    info.PageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                    return info;
                }
                else
                {
                    return null;
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {

            base.OnPreRender(e);

            //buildParams();

            sParams = getGanttParams();

            string webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);
 
            if (!Page.ClientScript.IsClientScriptBlockRegistered(base.GetType(), "listviewwebpart" + webPartPageComponentId))
                Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "listviewwebpart" + webPartPageComponentId, "<script language=\"javascript\">var mygrid" + sFullGridId + ";var G2antt1" + this.ZoneIndex + this.ZoneID + ";</script>");

            if (SPContext.Current.ViewContext.View != null)
            {

                //if (!Page.ClientScript.IsClientScriptBlockRegistered(base.GetType(), "listviewwebpart"))
                //    Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "listviewwebpart", "<script language=\"javascript\">" + Properties.Resources.txtRibbonScripts + "</script>");

                AddContextualTab();

                ClientScriptManager clientScript = this.Page.ClientScript;

                clientScript.RegisterClientScriptBlock(this.GetType(), "ContextualWebPart", this.DelayScript);
            }

        }

        public ResourcePlanning()
        {
        }

        public override void Dispose()
        {
            if (resWeb != null)
                if (resWeb.ID != SPContext.Current.Web.ID)
                    resWeb.Close();
            base.Dispose();
        }

        protected override void CreateChildControls()
        {

            act = new EPMLiveCore.Act(SPContext.Current.Web );
            activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.ResourcePlanner);

            if (activation != 0)
                return;

            strAction = Page.Request["action"];

            curWeb = SPContext.Current.Web;

            {
                resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(curWeb, "EPMLiveResourceURL");

                if (resUrl != "")
                {
                    try
                    {

                        if (resUrl.ToLower() != curWeb.ServerRelativeUrl.ToLower())
                        {
                            if (resUrl.StartsWith("/"))
                            {
                                resWeb = curWeb.Site.OpenWeb(resUrl);
                            }
                            else
                            {
                                using (SPSite tempSite = new SPSite(resUrl))
                                {
                                    resWeb = tempSite.OpenWeb();
                                    if (resWeb.Url.ToLower() != resUrl.ToLower())
                                    {
                                        resWeb = null;
                                    }
                                }
                            }
                        }
                        else
                            resWeb = curWeb;

                        if (resWeb != null)
                        {
                            try
                            {
                                reslist = resWeb.Lists["Resources"];
                            }
                            catch { }
                            if (reslist == null)
                            {
                                error = "Error: Resource list was not found.";
                            }
                            else
                            {
                                resview = reslist.DefaultView;

                                //viewList = "<ie:menuitem id=\"zz29_DefaultView\" type=\"option\" onMenuClick=\"changeview" + this.ZoneIndex + this.ZoneID + "('" + reslist.DefaultView.Title.Replace(" ", "%20") + "');\" text=\"" + reslist.DefaultView.Title + "\" menuGroupId=\"100\"></ie:menuitem>\r\n";
                                strCurrentView = reslist.DefaultView.Title;
                                foreach (SPView vw in resview.Views)
                                {
                                    if (!vw.Hidden)
                                    {
                                        if(vw.DefaultView)
                                            viewList += "<option selected value=\"" + vw.Title.Replace(" ", "%20") + "\">" + vw.Title + "</option>";
                                        else
                                            viewList += "<option value=\"" + vw.Title.Replace(" ", "%20") + "\">" + vw.Title + "</option>";
                                        //viewList += "<ie:menuitem id=\"zz31_View2\" type=\"option\" onMenuClick=\"changeview" + this.ZoneIndex + this.ZoneID + "('" + vw.Title.Replace(" ", "%20") + "');\" text=\"" + vw.Title + "\" menuGroupId=\"300\"></ie:menuitem>";
                                    }
                                }

                                lnk = new LinkButton();
                                lnk.Click += new EventHandler(lnk_Click);
                                lnk.OnClientClick = "Javascript:return postResources" + this.ZoneIndex + this.ZoneID + "();";
                                lnk.Text = "<img src=\"/_layouts/images/epmlivegantt.GIF\" border=\"0\" style=\"vertical-align: middle;\"> View Resource Plan";
                                Controls.Add(lnk);

                            }
                            rcList = SPContext.Current.List;
                            SPView view = SPContext.Current.ViewContext.View;

                            toolbar = new ViewToolBar();
                            toolbar.TemplateName = "GanttViewToolBar";

                            SPContext context = SPContext.GetContext(this.Context, view.ID, rcList.ID, curWeb);
                            toolbar.RenderContext = context;

                            Controls.Add(toolbar);


                            foreach (Control control in toolbar.Controls)
                            {
                                processControls(control, this.ZoneIndex + this.ZoneID, view.ServerRelativeUrl, curWeb);
                            }

                        }
                    }
                    catch { }


                }
            }



        }
        protected override void RenderWebPart(HtmlTextWriter output)
        {

            output.Write("<B><font color=\"red\">" + error + "</font></b>");

            if (activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }

            if (reslist == null)
                return;

            if (resUrl != "" && resWeb != null)
            {
                output.Write("<script language=\"javascript\">");
                output.Write("var myDataProcessor" + sFullGridId + " = new fakeGridObject();");
                output.Write("function fakeGridObject(){}");
                output.Write("</script>");

                //if (Page.Response.Cookies["EPMLiveResourcePlanResources"].Value != null)
                //    sResourceList = Page.Response.Cookies["EPMLiveResourcePlanResources"]["resources"];
                //else
                if(Page.Request.Cookies["EPMLiveResourcePlanResources"] != null)
                    sResourceList = Page.Request.Cookies["EPMLiveResourcePlanResources"]["resources"];
                else
                    sResourceList = "";

                try
                {
                    sResourceList = sResourceList.Replace("|", ";#");
                }
                catch { }
                if (sResourceList == null || sResourceList == "" || strAction == "changeRes")
                {
                    string resToolbar = Properties.Resources.txtResourcePlannerBottom;
                    resToolbar = resToolbar.Replace("#lists#", viewList);
                    resToolbar = resToolbar.Replace("#gridid#", this.ZoneIndex + this.ZoneID);

                    output.Write(Properties.Resources.txtResourcePlannerTop);

                    if (lnk != null)
                        lnk.RenderControl(output);

                    output.Write(resToolbar);

                    renderGrid(output);
                }
                else
                {
                    output.Write("<script language=\"javascript\">");
                    output.Write("mygrid" + sFullGridId + " = new fakeGridObject();");
                    ///////////////////////
                    //CUSTOM PROPERTIES
                    

                    output.WriteLine(Properties.Resources.txtResourcePlannerRibbonScripts.Replace("#gridid#", sFullGridId));

                    output.WriteLine("mygrid" + sFullGridId + "._webpartid = '" + this.ID + "';");

                    string image = "/_layouts/" + resWeb.Language + "/images/formatmap32x32.png";
                    try
                    {
                        output.WriteLine("mygrid" + sFullGridId + "._modifylist = " + reslist.DoesUserHavePermissions(SPBasePermissions.ManageLists).ToString().ToLower() + ";");
                    }
                    catch
                    {
                        output.WriteLine("mygrid" + sFullGridId + "._modifylist = false;");
                    }
                    try
                    {
                        output.WriteLine("mygrid" + sFullGridId + "._listperms = " + reslist.DoesUserHavePermissions(SPBasePermissions.ManagePermissions).ToString().ToLower() + ";");
                    }
                    catch
                    {
                        output.WriteLine("mygrid" + sFullGridId + "._listperms = false;");
                    }
                    output.WriteLine("mygrid" + sFullGridId + "._shownewmenu = false;");
                    output.WriteLine("mygrid" + sFullGridId + "._allowedit = true;");
                    SPView view = SPContext.Current.ViewContext.View;
                    output.WriteLine("mygrid" + sFullGridId + "._listid = '" + HttpUtility.UrlEncode(rcList.ID.ToString()).ToUpper() + "';");
                    output.WriteLine("mygrid" + sFullGridId + "._viewid = '" + HttpUtility.UrlEncode(view.ID.ToString()).ToUpper() + "';");
                    output.WriteLine("mygrid" + sFullGridId + "._viewurl = '" + view.ServerRelativeUrl.Replace(" ", "%20") + "';");
                    output.WriteLine("mygrid" + sFullGridId + "._viewname = '" + view.Title + "';");
                    output.WriteLine("mygrid" + sFullGridId + "._basetype = '" + reslist.BaseType + "';");
                    output.WriteLine("mygrid" + sFullGridId + "._templatetype = '" + (int)reslist.BaseTemplate + "';");
                    string url = resWeb.ServerRelativeUrl;
                    output.WriteLine("mygrid" + sFullGridId + "._cururl = '" + ((url == "/") ? "" : url) + "';");

                    output.WriteLine("mygrid" + sFullGridId + ".getUserData = function(item, item2){return '0,0,0,0,0,0,0,0,0,0,0,0,0,0';}");
                    output.WriteLine("mygrid" + sFullGridId + ".getSelectedRowId = function(){return '0';}");
                    
                    //output.WriteLine("mygrid" + sFullGridId + "._rolluplists = '" + rollupLists.Replace(",", ";").Replace("|", ",") + "';");
                    //StringBuilder sbExcel = new StringBuilder();

                    //sbExcel.Append(HttpUtility.UrlEncode(((resweb.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl)).Replace("%", @"\u00"));
                    //sbExcel.Append(@"\u002f_vti_bin\u002fowssvr.dll?CS=65001\u0026Using=_layouts\u002fquery.iqy\u0026List=");
                    //sbExcel.Append(@"\u00257B");
                    //sbExcel.Append(list.ID.ToString().ToUpper().Replace("-", @"\u00252D").ToString());
                    //sbExcel.Append(@"\u00257D");
                    //sbExcel.Append(@"\u0026View=\u00257B");
                    //sbExcel.Append(view.ID.ToString().ToUpper().Replace("-", @"\u00252D").ToString());
                    //sbExcel.Append(@"\u00257D");
                    //sbExcel.Append(@"\u0026RootFolder=");
                    //sbExcel.Append(System.IO.Path.GetDirectoryName(view.ServerRelativeUrl).Replace(@"\", @"\u00252F"));
                    //sbExcel.Append(@"\u0026CacheControl=1");

                    output.WriteLine("mygrid" + sFullGridId + "._excell = '';");

                    output.WriteLine("mygrid" + sFullGridId + "._gridid = '" + sFullGridId + "';");
                    StringBuilder sbForms = new StringBuilder();
                    foreach (SPForm form in reslist.Forms)
                    {
                        switch (form.Type)
                        {
                            case PAGETYPE.PAGE_DISPLAYFORM:
                                sbForms.Append("<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay' CommandValueId='" + form.ServerRelativeUrl + "' Command='EditDefaultForm' Image16by16='/_layouts/" + resWeb.Language + "/images/formatmap16x16.png' Image16by16Top='-176' Image16by16Left='-16' Image32by32='/_layouts/" + resWeb.Language + "/images/formatmap32x32.png' Image32by32Top='-256' Image32by32Left='-320' LabelText='Default Display Form'/>");
                                break;
                            case PAGETYPE.PAGE_EDITFORM:
                                sbForms.Append("<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay' CommandValueId='" + form.ServerRelativeUrl + "' Command='EditDefaultForm' Image16by16='/_layouts/" + resWeb.Language + "/images/formatmap16x16.png' Image16by16Top='-32' Image16by16Left='-80' Image32by32='/_layouts/" + resWeb.Language + "/images/formatmap32x32.png' Image32by32Top='-96' Image32by32Left='-448' LabelText='Default Edit Form'/>");
                                break;
                            case PAGETYPE.PAGE_NEWFORM:
                                sbForms.Append("<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay' CommandValueId='" + form.ServerRelativeUrl + "' Command='EditDefaultForm' Image16by16='/_layouts/" + resWeb.Language + "/images/formatmap16x16.png' Image16by16Top='-128' Image16by16Left='-224' Image32by32='/_layouts/" + resWeb.Language + "/images/formatmap32x32.png' Image32by32Top='-128' Image32by32Left='-96' LabelText='Default New Form'/>");
                                break;
                        };

                    }
                    output.WriteLine("mygrid" + sFullGridId + "._formmenus = \"" + sbForms + "\";");
                    //////////////////////
                    output.Write("</script>");
                    renderGantt(output);
                }
            }
            else
            {
                output.Write("The Resource Pool has not been configured.");
                return;
            }

            foreach (System.Web.UI.WebControls.WebParts.WebPart wp in WebPartManager.WebParts)
            {
                try
                {
                    if (wp.ToString() == "Microsoft.SharePoint.WebPartPages.XsltListViewWebPart" || wp.ToString() == "Microsoft.SharePoint.WebPartPages.ListViewWebPart")
                    {
                        wp.Visible = false;
                    }
                }
                catch { }
            }
        }

        void lnk_Click(object sender, EventArgs e)
        {
            Page.Response.Cookies.Remove("EPMLiveResourcePlanResources");
            Page.Request.Cookies.Remove("EPMLiveResourcePlanResources");

            HttpCookie myCookie = new HttpCookie("EPMLiveResourcePlanResources");
                        
            myCookie["resources"] = Page.Request["resourceList"];
            myCookie.Expires = DateTime.Now.AddMinutes(30);
            Page.Response.Cookies.Add(myCookie);

            strAction = "";
        }



        private void renderGantt(HtmlTextWriter output)
        {
            SPList list = SPContext.Current.List;
            SPView view = SPContext.Current.ViewContext.View;
            toolbar.RenderControl(output);
            StringBuilder sbTemplateList = new StringBuilder();

            double nonwork = 0;

            int work = resWeb.Site.RootWeb.RegionalSettings.WorkDays;
            for (byte x = 0; x < 7; x++)
            {
                if (((work >> x) & 0x01) != 0x01)
                {
                    nonwork += Math.Pow(2, 6 - x);
                }
            }


            StringBuilder sb = new StringBuilder(Properties.Resources.TextFile1.Replace("\r\n", "\\r\\n").Replace("\"", "`").Replace("#nonworkingdays#", nonwork.ToString()));

            string height = "";

            foreach (char c in Height.ToCharArray())
            {
                int temp = 0;
                if (int.TryParse(c.ToString(), out temp))
                    height += c;
            }
            if (height == "")
                height = "450";
            else
                height = (int.Parse(height) - 30).ToString();

            StringBuilder images = new StringBuilder();

            images.Append("HTMLPicture(`red.gif`) = `gBHJJGHA5MIQAEIcx0ACSFQfehzOr3TSbVBVJbTORvcxkMi5LhVXBSJb+fj8fCeUDRLJWeC/Xr0NJsaJMJTiRCEeyhUTTJZJdSORz0NxwayBPz4UakeRoNa3IxAdxxONTOT7d7vcpcLq2Hg1dSVSr0aDPbhvNbxYbBb5zN7zPR8fLlcj8ej0eRtNztWaxapqNDsNBoebMZT1aLQejOZjhQR+d6FQriPp6bRWKTwMZkeSNRzNMJbebHYzvW61ahoMz2TadbhgLjzOx4eKcTbgPJ2ezabLeOhweRfMTsVCme7cbbgOhxcB2ObcLZXbxyNr5czlahkMT1Uajbx1OLvLxgeJ0OrpUahejPZr3UqmauVeCKRTgNxrcByNz0T6feZHEeb4/Dyd6hHGQxBm8NY0GmMQwHmMozm4MownoSBJKwdxzEiRxvDiNpzEmR53l0XBvjgNp5keSBvvAexrmsb8PnqSRKRONhvLcfh5nmkx9noRhHNeLp1E+Tp5mWZJ2joOhzk2S5ujWM5bDkNRZDUMRPiKHR/y7LwATBMMxTHMkyzGEJ8gIAMwIYFkxIQhAAAOZZADoQRBDgOQADkOBBkUQQ4gMJgOAeCICAOOJFjoAYJhwKAKASAQshYGgBkUOIJikNwHCmAQYByLYfisSpBAMIoHBEHQViaMwPi0Lo2gsQgYiWIwSjQDoqBmOYlCAJAFESOQOAoGoPCSDIhjOBYvguAICjkhgHk6MA3h8OYRhaDAAgkCoADoOQIgEKIuC8BAxAyNgyhOBgNG4OACDIHYFjmKBGCyQYQEKSYLgaCRohySATCYA4KhAGBUHSEJxmSSIGkGcRMGAERSCUGwJCCNhcEAAAlmgAARBCNxQDGOBCgOAgokWcQsCgKBQEEQwDA2JQtBUOgkFCUpPh+Ac1h2gIA=`\\r\\n");
            images.Append("HTMLPicture(`green.gif`) = `gBHJJGHA5MIQAEIcxsAB6ZCPJy2NZ9ZKSFBhD53YyMN7EQxKWpoObFRJHWZlNjBQSAZSUKaAJZCQxFGJ/G5kVBvfD7fBFVJdNi4PhsYSDLChMZ5YyNMKlNRxXSCHaWJY6S5LJKJJbyfDzKqdLxNWpqKaBJj1fL2TbEUDleDmbzsb6sZ6wKCZLKvaCyNyUM5fTRhKCWKxSUJfLq8O5kXx8IiaKZeRZYKS3NxeUBkcDtcTzfD0ZziaOYMadYqhN64PzfdjgKSyNTJcDMKS1NpSTZaKydL6vZ6yL6hlC3PhUThdQi2RKaYaeMaoNhYWpwMq4PA5QQ+LagMRiTZkbLpbZiURoYjcY5cT5iJiqMa5ay8JqzNJ4V59LaRLLK2ZrYBBFqahcrWT44FWOw3luPosE4MA1lQOJDlwRg0FsPApFALztjIdJ5HUSxgk3EBNDaVY6iaTwtjeYZCnsfR7DOUrblkNYyFuO5IF8Sw5FaPI4EsNQ0kgMQhjoHR/yRJIASXJkmydJ8oSjKUpyWEJ8gIAMloYFkmoQhAAAOX5ADYQRBDQNQBjUNBBkUQQ0gyCoLAoCIJgYNJFjYBYHAUAQAAIA4CgkLQOkUNJMk2TpPiGMYjBYQYMk0ThPASJQfiSG4nkICpTFiFwvC4NYjhMEo2DUCwABoHowgSGQPg8B4pDOE41DYAYKCqKYgB4MosA0GAui2GwOAGYYIiCEIHh2KgYjEMwfBwAIIGkNAJiyGYajWF4NBIDYWgCAwLkSNgMCIIJxAIZQNAgL5kHoIZoDAKANAoFRWC4MIRBEY4hAYSoDBaABJiERBHBEEYGBAYBYGAKQNBEFZLBoQI4FCIIjCWNgFA6AQEFmcxRCAAAdoCA`\\r\\n");
            images.Append("HTMLPicture(`checkmark.gif`) = `gBHJJGHA5MIPAAMADmIwAcbpcqKYxAdDrdKUZI9Si9JRkVhkRizRzJarNZbTZjveLwSy2SK7Zi+KK0JChWqfYbVY50WJXQauSCDYhBNq+IiSWUSazJVzCV73fL4bLhba2agzXTKXbPcLXQC2Ja1Zq5OK3IiUY5VWbDWrteDtbTpWS8baQV7FV6UXZLVbKWysaZwcjqcyMXJ3Ki5I5oXpFYLSYaUWx8TC5QyIYpAYrcPCmZ5FVDCSJsWZTX7PYDodjpYbTVRgVxLSbIHqLWSEOa0Kj83iNY4+fD6fKsYo5Vi6VC4aalVbBVKxYqOcTnciMWKOUy1TiMXo/f/fAHh8Xj8nl83n9Hp9Xr9nt93v+HxEL5AgB8MNFnjhEKAAHMRACMQRBkGHgRgaHwgAWQhGAUEQQh+FYLEYQYKg8EwUA0ShBgAB4AhkA5GA+BBBiGCQGBKRgABqIIBCMC4bBSCBGBAGIXhgFgdAMFQCgSRgThaIoXAigoOgoTYjA4DYBh2G4JmSQQHAIDASCEaJBBmHoiGwQYMhoZJAgAHaAg==`\\r\\n");
            images.Append("HTMLPicture(`yellow.gif`) = `gBHJJGHA5MIQAEIcxbADzZqKcCPHDxYJvbJzA7yYp4erVTj4cC1eC+Mz5c7FezZUr0aKTdqyJrvXReeTJQL6dbMfDkXr3bqtdy2KrtV5FciZITqVJDd7FR7gRAadi4OTsWBScSQFruYKHcqiKjmTQufToZboUZEdSsLDuWpUdayMjlTAqdisITtWxZejWU7qU46ejXVTvXpody5McyMjxYBtu5FebMST0aCSeLCO7qUo1zkTYR1dapH7uWhTdivJk1QV9T7tWpZebOSLrVRBdq0Kz8eThfz8fOAHL+fLzdy4ME4aMgXOwLDsVZGdSmG+2H71bCldqxJbwXhmerTTj0aSZf7+frtWZT3JReTIQL3cS6dKjGLww/THEsTr8eZxpYShukIExyE6KKvi0f8FwYAEHQfCEIwlCcKQrC0LwxDMNQeEJ8gIAMHIYFkIIQhAAAOYRAC2QRBCyK4BiuLJBkUQQsA2DQShuFoLgmLBFi2AIKgcI4ZhSGoZAKEIAkULBMgQFAhC0HgWAUAAPkqQQNgcBAHh0H4tB6GIAAaAgMkIDRZgMHYOi0KojF2AQPESK4TgeAwICeF4tCUIYCAEA4MCuLYBigZwEisIgmCAKRrAYEABi2K4qAgBIChcGAcCKFYDgYCIKGyLILnYBQbCaKITCcegLDgJBaDKIQAisEhLDQBIZBKYQBASCwDDCBJQhWRJFAcHIjB4Ch4iUKBAAeao0HwDBAiIQQECiRZYDIeBAACAgCgcCwdC0FQ6EQUBSk2G4BxAHaAg`\\r\\n");

            //try
            //{
            //    string[] strImages = System.Configuration.ConfigurationManager.AppSettings["ganttimages"].ToString().Split(',');
            //    foreach (string strImage in strImages)
            //        images.Append("HTMLPicture(`" + strImage.ToLower() + "`) = `" + ImageManip.ImageToBase64(strImage.ToLower()) + "`\\r\\n");
            //}
            //catch { }

            sb = sb.Replace("#Images#", images.ToString());

            StringBuilder columns = new StringBuilder();
            SPViewFieldCollection vfc = view.ViewFields;
            foreach (string field in vfc)
            {
                SPField spfield = list.Fields.GetFieldByInternalName(field);
                switch (spfield.Type)
                {
                    case SPFieldType.Number:
                    case SPFieldType.Currency:
                    case SPFieldType.DateTime:
                    case SPFieldType.Counter:
                        columns.Append("Columns(`" + spfield.Title + "`).Alignment = 2\\r\\n");
                        break;
                    case SPFieldType.Calculated:
                        if (spfield.Description == "Indicator")
                            columns.Append("Columns(`" + spfield.Title + "`).Alignment = 1\\r\\n");
                        else
                            columns.Append("Columns(`" + spfield.Title + "`).Alignment = 2\\r\\n");
                        break;
                    default:
                        columns.Append("Columns(`" + spfield.Title + "`).Alignment = 0\\r\\n");
                        break;
                }
                if (spfield.InternalName == "StartDate")
                    columns.Append("Columns(`" + spfield.Title + "`).Def(18) = 1\\r\\n");
                if (spfield.InternalName == "DueDate")
                    columns.Append("Columns(`" + spfield.Title + "`).Def(18) = 2\\r\\n");
            }

            sb = sb.Replace("#Columns#", columns.ToString());

            //output.Write("<iframe id=\"iframemenu1\" height=\"40\" width=\"100\" style=\"position:absolute;top:400;left:400\">hello</iframe>");
            //output.Write("<div  id=\"divmenu1\" height=\"40\" width=\"100\" style=\"position:absolute;top:400;left:400\">hello</div>");
            //output.Write("<a href='Java`script:zoomIn();'>test</a>");

            output.Write("<OBJECT CLASSID=\"clsid:5220cb21-c88d-11cf-b347-00aa00a28331\" VIEWASTEXT><PARAM NAME=\"LPKPath\" VALUE=\"/_layouts/epmlive/epmlivegantt.lpk\"></OBJECT>\r\n\r\n");

            output.Write("<script src=\"/_layouts/epmlive/dhtml/xajax/dhtmlxcommon.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/resPlanning.js?guid=" + Guid.NewGuid() + "\"></script>");

            output.Write("<script type=\"text/javascript\" src=\"/_layouts/epmlive/modal/modal.js\"></script><link rel=\"stylesheet\" href=\"/_layouts/epmlive/modal/modalmain.css\" type=\"text/css\" /> ");

            //output.Write("<OBJECT id=Print1 classid=clsid:4DEB0D2B-6EBD-4A22-9835-48AB9CDC8088 CODEBASE=\"/_layouts/epmlive/ExPrintCab.CAB#version=4,0,0,5\" style=\"display:none;\"/>");
            output.Write("<div id=\"noitems" + this.ZoneIndex + this.ZoneID + "\" style=\"display:none;\" class\"ms-vb\">There are no items to show in this view.</div>");
            output.Write("<OBJECT id=G2antt1" + this.ZoneIndex + this.ZoneID + " style='z-index:-1' classid=clsid:CD481F4D-2D25-4759-803F-752C568F53B7 CODEBASE=\"/_layouts/epmlive/EPMLiveGantt.CAB#version=4,1,1,0\" height=" + height + " width=100%><b>Gantt Control Not Installed.</b></OBJECT>\r\n\r\n");
            output.Write("<OBJECT id=Print1" + this.ZoneIndex + this.ZoneID + " classid=clsid:4DEB0D2B-6EBD-4A22-9835-48AB9CDC8088 CODEBASE=\"/_layouts/epmlive/ExPrintCab.CAB#version=5,1,0,2\"></Object>\r\n");

            output.Write("<div  width=\"100%\" id=\"loadinggantt" + this.ZoneIndex + this.ZoneID + "\" align=\"center\">");
            output.Write("<img src=\"_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading Items...");
            output.Write("</div>");

            output.Write(Properties.Resources.txtFileFunctions.Replace("#gridid#", this.ZoneIndex + this.ZoneID));

            output.Write("<SCRIPT LANGUAGE=\"javascript\">\r\n");
            
            //output.Write("<!--\r\n");
            output.Write("var GcurItem;");
            output.Write("document.body.onload = function()\r\n");
            output.Write("{");
            output.Write("if (typeof(_spBodyOnLoadWrapper) != 'undefined') _spBodyOnLoadWrapper();\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + " = document.getElementById(\"G2antt1" + this.ZoneIndex + this.ZoneID + "\");\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".BeginUpdate();\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".Appearance = 0;\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".MarkSearchColumn = 0;\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".Chart.PaneWidth(0) = document.getElementById(\"G2antt1" + this.ZoneIndex + this.ZoneID + "\").clientWidth / 3;\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".DrawGridLines = 1;\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".Chart.DrawGridLines = 1;\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".ColumnAutoResize = false;\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".Chart.OverviewVisible = 1;\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".Chart.OverviewHeight = 24;\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".Chart.HistogramVisible = 1;\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".Chart.HistogramHeight = " + (int.Parse(height) / 3.5) + ";\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".Chart.HistogramView = 4;\r\n");

            //output.Write(sbTemplateList);
            //output.Write("G2antt1.LoadXML(\"" + SPContext.Current.Web.Url + "/_layouts/epmlive/getresourceplan.aspx?data=" + getGanttParams() + "\");\r\n");
            //output.Write("G2antt1.LoadXML(\"" + SPContext.Current.Web.Url + "/_layouts/epmlive/gantt.xml?id=" + Guid.NewGuid() + "\");\r\n");

            output.Write("document.getElementById(\"G2antt1" + this.ZoneIndex + this.ZoneID + "\").style.display=\"none\";");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".EndUpdate();");
            output.Write("setTimeout(\"loadGanttXml()\",1);");

            output.Write("}\r\n");
            //output.Write("//-->");
            output.Write("function loadGanttXml(){");
            output.Write("var wp = document.getElementById('MSOZoneCell_WebPart" + this.Qualifier + "');");
            //output.Write("fireEvent(wp, 'mouseup');");

            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".LoadXML(\"" + SPContext.Current.Web.Url + "/_layouts/epmlive/getresourceplan.aspx?data=" + getGanttParams() + "&Source=" + System.Web.HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()) + "\");\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".Template = \"" + sb + "\";\r\n");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".Columns(0).Def(0) = 1;");
            output.Write("G2antt1" + this.ZoneIndex + this.ZoneID + ".Columns(0).PartialCheck = 1;");
            output.Write("document.getElementById(\"G2antt1" + this.ZoneIndex + this.ZoneID + "\").style.display=\"\";");
            output.Write("document.getElementById(\"loadinggantt" + this.ZoneIndex + this.ZoneID + "\").style.display=\"none\";");
            output.Write("doSummaryTasks();");
            
            output.Write("}");


            output.WriteLine("function clickTab(){");
            output.WriteLine("var wp = document.getElementById('MSOZoneCell_WebPart" + this.Qualifier + "');");
            output.WriteLine("fireEvent(wp, 'mouseup');");
            output.WriteLine("setTimeout(\"clickbrowse()\",1000);");
            output.WriteLine("}");

            output.WriteLine("function clickbrowse(){");
            output.WriteLine("var wp2 = document.getElementById('Ribbon.ResourcePlanner-title').firstChild;");
            output.WriteLine("fireEvent(wp2, 'click');");
            output.WriteLine("}");

            output.Write("SP.SOD.executeOrDelayUntilScriptLoaded(clickTab, \"GridViewContextualTabPageComponent.js\");");
            



            output.Write("</SCRIPT>");
            output.Write("<SCRIPT FOR=G2antt1" + this.ZoneIndex + this.ZoneID + " EVENT=AnchorClick(Anchor,Options) LANGUAGE=JScript>");
            output.Write("document.location.href=Anchor");
            output.Write("</SCRIPT>\r\n");

            output.Write("<SCRIPT FOR=G2antt1" + this.ZoneIndex + this.ZoneID + " EVENT=Click() LANGUAGE=JScript>");
            output.Write("var c;var h;");
            output.Write("GcurItem = G2antt1" + this.ZoneIndex + this.ZoneID + ".ItemFromPoint(-1, -1, c, h);");
            output.Write("RefreshCommandUI();");
            output.Write("</SCRIPT>\r\n");

            output.Write("<script type=\"text/vbscript\">\r\n");
            output.Write("function printGantt" + this.ZoneIndex + this.ZoneID + "()\r\n");
            output.Write("    document.getElementById(\"Print1" + this.ZoneIndex + this.ZoneID + "\").PrintExt = document.getElementById(\"G2antt1" + this.ZoneIndex + this.ZoneID + "\").Object\r\n");
            output.Write("    document.getElementById(\"Print1" + this.ZoneIndex + this.ZoneID + "\").Preview\r\n");
            output.Write("end function\r\n</script>");



            output.Write("<div id=\"boxDialog\" class=\"dialog\">");
            output.Write("<table width=\"100%\">");
            output.Write("    <tr>");
            output.Write("      <td align=\"center\" class=\"ms-sectionheader\">");
            output.Write("<img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/><br />");
            output.Write("<H3 class=\"ms-standardheader\" id=\"txtDialog\">Saving Resource Plan...</h3>");
            output.Write("</td>");
            output.Write("</tr>");
            output.Write("</table>");
            output.Write("</div>");

            output.Write("<div id=\"boxOpenDialog\" class=\"dialog\">");
            output.Write("<table width=\"300\" height=\"250\">");
            output.Write("    <tr>");
            output.Write("      <td align=\"center\" class=\"ms-sectionheader\">");
            output.Write("<select id=\"slctOpen\" name=\"slctOpen\" size=\"15\" style=\"width: 280px;\" onChange=\"planToOpen = this.value;\"></select>");
            output.Write("</td></tr><tr><td align=\"right\">");
            output.Write("<input name=\"Button1\" type=\"button\" value=\"Open Plan\" onClick=\"loadPlan('" + SPContext.Current.Web.Url + "');\"> ");
            output.Write("<input name=\"Button2\" type=\"button\" value=\"Cancel\" onClick=\"hm('boxOpenDialog');\"> ");
            output.Write("</td>");
            output.Write("</tr>");
            output.Write("</table>");
            output.Write("</div>");

            

            output.Write("<script>");
            output.Write("initmb();");
            output.Write("</script>");



            
        }

        private string getGanttParams()
        {
            EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(rcList);

            string strRollupLists = "";
            string strRollupSites = "";
            string resources = "";

            strRollupLists = gSettings.RollupLists;
            strRollupSites = gSettings.RollupSites;

            if (sResourceList != "")
            {
                string[] arrRes = sResourceList.Replace(";#", "\n").Split('\n');
                ArrayList arrListRes = new ArrayList();
                arrListRes.AddRange(arrRes);
                foreach (SPListItem li in reslist.Items)
                {
                    if (arrListRes.Contains(li.ID.ToString()))
                    {
                        try
                        {
                            if (li["SharePointAccount"] != null)
                            {
                                SPFieldUserValue u = new SPFieldUserValue(li.Web, li["SharePointAccount"].ToString());
                                resources += ";#" + HttpUtility.UrlEncode(u.LookupValue);
                            }
                        }
                        catch { }
                    }
                }
                if (resources.Length > 2)
                    resources = resources.Substring(2);
            }

            string data = "";

            data = "Lists/Resource Center/DispForm.aspx\n" + SPContext.Current.ViewContext.View.Title + "\nStartDate\nDueDate\nPercentComplete\n\n\nTrue\n\n\n" + strRollupLists + "\n" + Page.Request["FilterField1"] + "\n" + Page.Request["FilterValue1"] + "\n" + strRollupSites + "\n" + resources;

            data += "\n" + gSettings.UsePopup.ToString();
            
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(data);

            return Convert.ToBase64String(toEncodeAsBytes);
        }

        public void processControls(Control parentControl, string ZoneIndex, string viewUrl, SPWeb curWeb)
        {
            foreach (Control childControl in parentControl.Controls)
            {
                if (childControl.ToString() == "System.Web.UI.WebControls.HyperLink")
                {
                    if (childControl.ID == "hlGanttScrollTo")
                    {
                        System.Web.UI.WebControls.HyperLink hl = (System.Web.UI.WebControls.HyperLink)childControl;
                        hl.NavigateUrl = "javascript:scrollTo()";
                    }
                }
                if (childControl.ToString() == "System.Web.UI.WebControls.Label")
                {
                    if (childControl.ID == "lblFilter")
                    {
                        //System.Web.UI.WebControls.HyperLink hl = (System.Web.UI.WebControls.HyperLink)childControl;
                        //hl.NavigateUrl = "Javascript:switchFilter" + ZoneIndex + "('" + hl.ClientID + "');";

                        try
                        {
                            System.Web.UI.WebControls.Label lblFilterText = (System.Web.UI.WebControls.Label)parentControl.FindControl("lblFilterText");
                            System.Web.UI.WebControls.Label lblLink = (System.Web.UI.WebControls.Label)childControl;
                            lblLink.Text = "<a href=\"Javascript:switchFilter" + ZoneIndex + "('" + lblFilterText.ClientID + "');\">";
                        }
                        catch { }
                    }
                }
                if (childControl.ToString().ToUpper() == "MICROSOFT.SHAREPOINT.WEBCONTROLS.NEWMENU")
                {
                    childControl.Visible = false;
                }

                if (childControl.ToString().ToUpper() == "MICROSOFT.SHAREPOINT.WEBCONTROLS.ACTIONSMENU")
                {
                    ActionsMenu menu = (ActionsMenu)childControl;

                    try { menu.GetMenuItem("EditInGridButton").Visible = false; }
                    catch { }
                    try { menu.GetMenuItem("ExportToDatabase").Visible = false; }
                    catch { }
                    try
                    {
                        menu.GetMenuItem("ExportToSpreadsheet").Visible = false;
                    }
                    catch { }
                    try
                    {
                        menu.GetMenuItem("ViewRSS").Visible = false;
                    }
                    catch { }
                    try
                    {
                        menu.GetMenuItem("SubscribeButton").Visible = false;
                    }
                    catch { }
                    menu.AddMenuItem("ChangeResources", "Select Resources", "/_layouts/images/3people.GIF", "Change the resources you are currently viewing.", viewUrl + "?action=changeRes", "");
                    menu.AddMenuItemSeparator();
                    menu.AddMenuItem("SaveResourcePlan", "Save Resource Plan", "/_layouts/images/save.GIF", "Save resource plan to file.", "", "savePlan('" + curWeb.Url + "')");
                    menu.AddMenuItem("OpenResourcePlan", "Open Resource Plan", "/_layouts/images/FLDRNEW.GIF", "Open resource plan from saved file.", "", "loadPlans('" + curWeb.Url + "')");
                    menu.AddMenuItemSeparator();
                    menu.AddMenuItem("PrintGantt", "Print Gantt", "/_layouts/epmlive/images/printmenu.GIF", "Print Gantt Chart.", "", "printGantt" + this.ZoneIndex + this.ZoneID + "()");
                }

                processControls(childControl, ZoneIndex, viewUrl, curWeb);
            }
        }



        private void renderGrid(HtmlTextWriter output)
        {
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid_skins.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/calendar/dhtmlxcalendar.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxmenu.css\">");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xmenu/context.css\">");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xcombo/dhtmlxcombo.css\">");

            output.Write("<script>_css_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; _js_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; </script>");

            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_post.js\"></script>");

            output.Write("<script src=\"/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xtreegrid/ext/dhtmlxtreegrid_filter.js\"></script>");

            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_nxml.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_filter.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_math.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_srnd.js\"></script>");

            output.Write("<script src=\"/_layouts/epmlive/DHTML/xcombo/dhtmlxcombo.js\"></script>");

            output.Write("<script language=\"JavaScript\" src=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxprotobar.js\"></script>");
            output.Write("<script language=\"JavaScript\" src=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxmenubar.js\"></script>");
            output.Write("<script language=\"JavaScript\" src=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxmenubar_cp.js\"></script>");

            output.Write("<script src=\"/_layouts/epmlive/resPlanning.js\"></script>");

            output.Write("<div id=\"grid" + this.ID + "\" style=\"width:100%;display:none;\" ></div>\r\n\r\n");

            output.Write("<div  width=\"100%\" id=\"loadinggrid" + this.ID + "\" align=\"center\">");
            output.Write("<img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading Resources...");
            output.Write("</div>");

            output.Write("<script language=\"javascript\">");

            output.Write("function gridfilter" + this.ZoneIndex + this.ZoneID + "(value){");
            output.Write("var vals = value.split('|');");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".filterBy(vals[0],vals[1]);");
            output.Write("}");

            output.Write(Properties.Resources.txtResourcePlannerJavascript1.Replace("#gridid#", this.ZoneIndex + this.ZoneID));

            output.Write("function changeview" + this.ZoneIndex + this.ZoneID + "(){");
            output.Write("try{");
            output.Write("var view = document.getElementById('viewselector" + this.ZoneIndex + this.ZoneID + "').value;");
            output.Write("document.getElementById(\"grid" + this.ID + "\").style.display = \"none\";");
            output.Write("document.getElementById(\"loadinggrid" + this.ID + "\").style.display = \"\";");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".detachHeader(1);");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".clearAll(true);");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".loadXML(\"" + resWeb.Url + "/_layouts/epmlive/getresourcepool.aspx?view=\" + view + \"&gridname=" + this.ZoneIndex + this.ZoneID + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "\");");
            output.Write("}catch(e){alert(e);}");
            output.Write("}");

            output.Write("function setSize" + this.ZoneIndex + this.ZoneID + "(){mygrid" + this.ZoneIndex + this.ZoneID + "._askRealRows();}");

            output.Write("function printgrid" + this.ZoneIndex + this.ZoneID + "() {var temp = mygrid" + this.ZoneIndex + this.ZoneID + ".hdr.rows[2];var parent = temp.parentNode;parent.removeChild(temp,true);mygrid" + this.ZoneIndex + this.ZoneID + ".printView();parent.appendChild(temp);}");
            output.Write("function switchFilter" + this.ZoneIndex + this.ZoneID + "(hlink){");
            output.Write("var input1 = mygrid" + this.ZoneIndex + this.ZoneID + ".hdr.rows[2];");
            output.Write("if(mygrid" + this.ZoneIndex + this.ZoneID + "Hidden == false){");
            output.Write("input1.style.display = \"none\";");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + "Hidden = true;");
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Show Filters\";}");
            output.Write("}else{");
            output.Write("input1.style.display = \"\";");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + "Hidden = false;");
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Hide Filters\";}");
            output.Write("}");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".setSizes();");
            output.Write("}");
            output.Write("function switchFilterLoad" + this.ZoneIndex + this.ZoneID + "(){switchFilter" + this.ZoneIndex + this.ZoneID + "(null);}");
            output.Write("</script>");

            output.Write("<script>");
            output.Write("var mygrid" + this.ZoneIndex + this.ZoneID + "Hidden = false;");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + " = new dhtmlXGridObject('grid" + this.ID + "');");

            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".setImagePath(\"/_layouts/epmlive/dhtml/xgrid/imgs/\");");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".setSkin(\"modern\");");

            output.WriteLine("mygrid" + sFullGridId + ".addFocusedCommands = function($arr){return $arr;}");
            output.WriteLine("mygrid" + sFullGridId + ".getGlobalCommands = function($arr){return $arr;}");
            output.WriteLine("mygrid" + sFullGridId + ".canHandleCommand = function($Grid, commandId){return false;}");
            output.WriteLine("mygrid" + sFullGridId + ".handleCommand = function($Grid, commandId, properites){if(typeof(properties) != 'undefined')return properties;}");

            if (this.Height == "")
            {
                output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".enableAutoHeigth(true);");
            }
            else
            {
                MatchCollection mc = Regex.Matches(this.Height, "\\d*");
                string h = "100";
                if (mc.Count > 0)
                {
                    h = mc[0].Value;
                    try
                    {
                        h = (int.Parse(h) - 30).ToString();
                    }
                    catch { }
                }
                output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".enableAutoHeigth(true," + h + ",true);");
            }

            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".setImageSize(1,1);");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".enableTreeCellEdit(false);");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".setDateFormat(\"%m/%d/%Y\");");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".attachEvent(\"onXLE\",clearLoader);");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".attachEvent(\"onCheck\", doOnCheck" + this.ZoneIndex + this.ZoneID + ");");

            //output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".attachEvent(\"onXLE\",switchFilterLoad" + this.ZoneIndex + this.ZoneID + ");");
            //output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".attachEvent(\"onBeforeContextMenu\",onShowMenu);");

            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".init();");

            output.Write("try{");
            output.Write("mygrid" + this.ZoneIndex + this.ZoneID + ".loadXML(\"" + resWeb.Url + "/_layouts/epmlive/getresourcepool.aspx?view=" + reslist.DefaultView.Title.Replace(" ", "%20") + "&gridname=" + this.ZoneIndex + this.ZoneID + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "\");");
            output.Write("}catch(e){alert(e);}");

            output.Write("</script>");

            output.Write("<input type=\"hidden\" name=\"changeRes\" id=\"changeRes\" value=\"yes\">");
            output.Write("<input type=\"hidden\" name=\"resourceList\" id=\"resourceList\" value=\"\">");
        }

    }
}
