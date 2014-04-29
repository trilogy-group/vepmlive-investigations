using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

using System.Net.Mail;

namespace TimeSheets
{
    public partial class sendtsemail : LayoutsPageBase
    {

        protected static string source;
        protected string strUsers;
        protected TextBox txtSubject;
        protected TextBox txtBody;
        protected string strSent;
        protected Panel pnlMain;
        protected Panel pnlSent;
        protected Panel pnlNone;

        protected HiddenField hdnNames;
        protected HiddenField hdnEmails;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string emails = "";
                string names = "";

                source = Request["source"];

                SPWeb web = SPContext.Current.Web;
                web.Site.CatchAccessDeniedException = false;
                EnsureChildControls();

                string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                SPWeb resWeb;
                SPList reslist;

                DataSet dsSubmitted = new DataSet();
                DataSet dsTimesheets = new DataSet();

                if (resUrl != "")
                {
                    try
                    {

                        //if (resUrl.ToLower() != web.Url.ToLower())
                        //{
                        //    using (SPSite tempSite = new SPSite(resUrl))
                        //    {

                        //        resWeb = tempSite.OpenWeb();
                        //        if (resWeb.Url.ToLower() != resUrl.ToLower())
                        //        {
                        //            resWeb = null;
                        //        }
                        //    }
                        //}
                        //else
                        //    resWeb = web;
                        //if (resWeb != null)
                        //{
                            //reslist = resWeb.Lists["Resources"];

                            //SPQuery query = new SPQuery();
                            //query.Query = "<Where><Contains><FieldRef Name='TimesheetManager'/><Value Type='User'>" + SPContext.Current.Web.CurrentUser.Name + "</Value></Contains></Where>";

                            DataTable dtResources = EPMLiveCore.API.APITeam.GetResourcePool("<Resources><Columns>SimpleColumns,Email</Columns></Resources>", Web);

                            foreach(string sRes in Request["resources"].Split(','))
                            {
                                if(sRes != "")
                                {
                                    DataRow[] dr = dtResources.Select("SPID='" + sRes + "'");
                                    if (dr.Length > 0)
                                    {
                                        strUsers += dr[0]["Title"].ToString() + "<br>";
                                        emails += "," + dr[0]["Email"].ToString();
                                        names += "," + dr[0]["Title"].ToString();
                                    }
                                }
                            }

                            /*if (Request["type"] == "1" || Request["type"] == "3")
                            {
                                SPSecurity.RunWithElevatedPrivileges(delegate()
                                {
                                    try
                                    {
                                        SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                                        cn.Open();

                                        SqlCommand cmd = new SqlCommand("select ts_uid,username from TSTIMESHEET where period_id=@period_id and site_uid=@siteid and submitted=1", cn);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Parameters.AddWithValue("@period_id", Request["period"]);
                                        cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                                        dsSubmitted = new DataSet();
                                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                                        da.Fill(dsSubmitted);


                                        cmd = new SqlCommand("select ts_uid,username from TSTIMESHEET where period_id=@period_id and site_uid=@siteid and ts_uid in (SELECT Item FROM dbo.Split (@timesheets, ';#'))", cn);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Parameters.AddWithValue("@period_id", Request["period"]);
                                        cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                                        cmd.Parameters.AddWithValue("@timesheets", Request["timesheets"].Replace(",", ";#"));
                                        //Request["timesheets"].Replace(",","','")
                                        dsTimesheets = new DataSet();
                                        da = new SqlDataAdapter(cmd);
                                        da.Fill(dsTimesheets);

                                        cn.Close();
                                    }
                                    catch { }
                                });
                            }*/

                            //foreach (SPListItem li in reslist.GetItems(query))
                            //{
                            //    SPFieldUserValue uv = new SPFieldUserValue(web, li["SharePointAccount"].ToString());
                            //    string uName = uv.User.LoginName;
                            //    string name = uv.User.Name.Replace(",", ";");
                            //    string email = uv.User.Email;

                            //    if (email != "")
                            //    {
                            //        if (Request["type"] == "1")
                            //        {
                            //            if (dsSubmitted.Tables[0].Select("username like '" + uName + "'").Length == 0)
                            //            {
                            //                strUsers += name + "<br>";
                            //                emails += "," + email;
                            //                names += "," + name;
                            //            }
                            //        }
                            //        else if (Request["type"] == "3")
                            //        {
                            //            if (dsTimesheets.Tables[0].Select("username like '" + uName + "'").Length > 0)
                            //            {
                            //                strUsers += name + "<br>";
                            //                emails += "," + email;
                            //                names += "," + name;
                            //            }
                            //        }
                            //        else
                            //        {
                            //            strUsers += name + "<br>";
                            //            emails += "," + email;
                            //            names += "," + name;
                            //        }
                            //    }
                            //}
                            //if (resWeb.ID != SPContext.Current.Web.ID)
                            //    resWeb.Close();


                        //}
                    }
                    catch { }
                    if (emails.Length > 0)
                    {
                        emails = emails.Substring(1);
                        names = names.Substring(1);
                    }
                    else
                    {
                        pnlMain.Visible = false;
                        pnlNone.Visible = true;
                    }
                    hdnEmails.Value = emails;
                    hdnNames.Value = names;
                }
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            strSent = "";

            string emails = hdnEmails.Value;
            string names = hdnNames.Value;

            SPWeb web = SPContext.Current.Web;
            {
                string fromEmail = web.CurrentUser.Email;
                if (fromEmail == "")
                    fromEmail = "no-reply@epmlive.com";

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                    string[] semails = emails.Split(',');
                    string[] snames = names.Split(',');

                    string body = txtBody.Text + "<br><br>Go To Site: <a href=\"" + web.Url + "\">" + web.Title + "</a>";

                    for (int i = 0; i < semails.Length; i++)
                    {
                        if (semails[i] != "")
                        {
                            try
                            {
                                System.Net.Mail.MailMessage mailMsg = new MailMessage();
                                mailMsg.From = new MailAddress(fromEmail);
                                mailMsg.To.Add(new MailAddress(semails[i]));
                                mailMsg.Subject = txtSubject.Text;
                                mailMsg.Body = body;
                                mailMsg.IsBodyHtml = true;
                                mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
                                mailMsg.Priority = MailPriority.Normal;

                                // Configure the mail server
                                SmtpClient smtpClient = new SmtpClient();
                                SPAdministrationWebApplication spWebAdmin = Microsoft.SharePoint.Administration.SPAdministrationWebApplication.Local;
                                string sMailSvr = spWebAdmin.OutboundMailServiceInstance.Server.Name;
                                smtpClient.Host = sMailSvr;
                                smtpClient.Send(mailMsg);
                                strSent += snames[i] + " (" + semails[i] + ")...Success<br>";
                            }
                            catch (Exception ex)
                            {
                                strSent += "<font color=\"red\">" + snames[i] + " (" + semails[i] + ")...Failed: " + ex.Message + "</font><br>";
                            }
                        }
                    }

                });
            }

            pnlMain.Visible = false;
            pnlSent.Visible = true;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(source);
        }
    }
}
