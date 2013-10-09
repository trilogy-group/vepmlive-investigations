using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Collections;


namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class gotoremote : LayoutsPageBase
    {
        protected string error = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "";

            bool bIframe = false;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                if (!string.IsNullOrEmpty(Request["listid"]))
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
                            
                            if (dr["WINDOWSTYLE"].ToString() == "4")
                            {
                                bIframe = true;
                            }
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
                }
                else
                {
                    API.Integration.IntegrationCore core = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);

                    Hashtable hshParams  = new Hashtable();
                    hshParams.Add("intlistuid", Request["intlistid"]);

                    DataSet ds = core.GetDataSet("Select list_id from INT_LISTS where INT_LIST_ID=@intlistuid", hshParams);

                    url = core.GetControlURL(new Guid(Request["intlistid"]), new Guid(ds.Tables[0].Rows[0]["LIST_ID"].ToString()), Request["Control"], "");
                }
            });

            if (url != "")
            {
                if (bIframe)
                {
                    error = "<iframe src=\"" + url + "\" id=\"frmRemote\">";
                }
                else
                {
                    Response.Redirect(url);
                }
            }
            else
            {
                error = "No Url Generated";
            }
        }

    }
}
