using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class AddList : LayoutsPageBase
    {
        protected string newname = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                ArrayList arr = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "epklists").Split(','));

                foreach(SPList list in Web.Lists)
                {
                    if(!list.Hidden && !arr.Contains(list.Title))
                    {
                        ddlLists.Items.Add(list.Title);
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string lists = EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "epklists") + "," + ddlLists.SelectedValue;
            lists = lists.Trim(',');

            EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epklists", lists);

            pnlEdit.Visible = true;
            pnlMain.Visible = false;
            newname = ddlLists.SelectedValue;
        }
    }
}
