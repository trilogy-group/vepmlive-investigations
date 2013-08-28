using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class addusers : LayoutsPageBase
    {
        private const string GridName = "Users33";
        private const string EpmLivePath = "/_layouts/epmlive/";
        protected PlaceHolder phToolbar;

        protected void Page_Load(object sender, EventArgs e)
        {
            ViewList viewList;
            string resUrl;
            SPSite site = SPContext.Current.Site;
    
            {
                SPWeb web = SPContext.Current.Web;
                {
                    resUrl = CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL");
                    if (resUrl.StartsWith("/"))
                    {
                        using (SPWeb resWeb = site.OpenWeb(resUrl))
                        {
                            viewList = GetViewList(resWeb.Lists[CoreFunctions.getConfigSetting(resWeb, "EPMLiveResourcePool")]);
                        }
                    }
                    else
                    {
                        using (SPSite resSite = new SPSite(resUrl))
                        {
                            using (SPWeb resWeb = resSite.OpenWeb())
                            {
                                viewList = GetViewList(resWeb.Lists[CoreFunctions.getConfigSetting(resWeb, "EPMLiveResourcePool")]);
                            }
                        }
                    }
                }
            }

            ClientScript.RegisterStartupScript(GetType(), "EPMScript1",
                                               Properties.Resources.Javascript.Replace("#ResourceUrl#", GetGridUrl(resUrl)).Replace("#DefaultView#", viewList.DefaultView).Replace("#Grid#",
                                                                                                                                                                        GridName));
            RegisterScripts();

            phToolbar.Controls.Add(new LiteralControl(Properties.Resources.ResourceDDLTop));
            phToolbar.Controls.Add(CreateAddUserButton());
            phToolbar.Controls.Add(new LiteralControl(Properties.Resources.ResourceDDLBottom.Replace("#currentView#", viewList.DefaultView).Replace("#viewList#", viewList.ViewListString)));
        }



        protected string GetGridUrl(string resUrl)
        {
            return string.Format(
                "{0}/_layouts/epmlive/getresourcepool.aspx?gridname={1}&source={2}",
                (resUrl == "/") ? "" : resUrl,
                GridName,
                HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()));
        }

        private void AddUser_Click(object sender, EventArgs e)
        {

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/permissions.aspx?Resources=" + Page.Request["ResourceList"], Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        private ViewList GetViewList(SPList list)
        {
            SPView resview = list.DefaultView;
            string vl = GetMenuItem(resview, "zz29_DefaultView", "100");
            foreach (SPView vw in resview.Views)
            {
                if (!vw.Hidden && !vw.DefaultView)
                    vl += GetMenuItem(vw, "zz31_View2", "300");
            }
            return new ViewList(vl, resview.Title); //.Replace(" ", "%20"));
        }

        private string GetMenuItem(SPView vw, string viewCode, string groupId)
        {
            return string.Format(
                "<ie:menuitem id=\"{0}\" type=\"option\" onMenuClick=\"changeview{1}('{2}');\" text=\"{3}\" menuGroupId=\"{4}\"></ie:menuitem>",
                viewCode,
                GridName,
                vw.Title.Replace(" ", "%20"),
                vw.Title,
                groupId);
        }

        private LinkButton CreateAddUserButton()
        {
            LinkButton btnAddUser = new LinkButton();
            btnAddUser.Click += AddUser_Click;
            btnAddUser.OnClientClick = string.Format("Javascript:return postResources{0}();", GridName);
            btnAddUser.Text =
                "<img src=\"/_layouts/images/epmlivegantt.GIF\" border=\"0\" style=\"vertical-align: middle;\"> Add Selected Users";
            return btnAddUser;
        }

        private void RegisterScripts()
        {
            string dhtmlPath = EpmLivePath + "DHTML/";
            ClientScript.RegisterStartupScript(GetType(), "EPMScript2", string.Format("<script>_css_prefix = '{0}xgrid/';_js_prefix = '{0}xgrid/'; </script>", dhtmlPath));
            string[] dhtmlrefs = new string[]
                                {
                                    "xgrid/dhtmlxcommon.js",
                                    "xgrid/dhtmlxgrid.js",
                                    "xgrid/dhtmlxgridcell.js",
                                    "xgrid/dhtmlxgrid_post.js",
                                    "xtreegrid/dhtmlxtreegrid.js",
                                    "xtreegrid/ext/dhtmlxtreegrid_filter.js",
                                    "xgrid/ext/dhtmlxgrid_nxml.js",
                                    "xgrid/ext/dhtmlxgrid_filter.js",
                                    "xgrid/ext/dhtmlxgrid_math.js",
                                    "xgrid/ext/dhtmlxgrid_srnd.js",
                                    "xcombo/dhtmlxcombo.js",
                                    "xmenu/dhtmlxprotobar.js",
                                    "xmenu/dhtmlxmenubar.js",
                                    "xmenu/dhtmlxmenubar_cp.js"
                                };
            int count = 1;
            foreach (string jsRef in dhtmlrefs)
            {
                ClientScript.RegisterClientScriptInclude(GetType(), "EPMInclude" + count++.ToString("d2"), dhtmlPath + jsRef);
            }

            ClientScript.RegisterClientScriptInclude(GetType(), "EPMInclude", EpmLivePath + "resPlanning.js");
            ClientScript.RegisterStartupScript(GetType(), "EPMScript3",
                                               @"
    <script language='javascript'>
        function chk(chkid, ddlid) {
            var chk = document.getElementById(chkid);
            var divDDL = document.getElementById(ddlid);
            if (chk.checked)
                divDDL.style.display = '';
            else
                divDDL.style.display = 'none';
        }
    </script>"
                );
        }

        #region Nested type: ViewList

        public struct ViewList
        {
            public string DefaultView;
            public string ViewListString;

            public ViewList(string viewListString, string defaultView)
            {
                ViewListString = viewListString;
                DefaultView = defaultView;
            }
        }

        #endregion
    }
}