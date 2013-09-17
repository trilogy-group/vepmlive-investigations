using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class gotoremote : LayoutsPageBase
    {
        protected string error = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "";

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                Guid listId = new Guid(Request["listid"]);

                API.Integration.IntegrationCore core = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);
                DataTable dt = core.GetIntegrationControl(listId, Request["Control"]);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    string intid = "";
                    try
                    {
                        SPList list = Web.Lists[listId];
                        SPListItem li = list.GetItemById(int.Parse(Request["itemid"]));

                        intid = li["INTUID" + dr["INT_COLID"].ToString()].ToString();
                    }
                    catch { }
                    if (intid != "")
                    {
                        url = core.GetControlURL(new Guid(dr["INT_LIST_ID"].ToString()), listId, Request["Control"], intid);
                    }
                    else
                    {

                        error = "Could not find external itemid";

                    }
                }
                else
                {
                    error = "Could not find control";
                }
            });

            if (url != "")
            {
                Response.Redirect(url);
            }
            else
            {
                error = "No Url Generated";
            }
        }

    }
}
