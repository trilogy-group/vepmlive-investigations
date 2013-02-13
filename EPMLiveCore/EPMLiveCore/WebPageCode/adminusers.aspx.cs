using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore
{
    public partial class adminusers : System.Web.UI.Page
    {
        protected SPGridView GvItems;
        protected Label lblFeatureName;
        protected Label lblUsage;
        protected Label lblConnError;
        protected Label lblMaxUsers;
        protected Label lblError;
        protected string sFeature;

        protected void Page_Load(object sender, EventArgs e)
        {
            sFeature = Act.GetFeatureName(Request["feature"]);

            if (Request["delete"] != null)
            {
                //EPMLiveCore.CoreFunctions.deleteKey(Request["delete"]);
                DeleteUser(Request["delete"]);
            }

            if (sFeature != "" || sFeature != null)
            {
                MenuTemplate propertyNameListMenu = new MenuTemplate();
                propertyNameListMenu.ID = "PropertyNameListMenu";
                MenuItemTemplate testMenu = new MenuItemTemplate("Delete User", "/_layouts/images/delete.gif");
                testMenu.ClientOnClickNavigateUrl = "users.aspx?feature=" + Request["feature"] + "&delete=%NAME%";

                propertyNameListMenu.Controls.Add(testMenu);

                this.Controls.Add(propertyNameListMenu);

                ListUsers();
            }
            else
            {
                lblFeatureName.Text = "None Selected";
            }
        }

        private void ListUsers()
        {

            ArrayList users = CoreFunctions.getFeatureUsers(int.Parse(Request["feature"]));
            DataTable dt = new DataTable();
            dt.Columns.Add("username");
            dt.Columns.Add("encusername");

            int cntUsers = 0;

            foreach (string username in users)
            {
                if (username != "")
                {
                    cntUsers++;
                    dt.Rows.Add(new string[] { username, System.Web.HttpUtility.UrlEncode(username) });
                }
            }

            GvItems.DataSource = dt;
            GvItems.DataBind();

            lblUsage.Text = cntUsers.ToString();
            lblMaxUsers.Text = CoreFunctions.getFeatureLicenseUserCount(int.Parse(Request["feature"]));
            
        }



        private void DeleteUser(string sFeatureUserID)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                SPWeb web = SPContext.Current.Web;
                web.AllowUnsafeUpdates = true;
                SPSite site = web.Site;
                site.AllowUnsafeUpdates = true;
                SPWebApplication app = site.WebApplication;
                SPFarm farm = app.Farm;

                UserManager _chrono = farm.GetChild<UserManager>("UserManager" + Request["feature"]);
                ArrayList arrUsers = _chrono.UserList;

                arrUsers.Remove(sFeatureUserID);

                _chrono.UserList = arrUsers;

                _chrono.Update();

                farm.Update();
            });
            

            Response.Redirect("users.aspx?isdlg=1&feature=" + Request["feature"]);

        }

    }
}