using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace EPMLiveCore
{
    public class ManageableLists : UserControl
    {
        DropDownList ddl;
        protected override void CreateChildControls()
        {
            Label lbl = new Label();
            lbl.Text = "Manage Work: ";
            
            ddl = new DropDownList();
            ddl.ID = "Ddl1";
            ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
            ddl.AutoPostBack = true;
            ListItem li = new ListItem("--Select A List--", "");
            ddl.Items.Add(li);

            SPWeb web = SPContext.Current.Web;
            SPList lstProjectCenter = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveProjectCenter")];

            foreach (SPList l in web.Lists)
            {
                if (l.SchemaXml.ToLower().Contains("list=\"{" + lstProjectCenter.ID.ToString() + "}\"") && l.Title != CoreFunctions.getConfigSetting(web, "EPMLiveTaskCenter"))
                {
                    li = new ListItem(l.Title,l.DefaultViewUrl);
                    ddl.Items.Add(li);
                }
            }

            base.Controls.Add(lbl);
            base.Controls.Add(ddl);
            base.CreateChildControls();
        }

        void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(ddl.SelectedValue);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }
    }

}
