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

namespace EPMLiveCore.Layouts.EPMLiveCore
{
    public partial class usersv2 : LayoutsPageBase
    {
        protected string sFeature;

        protected void Page_Load(object sender, EventArgs e)
        {

            sFeature = Act.GetFeatureNameV2(Request["feature"]);

            if(Request["delete"] != null)
            {
                //EPMLiveCore.CoreFunctions.deleteKey(Request["delete"]);
                DeleteUser(Request["delete"]);
            }

            if(sFeature != "" || sFeature != null)
            {
                MenuTemplate propertyNameListMenu = new MenuTemplate();
                propertyNameListMenu.ID = "PropertyNameListMenu";
                MenuItemTemplate testMenu = new MenuItemTemplate("Delete User", "/_layouts/images/delete.gif");
                testMenu.ClientOnClickNavigateUrl = "usersv2.aspx?feature=" + Request["feature"] + "&delete=%NAME%";

                propertyNameListMenu.Controls.Add(testMenu);

                this.Controls.Add(propertyNameListMenu);

                ListUsers();
            }

        }

        private void ListUsers()
        {

            ArrayList users = CoreFunctions.getFeatureUsers(1000);

            DataTable dt = new DataTable();
            dt.Columns.Add("username");
            dt.Columns.Add("encusername");

            int cntUsers = 0;

            foreach(string username in users)
            {
                

                if(username != "")
                {
                    string[] sUserInfo = username.Split(':');

                    if(sUserInfo[1] == Request["feature"])
                    {
                        cntUsers++;
                        dt.Rows.Add(new string[] { sUserInfo[0], System.Web.HttpUtility.UrlEncode(sUserInfo[0]) });
                    }
                }
            }

            GvItems.DataSource = dt;
            GvItems.DataBind();

            lblUsage.Text = cntUsers.ToString();

            int actType = 0;

            SortedList slLevels = Act.GetAllAvailableLevels(out actType);

            try
            {
                lblMaxUsers.Text = slLevels[int.Parse(Request["feature"])].ToString();
            }
            catch { lblMaxUsers.Text = "0"; }

        }

        private void DeleteUser(string sFeatureUserID)
        {
            Act act = new Act(Web);
            act.SetUserLevelV3(sFeatureUserID, 0);

            Response.Redirect("usersv2.aspx?isdlg=1&feature=" + Request["feature"]);
        }
    }
}
