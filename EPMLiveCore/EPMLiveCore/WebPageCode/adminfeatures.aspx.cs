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
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore
{
    public partial class adminfeatures : System.Web.UI.Page
    {
        protected SPGridView GvItems;
        protected Label lblFarmId;
        protected Label lblWarning;
        protected SPGridView gvFeatures;

        private int actType = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["delete"] != "")
            {
                EPMLiveCore.CoreFunctions.deleteKey(Request["delete"]);
            }
            
            
            MenuTemplate propertyNameListMenu = new MenuTemplate();

            propertyNameListMenu.ID = "PropertyNameListMenu";

            MenuItemTemplate testMenu = new MenuItemTemplate(

            "Delete Key", "/_layouts/images/delete.gif");

            testMenu.ClientOnClickNavigateUrl = "features.aspx?delete=%NAME%";

            propertyNameListMenu.Controls.Add(testMenu);

            this.Controls.Add(propertyNameListMenu);



            

            DataTable dt = new DataTable();
            dt.Columns.Add("feature");
            dt.Columns.Add("company");
            dt.Columns.Add("features");
            dt.Columns.Add("users");
            dt.Columns.Add("servers");
            dt.Columns.Add("dtcreated");
            dt.Columns.Add("expiration");

            int servercount = 0;
            string[] features = EPMLiveCore.CoreFunctions.featureList();
            foreach (string feature in features)
            {
                string[] featureData = EPMLiveCore.CoreFunctions.Decrypt(feature, "jLHKJH5416FL>1dcv3#I").Split('\n');
                if (featureData[2] == "0")
                    featureData[2] = "Unlimited";
                string[] featureNames = featureData[1].Split(',');
                string featureRealName = "";
                string servers = "";
                try
                {
                    servers = featureData[5];
                    servercount += int.Parse(servers);
                }catch{}
                foreach (string featureName in featureNames)
                {
                    featureRealName += CoreFunctions.getFeatureName(featureName);
                }
                if (featureRealName.Length > 0)
                {
                    featureRealName = featureRealName.Substring(4);
                }

                if(featureData[0][0] == '*')
                    dt.Rows.Add(new string[] { HttpUtility.UrlEncode(feature), featureData[2], featureRealName, featureData[2], servers, DateTime.Parse(featureData[1]).ToShortDateString(), featureData[4] });
                else
                    dt.Rows.Add(new string[] { HttpUtility.UrlEncode(feature), featureData[0], featureRealName, featureData[2], servers, featureData[3], featureData[4] });
            }

            GvItems.DataSource = dt;
            GvItems.DataBind();


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("featureid");
            dt2.Columns.Add("feature");
            dt2.Columns.Add("quantity");
            dt2.Columns.Add("active");

            SortedList acts = Act.GetAllAvailableLevels(out actType);

            ArrayList arrUsers = new ArrayList();

            if(actType == 3)
            {
                MenuTemplate propertyNameListMenu2 = new MenuTemplate();
                propertyNameListMenu2.ID = "PropertyNameListMenu2";
                MenuItemTemplate testMenu2 = new MenuItemTemplate(
                "Manage Users", "");
                testMenu2.ClientOnClickScript = "managelicv2('%NAME%');";
                propertyNameListMenu2.Controls.Add(testMenu2);
                this.Controls.Add(propertyNameListMenu2);

                arrUsers = CoreFunctions.getFeatureUsers(1000);
                if(arrUsers.Count == 1 && arrUsers[0].ToString() == "")
                    arrUsers = new ArrayList();
            }
            else
            {
                MenuTemplate propertyNameListMenu2 = new MenuTemplate();
                propertyNameListMenu2.ID = "PropertyNameListMenu2";
                MenuItemTemplate testMenu2 = new MenuItemTemplate(
                "Manage Users", "");
                //testMenu2.ClientOnClickNavigateUrl = "users.aspx?feature=%NAME%";
                testMenu2.ClientOnClickScript = "managelic('%NAME%');";
                propertyNameListMenu2.Controls.Add(testMenu2);
                this.Controls.Add(propertyNameListMenu2);
            }

            foreach(DictionaryEntry de in acts)
            {
                if(actType == 3)
                {
                    int counter = 0;
                    foreach(string user in arrUsers)
                    {
                        string[] sUserInfo = user.Split(':');
                        try
                        {
                            if(sUserInfo[1] == de.Key.ToString())
                                counter++;
                        }
                        catch { }
                    }

                    string count = de.Value.ToString();
                    if(count == "0")
                        count = "Unlimited";

                    dt2.Rows.Add(new string[] { de.Key.ToString(), Act.GetFeatureNameV2(de.Key.ToString()), count, counter.ToString() });
                }
                else
                {
                    CoreFunctions.getFeatureLicenseUserCount(int.Parse(de.Key.ToString()));

                    string count = de.Value.ToString();
                    if(count == "0")
                        count = "Unlimited";
                    dt2.Rows.Add(new string[] { de.Key.ToString(), Act.GetFeatureName(de.Key.ToString()), count, CoreFunctions.getFeatureUsers(int.Parse(de.Key.ToString())).Count.ToString() });
                }
            }

            gvFeatures.DataSource = dt2;
            gvFeatures.DataBind();

            lblFarmId.Text = SPFarm.Local.Id.ToString();

            string epmliveservers = "";
            try
            {
                epmliveservers = SPFarm.Local.Properties["EPMLiveServers"].ToString();
            }
            catch { }
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPServerCollection servers = SPFarm.Local.Servers;
                int farmservercount = 0;
                foreach (SPServer server in servers)
                    if (server.Role == SPServerRole.WebFrontEnd || server.Role == SPServerRole.Application)
                        farmservercount++;

                if (farmservercount > servercount && servercount != 0 && epmliveservers != "")
                {
                    lblWarning.Text = "<b>Warning:</b> It appears you have may have more servers in your farm than your key allows. To select specific servers go to the <a href=\"servers.aspx\">EPM Live Servers</a> page.";
                }
            });

        }

        protected void gvFeatures_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRow dr = ((DataRowView)e.Row.DataItem).Row;

                if(actType == 3)
                {
                    e.Row.Cells[3].Text = "<A href=\"javascript:void(0);\" onclick=\"Javascript:managelicv2('" + dr["feature"].ToString() + "');\">Manage</a>";
                }
                else
                {
                    e.Row.Cells[3].Text = "<A href=\"javascript:void(0);\" onclick=\"Javascript:managelic('" + dr["feature"].ToString() + "');\">Manage</a>";
                }
            }
        }
    }
}