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
                            using(SPSite site = new SPSite(SPContext.Current.Site.ID))
                            {
                                site.CatchAccessDeniedException = false;
                                site.CatchAccessDeniedException = false;
                                using(SPWeb currWeb = site.OpenWeb())
                                {
                                    string sNotificationUsers = "";
                                    if(currWeb.Properties.ContainsKey("EPMLiveNotificationUsers"))
                                    {
                                        sNotificationUsers = currWeb.Properties["EPMLiveNotificationUsers"];
                                    }
                                    if(sNotificationUsers.Contains(sCurrUser))
                                    {
                                        chkTask.Checked = true;
                                    }
                                    else
                                    {
                                        chkTask.Checked = false;
                                    }

                                    if(currWeb.Properties.ContainsKey("EPMLiveNotificationLock"))
                                    {
                                        if(currWeb.Properties["EPMLiveNotificationLock"].ToUpper() == "TRUE" || currWeb.Properties["EPMLiveNotificationAllUsers"].ToUpper() == "TRUE")
                                            chkTask.Enabled = false;
                                        else
                                            chkTask.Enabled = true;
                                    }

                                    if(currWeb.Properties.ContainsKey("EPMLiveNotificationAllUsers"))
                                    {
                                        if(currWeb.Properties["EPMLiveNotificationAllUsers"].ToUpper() == "TRUE")
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
                    using(SPSite site = new SPSite(SPContext.Current.Site.ID))
                    {
                        site.CatchAccessDeniedException = false;
                        using(SPWeb currWeb = site.OpenWeb()) 
                        {
                            currWeb.AllowUnsafeUpdates = true;
                            string sNotificationUsers = "";
                            if(currWeb.Properties.ContainsKey("EPMLiveNotificationUsers"))
                            {
                                sNotificationUsers = currWeb.Properties["EPMLiveNotificationUsers"];
                            }

                            string sCurrUser = SPContext.Current.Site.RootWeb.CurrentUser.ID + ";#" + SPContext.Current.Site.RootWeb.CurrentUser.Name;

                            if(chkTask.Checked == true)
                            {
                                if(!sNotificationUsers.Contains(sCurrUser))
                                {
                                    sNotificationUsers += "|" + sCurrUser;
                                    currWeb.Properties["EPMLiveNotificationUsers"] = sNotificationUsers;
                                    currWeb.Properties.Update();
                                }
                            }
                            else
                            {
                                if(sNotificationUsers.Contains(sCurrUser))
                                {
                                    int iPipeLocation = sNotificationUsers.IndexOf("|", sNotificationUsers.IndexOf(sCurrUser) + sCurrUser.Length) + 1;
                                    if(iPipeLocation > 0) // has more
                                    {
                                        sNotificationUsers = sNotificationUsers.Replace(sCurrUser + "|", "");
                                    }
                                    else // last one
                                    {
                                        sNotificationUsers = sNotificationUsers.Replace(sCurrUser, "");
                                    }
                                    currWeb.Properties["EPMLiveNotificationUsers"] = sNotificationUsers;
                                    currWeb.Properties.Update();
                                }
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
