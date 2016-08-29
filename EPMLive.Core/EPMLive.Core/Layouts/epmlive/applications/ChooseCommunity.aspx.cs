using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;

namespace EPMLiveCore.Layouts.epmlive.applications
{
    public partial class ChooseCommunity : LayoutsPageBase
    {
        protected string bNavOnly = "false";

        protected void Page_Load(object sender, EventArgs e)
        {
            Act act = new Act(Web);

            if(act.CheckFeatureLicense(ActFeature.AppsAndCommunities) != 0)
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/applications/noact.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);

            API.ApplicationDef appDef = API.Applications.GetApplicationInfo(Request["AppId"]);

            if(appDef.Community != "")
            {

                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/applications/precheck.aspx?appid=" + Request["appid"] + "&CommId=", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);

            }
            else
            {

                string curapp = "";
                try
                {
                    curapp = Request["CommId"].ToString();
                }
                catch { }
                if(curapp == "")
                {
                    AppSettingsHelper helper = new AppSettingsHelper();
                    curapp = helper.CurrentAppId.ToString();
                }
            
                

                SPList oList = Web.Lists.TryGetList("Installed Applications");

                SPQuery query = new SPQuery();
                query.Query = "<Where><IsNull><FieldRef Name='EXTID'/></IsNull></Where><OrderBy><FieldRef Name='Title'/></OrderBy>";

                foreach(SPListItem li in oList.GetItems(query))
                {
                    System.Web.UI.WebControls.ListItem listitem = new System.Web.UI.WebControls.ListItem(li.Title, li.ID.ToString());

                    if(String.Equals(li.ID.ToString(), curapp))
                        listitem.Selected = true;

                    ddlCommunity.Items.Add(listitem);
                }

                query = new SPQuery();
                query.Query = "<Where><And><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + Request["AppId"] + "</Value></Eq><Eq><FieldRef Name='Status'/><Value Type='Text'>Installed</Value></Eq></And></Where>";

                SPListItemCollection lic = oList.GetItems(query);

                if(lic.Count > 0)
                {
                    pnlInstalled.Visible = true;
                    bNavOnly = "true";
                }
            }
        }
    }
}
