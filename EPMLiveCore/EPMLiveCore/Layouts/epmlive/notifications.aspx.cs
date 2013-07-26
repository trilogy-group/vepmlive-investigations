using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace EPMLiveCore
{
    public partial class Notificiations : LayoutsPageBase
    {
        public string strTitle;
        public string strTemplate;
        public static Hashtable desc;
        protected Panel pnlAdmin;
        protected ListBox lstNotificationUsers;
        protected ListBox lstSiteUsers;
        protected CheckBox chkTask;
        protected CheckBox chkAdmin;
        protected Panel pnlTL;
        protected Panel pnlMain;
        protected HyperLink hlAdmin;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!SPContext.Current.Web.IsRootWeb)
                    {
                        pnlTL.Visible = true;
                        hlAdmin.NavigateUrl = SPContext.Current.Site.Url + "/_layouts/epmlive/notifications.aspx";
                        pnlMain.Visible = false;
                    }
                    else
                    {
                        string sCurrUser = SPContext.Current.Site.RootWeb.CurrentUser.ID + ";#" + SPContext.Current.Site.RootWeb.CurrentUser.Name;

                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            //SPSite site = SPContext.Current.Site;
                            using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                            {
                                site.CatchAccessDeniedException = false;
                                site.CatchAccessDeniedException = false;
                                using (SPWeb currWeb = site.OpenWeb())
                                {
                                    string sNotificationUsers = "";
                                    if (currWeb.Properties.ContainsKey("EPMLiveNotificationUsers"))
                                    {
                                        sNotificationUsers = currWeb.Properties["EPMLiveNotificationUsers"];
                                    }
                                    if (sNotificationUsers.Contains(sCurrUser))
                                    {
                                        chkTask.Checked = true;
                                    }
                                    else
                                    {
                                        chkTask.Checked = false;
                                    }

                                    if (currWeb.Properties.ContainsKey("EPMLiveNotificationLock"))
                                    {
                                        if (currWeb.Properties["EPMLiveNotificationLock"].ToUpper() == "TRUE" || currWeb.Properties["EPMLiveNotificationAllUsers"].ToUpper() == "TRUE")
                                            chkTask.Enabled = false;
                                        else
                                            chkTask.Enabled = true;
                                    }

                                    if (currWeb.Properties.ContainsKey("EPMLiveNotificationAllUsers"))
                                    {
                                        if (currWeb.Properties["EPMLiveNotificationAllUsers"].ToUpper() == "TRUE")
                                            chkTask.Enabled = false;
                                    }
                                }
                            }

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                    {
                        site.CatchAccessDeniedException = false;
                        using (SPWeb currWeb = site.OpenWeb())
                        {
                            currWeb.AllowUnsafeUpdates = true;
                            string sNotificationUsers = "";
                            if (currWeb.Properties.ContainsKey("EPMLiveNotificationUsers"))
                            {
                                sNotificationUsers = currWeb.Properties["EPMLiveNotificationUsers"];
                            }

                            string sCurrUser = SPContext.Current.Site.RootWeb.CurrentUser.ID + ";#" + SPContext.Current.Site.RootWeb.CurrentUser.Name;

                            if (chkTask.Checked == true)
                            {
                                ArrayList arrUsers = new ArrayList(sNotificationUsers.Split('|'));
                                bool found = false;
                                foreach (string user in arrUsers)
                                {
                                    string[] userinfo = user.Replace(";#", "\n").Split('\n');
                                    if (userinfo[0] == SPContext.Current.Site.RootWeb.CurrentUser.ID.ToString())
                                        found = true;
                                }
                                if (!found)
                                    arrUsers.Add(sCurrUser);

                                currWeb.Properties["EPMLiveNotificationUsers"] = String.Join("|", (string[])arrUsers.ToArray(typeof(string)));
                                currWeb.Properties.Update();
                            }
                            else
                            {
                                ArrayList arrUsers = new ArrayList(sNotificationUsers.Split('|'));
                                ArrayList arrNewUsers = new ArrayList();
                                foreach (string user in arrUsers)
                                {
                                    string[] userinfo = user.Replace(";#", "\n").Split('\n');
                                    if (userinfo[0] != SPContext.Current.Site.RootWeb.CurrentUser.ID.ToString() && user != "")
                                    {
                                        arrNewUsers.Add(user);
                                    }
                                }

                                currWeb.Properties["EPMLiveNotificationUsers"] = String.Join("|", (string[])arrNewUsers.ToArray(typeof(string)));
                                currWeb.Properties.Update();
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }

            Response.Redirect(SPContext.Current.Web.ServerRelativeUrl);
        }

        public class UserObject : IComparable
        {
            public string Login;
            public string Name;

            public UserObject(string l, string n)
            {
                this.Login = l;
                this.Name = n;
            }

            public int CompareTo(object obj)
            {
                UserObject Compare = (UserObject)obj;
                int result = this.Name.CompareTo(Compare.Name);
                if (result == 0)
                    result = this.Name.CompareTo(Compare.Name);
                return result;
            }
        }
    }
}
