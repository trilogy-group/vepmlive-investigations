using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Collections.Generic;

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

            ddlTimed.Attributes.Add("OnChange", "ChangeTimed()");
            ddlScheduleType.Attributes.Add("OnChange", "ChangeSchedule()");

            //if(!IsPostBack)
            {
                for(int i = 1; i < 31; i++)
                {
                    ddlDayOfMonth.Items.Add(i.ToString());
                }


                for(int i = 0; i < 24; i++)
                {
                    ddlHour.Items.Add(new ListItem(i.ToString() + ":00", i.ToString()));
                }
            }

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

                 try
                 {
                     lblURL.Text = intcore.GetAPIUrl(Web.Site.WebApplication.Id);
                 }
                 catch { }
                 Dictionary<string,string> sASO = intcore.GetDropDownProperties(intadmin.ModuleID, intadmin.intlistid, new Guid(Request["LIST"]) , "AvailableSynchOptions","");

                 if(sASO.Count == 0)
                 {
                     sASO.Add("LI", "LI");
                     sASO.Add("LO", "LO");
                     sASO.Add("TO", "TO");
                     sASO.Add("TI", "TI");
                 }

                 if(!sASO.ContainsKey("LI"))
                     chkLin.Enabled = false;
                 if(!sASO.ContainsKey("LO"))
                     chkLout.Enabled = false;
                 if(!sASO.ContainsKey("TO"))
                     ddlTimed.Items.Remove(ddlTimed.Items.FindByValue("out"));
                 if(!sASO.ContainsKey("TI"))
                     ddlTimed.Items.Remove(ddlTimed.Items.FindByValue("in"));

                 if(intlistid != Guid.Empty)
                 {
                     if(!IsPostBack)
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
                             ddlTimed.SelectedValue = "out";
                         if(dr["TIMEINCOMING"].ToString() == "True")
                             ddlTimed.SelectedValue = "in";

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
                 }
                 else
                 {
                     chkLout.Checked = true;
                 }


                 if(lblKey.Text == "")
                     lblKey.Text = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");

                 if(Request["wizard"] == "1")
                     Button1.Text = "Next >";

                 if(!IsPostBack)
                 {
                     if(ddlTimed.SelectedValue != "")
                     {
                         SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id));
                         cn.Open();

                         SqlCommand cmd = new SqlCommand("SELECT scheduletype, runtime, days from TIMERJOBS where listguid=@listguid and jobtype=70 and [key]=@key", cn);
                         cmd.Parameters.AddWithValue("@listguid", Request["List"]);
                         cmd.Parameters.AddWithValue("@key", Request["intlistid"]);
                         SqlDataReader dr = cmd.ExecuteReader();
                         if(dr.Read())
                         {

                             ddlScheduleType.SelectedValue = dr.GetInt32(0).ToString();
                             if(ddlScheduleType.SelectedValue == "2")
                             {
                                 ddlHour.SelectedValue = dr.GetInt32(1).ToString();

                                 ArrayList arr = new ArrayList(dr.GetString(2).Split(','));
                                 foreach(ListItem li in chkDayOfWeek.Items)
                                 {
                                     if(arr.Contains(li.Value))
                                     {
                                         li.Selected = true;
                                     }
                                 }

                             }
                             else if(ddlScheduleType.SelectedValue == "3")
                             {
                                 ddlDayOfMonth.SelectedValue = dr.GetInt32(1).ToString();
                             }
                         }
                         dr.Close();
                         cn.Close();
                     }
                 }


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

                     intadmin.UpdateIntegration(intlistid, lblKey.Text, chkLout.Checked, chkLin.Checked, ddlTimed.SelectedValue == "out", ddlTimed.SelectedValue == "in");
                     intadmin.SaveProperties(hshProps);

                     SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id));
                     cn.Open();

                     SqlCommand cmd = new SqlCommand("DELETE FROM TIMERJOBS WHERE listguid=@listid and jobtype=70 and [key]=@data",cn);
                     cmd.Parameters.AddWithValue("@listid", Request["LIST"]);
                     cmd.Parameters.AddWithValue("@data", Request["intlistid"]);
                     cmd.ExecuteNonQuery();
                     

                     if(ddlTimed.SelectedValue != "")
                     {
                         string days = "";
                         int runtime = 0;
                         if(ddlScheduleType.SelectedValue == "3")
                         {
                             runtime = int.Parse(ddlDayOfMonth.SelectedValue);
                         }
                         else if(ddlScheduleType.SelectedValue == "2")
                         {
                             runtime = int.Parse(ddlHour.SelectedValue);
                             foreach(ListItem li in chkDayOfWeek.Items)
                             {
                                 if(li.Selected)
                                 {
                                     days += "," + li.Value;
                                 }
                             }
                             days = days.Trim(',');
                         }

                         cmd = new SqlCommand("INSERT INTO TIMERJOBS (jobname, siteguid, webguid, listguid, jobtype, runtime, scheduletype, days, [key]) VALUES ('Integration', @siteguid, @webguid, @listguid, 70, @runtime, @scheduletype, @days, @key)", cn);
                         cmd.Parameters.AddWithValue("@siteguid", Web.Site.ID);
                         cmd.Parameters.AddWithValue("@webguid", Web.ID);
                         cmd.Parameters.AddWithValue("@listguid", Request["LIST"]);
                         cmd.Parameters.AddWithValue("@runtime", runtime);
                         cmd.Parameters.AddWithValue("@scheduletype", ddlScheduleType.SelectedValue);
                         cmd.Parameters.AddWithValue("@days", days);
                         cmd.Parameters.AddWithValue("@key", Request["intlistid"]);

                         cmd.ExecuteNonQuery();

                         //API.Timer.AddTimerJob(Web.Site.ID, Web.ID, new Guid(Request["LIST"]), "Integration", 70, "", Request["intlistid"], runtime, int.Parse(ddlScheduleType.SelectedValue), days);  
                     }

                     cn.Close();

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
