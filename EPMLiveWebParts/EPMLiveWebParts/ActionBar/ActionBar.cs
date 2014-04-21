using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Reflection;

namespace EPMLiveWebParts
{
    [MdsCompliant(true)]
    [ToolboxData("<{0}:ActionBar runat=server></{0}:ActionBar>")]
    [Guid("f816bcc6-82de-4bb6-98aa-448dd07bf62c")]
    [XmlRoot(Namespace = "ActionBar")]
    public class ActionBar : Microsoft.SharePoint.WebPartPages.WebPart
    {
        private ViewToolBar toolbar;
        private int activation;
        private SPList list;
        private SPView view;
        private string sFullGridId;

        private int filterIndex;
        private bool disableNewButtonModification;
        private string newMenuName;
        private string rollupLists;
        private bool useNewMenu;
        private bool hideNew;
        private bool hasList;

        private SPWeb web;

        protected override void OnInit(EventArgs e)
        {
            if (SPContext.Current == null) return;
            web = SPContext.Current.Web;
        }

        protected override void OnLoad(EventArgs e)
        {
            sFullGridId = this.ZoneIndex + this.ZoneID;
        }

        protected override void CreateChildControls()
        {
            buildParams();

            if (SPContext.Current.ViewContext.View != null)
            {
                try
                {
                    typeof(ListTitleViewSelectorMenu).GetField("m_wpSingleInit", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Page.FindControl("ctl00$PlaceHolderPageTitleInTitleArea$ctl01$ctl00").Controls[1], true);
                }
                catch { }
                try
                {
                    typeof(ListTitleViewSelectorMenu).GetField("m_wpSingle", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Page.FindControl("ctl00$PlaceHolderPageTitleInTitleArea$ctl01$ctl00").Controls[1], true);
                }
                catch { }
            }

            EnsureChildControls();

            EPMLiveCore.Act act = new EPMLiveCore.Act(web);
            activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WebParts);
            if (activation != 0)
                return;

            try
            {
                toolbar = new ViewToolBar();
                toolbar.EnableViewState = false;

                list = SPContext.Current.List;
                view = SPContext.Current.ViewContext.View;

                SPContext context = SPContext.GetContext(this.Context, view.ID, list.ID, web);
                toolbar.RenderContext = context;

                Controls.Add(toolbar);
            }
            catch { }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (toolbar != null)
            {
                toolbar.RenderControl(writer);

                foreach (Control control in toolbar.Controls)
                {
                    if (control == null) continue;
                    processControls(control, list.Title, list.ID.ToString(), view.ID.ToString(), "grid", this.ID, sFullGridId, hideNew);
                }
            }

            if (SPContext.Current.ViewContext.View != null)
            {
                foreach (System.Web.UI.WebControls.WebParts.WebPart wp in WebPartManager.WebParts)
                {
                    try
                    {
                        if (wp.ToString() == "Microsoft.SharePoint.WebPartPages.XsltListViewWebPart" || wp.ToString() == "Microsoft.SharePoint.WebPartPages.ListViewWebPart")
                        {
                            Microsoft.SharePoint.WebPartPages.XsltListViewWebPart wp2 = (Microsoft.SharePoint.WebPartPages.XsltListViewWebPart)wp;
                            wp2.XmlDefinition = wp2.XmlDefinition.Replace("<Toolbar Type=\"Standard\"/>", "<Toolbar Type=\"Standard\" ShowAlways=\"TRUE\"/>");
                            wp.Visible = false;
                            break;
                        }
                    }
                    catch { }
                }
            }
        }

        private void buildParams()
        {
            EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);

            rollupLists = gSettings.RollupLists;
            hideNew = gSettings.HideNewButton;
            disableNewButtonModification = gSettings.DisableNewItemMod;
            useNewMenu = gSettings.UseNewMenu;
            newMenuName = gSettings.NewMenuName;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                using (SPSite site = new SPSite(web.Site.ID))
                {
                    using (SPWeb w = site.OpenWeb(web.ID))
                    {


                        string _templateResourceUrl = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveTemplateGalleryURL", true, false);

                        try
                        {
                            using (SPSite tsite = new SPSite(_templateResourceUrl))
                            {
                                using (SPWeb tweb = tsite.OpenWeb())
                                {
                                    SPList tlist = tweb.Lists.TryGetList("Template Gallery");
                                    if (tlist != null)
                                        hasList = true;
                                }
                            }
                        }
                        catch { }

                    }
                }
            });
        }


        private void processControls(Control parentControl, string listname, string listid, string viewid, string defaultcontrol, string webpartid, string ZoneIndex, bool hideNew)
        {
            foreach (Control childControl in parentControl.Controls)
            {
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
                            lblLink.Text = "<a onclick=\"Javascript:switchFilter" + ZoneIndex + "('" + lblFilterText.ClientID + "');\">";

                            filterIndex = parentControl.Parent.Controls.IndexOf(parentControl);


                        }
                        catch { }
                    }
                }

                if (childControl.ToString().ToUpper() == "MICROSOFT.SHAREPOINT.WEBCONTROLS.NEWMENU")
                {
                    if (hideNew)
                    {
                        childControl.Visible = false;
                    }
                    else if (useNewMenu)
                    {

                        if (hasList)
                        {
                            NewMenu menu = (NewMenu)childControl;
                            try
                            {
                                Microsoft.SharePoint.WebControls.MenuItemTemplate mnu = menu.GetMenuItem("New0");
                                mnu.ClientOnClickNavigateUrl = "javascript:newAppPopup('" + list.ID.ToString().ToUpper() + @"');";
                                string txt = mnu.Text;
                                int spaceloc = txt.IndexOf(" ");
                                txt = txt.Substring(0, spaceloc);
                                if (newMenuName == "")
                                    mnu.Text = txt + " " + listname;
                                else
                                    mnu.Text = txt + " " + newMenuName;
                                menu.MenuControl.ClientOnClickScript = "javascript:newAppPopup('" + list.ID.ToString().ToUpper() + @"');";
                            }
                            catch { }
                        }
                        else
                        {
                            NewMenu menu = (NewMenu)childControl;
                            try
                            {
                                Microsoft.SharePoint.WebControls.MenuItemTemplate mnu = menu.GetMenuItem("New0");
                                mnu.ClientOnClickNavigateUrl = SPContext.Current.Web.Url + "/_layouts/epmlive/newapp.aspx?List=" + listid;
                                string txt = mnu.Text;
                                int spaceloc = txt.IndexOf(" ");
                                txt = txt.Substring(0, spaceloc);
                                if (newMenuName == "")
                                    mnu.Text = txt + " " + listname;
                                else
                                    mnu.Text = txt + " " + newMenuName;
                                menu.MenuControl.ClientOnClickScript = "location.href='" + mnu.ClientOnClickNavigateUrl + "'";
                            }
                            catch { }
                        }
                    }
                    else if (listname != "Project Center" && listname != "Project Center Rollup" && rollupLists != "" && !disableNewButtonModification)
                    {
                        NewMenu menu = (NewMenu)childControl;
                        try
                        {
                            menu.GetMenuItem("New0").Visible = false;
                            menu.MenuControl.NavigateUrl = "";
                            menu.MenuControl.ClientOnClickScript = "";
                            string[] arrrolluplists = rollupLists.Split(',');
                            foreach (string rolluplist in arrrolluplists)
                            {
                                string[] arrrolluplist = rolluplist.Split('|');
                                string image = "";
                                try
                                {
                                    image = "/_layouts/images/" + arrrolluplist[1];
                                }
                                catch { }
                                menu.AddMenuItem("New1", "New " + arrrolluplist[0].Trim() + " Item", "", "", SPContext.Current.Web.Url + "/_layouts/epmlive/newitem.aspx?List=" + arrrolluplist[0] + "&Source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()), "");
                            }

                        }
                        catch { }
                    }
                    else
                    {
                        NewMenu menu = (NewMenu)childControl;
                        MenuItemTemplate template = menu.GetMenuItem("New0");
                    }
                }

                if (childControl.ToString().ToUpper() == "MICROSOFT.SHAREPOINT.WEBCONTROLS.ACTIONSMENU")
                {
                    ActionsMenu menu = (ActionsMenu)childControl;
                    if (rollupLists != "")
                    {
                        try { menu.GetMenuItem("EditInGridButton").Visible = false; }
                        catch { }
                        try { menu.GetMenuItem("ExportToDatabase").Visible = false; }
                        catch { }
                        if (rollupLists != "")
                        {
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
                        }
                        try
                        {
                            SPWeb web = SPContext.Current.Web;
                            MenuItemTemplate mnu = menu.GetMenuItem("ExportToSpreadsheet");
                            mnu.ClientOnClickScript = "location.href='" + web.ServerRelativeUrl + "/_layouts/epmlive/rollupexport.aspx?List=" + listid + "&View=" + viewid + "&Lists=" + HttpUtility.UrlEncode(rollupLists.Replace(",", ";")) + "'";
                        }
                        catch { }
                    }

                    string url = HttpContext.Current.Request.Url.AbsolutePath;
                    if (url.Contains("?"))
                        url += "&";
                    else
                        url += "?";

                    if (defaultcontrol.ToLower() == "grid")
                    {

                    }
                    else if (defaultcontrol.ToLower() == "gantt")
                    {
                        menu.AddMenuItem("ViewInGrid", "View In Grid", "/_layouts/epmlive/images/menugridview.GIF", "View list using EPM Live Grid.", url + "webpartid=" + webpartid + "&gridmode=grid", "");
                    }
                }

                if (childControl == null) return;

                processControls(childControl, listname, listid, viewid, defaultcontrol, webpartid, ZoneIndex, hideNew);
            }
        }
    }
}
