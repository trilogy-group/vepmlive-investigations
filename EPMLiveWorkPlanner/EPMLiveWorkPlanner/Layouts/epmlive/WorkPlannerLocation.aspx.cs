using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class WorkPlannerLocation : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SPList list = base.Web.Lists[new Guid(Request["listid"])];

            SPQuery query = new SPQuery();
            query.Query = "<Where><And><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + Request["ProjectId"] + "</Value></Eq><Eq><FieldRef Name='taskuid'/><Value Type='Text'>" + Request["taskuid"] + "</Value></Eq></And></Where>";
            query.ViewFields = "";

            SPListItemCollection lic = list.GetItems(query);

            if(lic.Count > 0)
            {
                switch(Request["locationurl"].ToLower())
                {
                    case "subnew":
                    case "versions":
                    case "workflows":
                        Microsoft.SharePoint.Utilities.SPUtility.Redirect(Request["locationurl"] + ".aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current, "ID=" + lic[0].ID + "&List=" + Request["listid"]);
                        break;
                    case "user":
                        Microsoft.SharePoint.Utilities.SPUtility.Redirect(Request["locationurl"] + ".aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current, "obj=" + Request["listid"] + "," + lic[0].ID + ",LISTITEM&LIST=" + Request["listid"]);
                        break;
                    default:
                        Microsoft.SharePoint.Utilities.SPUtility.Redirect(Request["locationurl"] + ".aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current, "itemID=" + lic[0].ID + "&Listid=" + Request["listid"]);
                        break;
                }
            }
            

        }
    }
}
