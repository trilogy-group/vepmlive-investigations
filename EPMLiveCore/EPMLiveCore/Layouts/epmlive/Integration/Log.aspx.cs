using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Collections;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class Log : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                Hashtable hshParms = new Hashtable();
                hshParms.Add("intlistid", Request["intlistid"]);
                hshParms.Add("type", ddlLevel.SelectedValue);

                API.Integration.IntegrationCore core = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);
                DataSet dsLog = core.GetDataSet("SELECT * FROM INT_LOG WHERE INT_LIST_ID=@intlistid and LOGTYPE>=@type order by dtlogged desc", hshParms);


                gvLog.DataSource = dsLog.Tables[0];
                gvLog.DataBind();
            });
        }
    }
}
