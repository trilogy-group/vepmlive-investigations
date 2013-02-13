using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using System.Xml;
using System.Data;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class Connection : LayoutsPageBase
    {
        protected string PageHead;
        protected Guid intlistid = Guid.Empty;
        protected Guid moduleid = Guid.Empty;
        API.Integration.IntegrationCore intcore;
        API.Integration.IntegrationAdmin intadmin;

        protected void Page_Load(object sender, EventArgs e)
        {

           
            try
            {
                intlistid=new Guid(Request["intlistid"]);
            }catch{}
            try
            {
                moduleid=new Guid(Request["module"]);
            }catch{}

            intcore = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);
            intadmin = new API.Integration.IntegrationAdmin(intcore, intlistid, moduleid);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                PageHead = intadmin.GetIntegrationHeader();

                Hashtable hshProps = new Hashtable();
                if(intlistid != Guid.Empty)
                    hshProps = intcore.GetProperties(intlistid);

                XmlDocument doc = intcore.GetModuleProperties(intlistid, moduleid);
                
                XmlNode ndCon = doc.FirstChild.SelectSingleNode("/Properties/Connection");

                lblMain.Controls.AddAt(0, intadmin.GetPropertyPanel(ndCon, hshProps, this));

            });


            if(Request["wizard"] == "1")
                Button1.Text = "Next >";
        }

        public override string PageToRedirectOnCancel
        {
            get
            {
                return "integrationlist.aspx?LIST=" + Request["List"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string message = "";

            Hashtable Properties = intadmin.GetCurrentPageProperties();

            

            if(intcore.TestModuleConnection(intadmin.ModuleID, intlistid, new Guid(Request["List"]), Properties, out message))
            {
                lblError.Visible = false;

                Hashtable hshProps = new Hashtable();

                if(Request["wizard"] == "1")
                {
                    intadmin.CreateIntegration(Web.Site.ID, Web.ID, new Guid(Request["List"]), Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N"), false, false, false, false);
                    intadmin.SaveProperties(hshProps);
                    SPUtility.Redirect("epmlive/integration/properties.aspx?intlistid=" + intadmin.intlistid + "&LIST=" + Request["List"] + "&wizard=1", SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
                }
                else
                {
                    SPList list = Web.Lists[new Guid(Request["List"])];
                    //intadmin.UpdateIntegration(intlistid, lblKey.Text, chkLout.Checked, chkLin.Checked, chkTout.Checked, chkTin.Checked);
                    intadmin.SaveProperties(hshProps);
                    intadmin.InstallEventHandlers(list);
                    SPUtility.Redirect("epmlive/integration/integrationlist.aspx?LIST=" + Request["List"], SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
                }

            }
            else
            {
                lblError.Visible = true;
                lblError.Text = message;
            }


        }
    }
}
