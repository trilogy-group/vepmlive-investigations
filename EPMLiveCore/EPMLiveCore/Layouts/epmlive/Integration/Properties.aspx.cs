using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using System.Xml;
using System.Data;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class Properties : LayoutsPageBase
    {
        protected string PageHead;
        protected Guid intlistid = Guid.Empty;
        protected Guid moduleid = Guid.Empty;
        API.Integration.IntegrationCore intcore;
        API.Integration.IntegrationAdmin intadmin;

        protected void Page_Load(object sender, EventArgs e)
        {

            SPSecurity.RunWithElevatedPrivileges(delegate()
             {
                 try
                 {
                     intlistid = new Guid(Request["intlistid"]);
                 }
                 catch { }

                 lblID.Text  = intlistid.ToString();

                 try
                 {
                     moduleid = new Guid(Request["module"]);
                 }
                 catch { }

                 intcore = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);
                 intadmin = new API.Integration.IntegrationAdmin(intcore, intlistid, moduleid);


                 PageHead = intadmin.GetIntegrationHeader();

                 Hashtable hshProps = new Hashtable();
                 if(intlistid != Guid.Empty)
                     hshProps = intcore.GetProperties(intlistid);

                 XmlDocument doc = intcore.GetModuleProperties(intlistid, moduleid);

                 XmlNode ndCon = doc.FirstChild.SelectSingleNode("/Properties/General");

                 lblMain.Controls.AddAt(0, intadmin.GetPropertyPanel(ndCon, hshProps, this));

                 if(intlistid != Guid.Empty && !IsPostBack)
                 {
                     Hashtable hshParms = new Hashtable();
                     hshParms.Add("intlistid", intlistid);
                     DataSet dsInfo = intcore.GetDataSet("SELECT * FROM INT_LISTS where INT_LIST_ID=@intlistid", hshParms);
                     DataRow dr = dsInfo.Tables[0].Rows[0];

                     lblKey.Text = dr["INT_KEY"].ToString();

                     if(dr["LIVEOUTGOING"].ToString() == "True")
                         chkLout.Checked = true;
                     if(dr["LiveIncoming"].ToString() == "True")
                         chkLin.Checked = true;
                     if(dr["TIMEOUTGOING"].ToString() == "True")
                         chkTout.Checked = true;
                     if(dr["TIMEINCOMING"].ToString() == "True")
                         chkTin.Checked = true;

                     try
                     {
                         chkDeleteList.Checked = bool.Parse(hshProps["AllowDeleteList"].ToString());
                     }
                     catch { }
                     try
                     {
                         chkDeleteInt.Checked = bool.Parse(hshProps["AllowDeleteInt"].ToString());
                     }
                     catch { }

                     try
                     {
                         chkAddList.Checked = bool.Parse(hshProps["AllowAddList"].ToString());
                     }
                     catch { }
                     try
                     {
                         chkAddInt.Checked = bool.Parse(hshProps["AllowAddInt"].ToString());
                     }
                     catch { }
                 }
                 else
                 {
                     chkLout.Checked = true;
                 }


                 if(lblKey.Text == "")
                     lblKey.Text = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");

                 if(Request["wizard"] == "1")
                     Button1.Text = "Next >";
             });

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
            SPSecurity.RunWithElevatedPrivileges(delegate()
             {
                 if(intcore.TestModuleConnection(intadmin.ModuleID, intlistid, new Guid(Request["List"]), out message))
                 {
                     lblError.Visible = false;

                     Hashtable hshProps = new Hashtable();
                     hshProps.Add("AllowDeleteList", chkDeleteList.Checked.ToString());
                     hshProps.Add("AllowDeleteInt", chkDeleteInt.Checked.ToString());
                     hshProps.Add("AllowAddList", chkAddList.Checked.ToString());
                     hshProps.Add("AllowAddInt", chkAddInt.Checked.ToString());

                     intadmin.UpdateIntegration(intlistid, lblKey.Text, chkLout.Checked, chkLin.Checked, chkTout.Checked, chkTin.Checked);
                     intadmin.SaveProperties(hshProps);

                     if(Request["wizard"] == "1")
                     {
                         SPUtility.Redirect("epmlive/integration/columns.aspx?intlistid=" + intadmin.intlistid + "&LIST=" + Request["List"] + "&wizard=1", SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
                     }
                     else
                     {

                         SPUtility.Redirect("epmlive/integration/integrationlist.aspx?LIST=" + Request["List"], SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
                     }

                 }
                 else
                 {
                     lblError.Visible = true;
                     lblError.Text = message;
                 }
             });

        }
    }
}
