using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

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
                 Dictionary<string,string> sASO = intcore.GetDropDownProperties(intadmin.ModuleID, intadmin.intlistid, new Guid(Request["LIST"]) , "AvailableSynchOptions","") ??
                                                  new Dictionary<string, string>();

                 if (sASO.Count == 0)
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
                         using (var connection = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id)))
                         {
                             connection.Open();

                             using (var command = new SqlCommand("SELECT scheduletype, runtime, days from TIMERJOBS where listguid=@listguid and jobtype=70 and [key]=@key", connection))
                             {
                                 command.Parameters.AddWithValue("@listguid", Request["List"]);
                                 command.Parameters.AddWithValue("@key", Request["intlistid"]);
                                 using (var dataReader = command.ExecuteReader())
                                 {
                                     if (dataReader.Read())
                                     {
                                         ddlScheduleType.SelectedValue = dataReader.GetInt32(0).ToString();
                                         if (ddlScheduleType.SelectedValue == "2")
                                         {
                                             ddlHour.SelectedValue = dataReader.GetInt32(1).ToString();

                                             var arrayList = new ArrayList(dataReader.GetString(2).Split(','));
                                             foreach (ListItem listItem in chkDayOfWeek.Items)
                                             {
                                                 if (arrayList.Contains(listItem.Value))
                                                 {
                                                     listItem.Selected = true;
                                                 }
                                             }

                                         }
                                         else if (ddlScheduleType.SelectedValue == "3")
                                         {
                                             ddlDayOfMonth.SelectedValue = dataReader.GetInt32(1).ToString();
                                         }
                                     }
                                 }
                             }
                         }
                     }
                 }


             });

        }

        public override string PageToRedirectOnCancel
        {
            get
            {
                if (Request["ret"] == "Manage")
                    return "manage.aspx";
                else
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

                     using (var connection = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id)))
                     {
                         connection.Open();

                         using (var command = new SqlCommand("DELETE FROM TIMERJOBS WHERE listguid=@listid and jobtype=70 and [key]=@data", connection))
                         {
                             command.Parameters.AddWithValue("@listid", Request["LIST"]);
                             command.Parameters.AddWithValue("@data", Request["intlistid"]);
                             command.ExecuteNonQuery();
                         }

                         if (!string.IsNullOrWhiteSpace(ddlTimed.SelectedValue))
                         {
                             var days = string.Empty;
                             var stringBuilder = new StringBuilder();
                             var runtime = 0;
                             if (ddlScheduleType.SelectedValue == "3")
                             {
                                 runtime = int.Parse(ddlDayOfMonth.SelectedValue);
                             }
                             else if (ddlScheduleType.SelectedValue == "2")
                             {
                                 runtime = int.Parse(ddlHour.SelectedValue);
                                 foreach (ListItem listItem in chkDayOfWeek.Items)
                                 {
                                     if (listItem.Selected)
                                     {
                                         stringBuilder.Append(",")
                                            .Append(listItem.Value);
                                     }
                                 }
                                 days = stringBuilder.ToString().Trim(',');
                             }

                             using (var command = new SqlCommand("INSERT INTO TIMERJOBS (jobname, siteguid, webguid, listguid, jobtype, runtime, scheduletype, days, [key]) VALUES ('Integration', @siteguid, @webguid, @listguid, 70, @runtime, @scheduletype, @days, @key)", connection))
                             {
                                 command.Parameters.AddWithValue("@siteguid", Web.Site.ID);
                                 command.Parameters.AddWithValue("@webguid", Web.ID);
                                 command.Parameters.AddWithValue("@listguid", Request["LIST"]);
                                 command.Parameters.AddWithValue("@runtime", runtime);
                                 command.Parameters.AddWithValue("@scheduletype", ddlScheduleType.SelectedValue);
                                 command.Parameters.AddWithValue("@days", days);
                                 command.Parameters.AddWithValue("@key", Request["intlistid"]);

                                 command.ExecuteNonQuery();
                             }                             
                         }
                     }

                     if(Request["wizard"] == "1")
                     {
                         SPUtility.Redirect("epmlive/integration/columns.aspx?intlistid=" + intadmin.intlistid + "&LIST=" + Request["List"] + "&wizard=1&ret=" + Request["ret"], SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
                     }
                     else
                     {
                         if (Request["ret"] == "Manage")
                            SPUtility.Redirect("epmlive/integration/manage.aspx", SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
                         else
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

        public override void Dispose()
        {
            for (var i = 0; i < lblMain.Controls.Count; i++)
            {
                var control = lblMain.Controls[i];
                control?.Dispose();
            }
            base.Dispose();
        }
    }
}
