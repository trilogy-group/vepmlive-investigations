
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace TimeSheets
{
    public partial class dotsaction : System.Web.UI.Page
    {
        private XmlDocument doc = new XmlDocument();
        protected string data;
        string username = SPContext.Current.Web.CurrentUser.LoginName;
        bool impFailed = false;
        string resName = SPContext.Current.Web.CurrentUser.Name;
        bool liveHours = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            string strAction = Request["action"];
            string period = Request["period"];

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            data = "";

            string fEmail = SPContext.Current.Web.CurrentUser.Email;

            SPSite site = SPContext.Current.Site;
            //using ()
            {
                //using ()
                SPWeb web = SPContext.Current.Web;
                {
                    try
                    {
                        SqlConnection cn = null;
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                            cn.Open();

                            string requestedUser = Page.Request["duser"];

                            if (requestedUser != null && requestedUser != "")
                            {
                                if (SharedFunctions.canUserImpersonate(username, requestedUser, SPContext.Current.Site.RootWeb, out resName))
                                {
                                    username = requestedUser;
                                }
                                else
                                    impFailed = true;
                            }
                            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSLiveHours"), out liveHours);
                        });
                        if (impFailed)
                        {
                            data = "Error: Impersonation Failed";
                        }
                        else
                        {
                            if (cn != null)
                            {
                                SqlCommand cmd;

                                int iperiod;
                                SqlDataReader dr;

                                switch (strAction)
                                {
                                    case "deleteTS":
                                        if (web.CurrentUser.IsSiteAdmin)
                                        {
                                            string[] tsuids = Request["ts_uids"].Split(',');
                                            foreach (string tsuidData in tsuids)
                                            {
                                                cmd = new SqlCommand("DELETE FROM TSTIMESHEET where ts_uid=@ts_uid", cn);
                                                cmd.Parameters.AddWithValue("@ts_uid", tsuidData);
                                                cmd.ExecuteNonQuery();
                                            }
                                            data = "Success";
                                        }
                                        else
                                        {
                                            data = "Error: Access Denied";
                                        }
                                        break;
                                    case "closePeriod":
                                        cmd = new SqlCommand("update tsperiod set locked=1 where period_id=@periodid and site_id=@siteid", cn);
                                        cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                        cmd.Parameters.AddWithValue("@periodid", period);
                                        cmd.ExecuteNonQuery();
                                        data = period;
                                        break;
                                    case "openPeriod":
                                        cmd = new SqlCommand("update tsperiod set locked=0 where period_id=@periodid and site_id=@siteid", cn);
                                        cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                        cmd.Parameters.AddWithValue("@periodid", period);
                                        cmd.ExecuteNonQuery();
                                        data = period;
                                        break;
                                    case "submitTime":
                                        cmd = new SqlCommand("update TSTIMESHEET set submitted=1,approval_status=0,lastmodifiedbyu=@u,lastmodifiedbyn=@n where ts_uid=@ts_uid", cn);
                                        cmd.Parameters.AddWithValue("@ts_uid", Request["ts_uid"]);
                                        cmd.Parameters.AddWithValue("@u", SPContext.Current.Web.CurrentUser.LoginName);
                                        cmd.Parameters.AddWithValue("@n", SPContext.Current.Web.CurrentUser.Name);
                                        cmd.ExecuteNonQuery();
                                        SPSecurity.RunWithElevatedPrivileges(delegate()
                                        {
                                            SPWeb tweb = SPContext.Current.Web;
                                            {
                                                SharedFunctions.processResources(cn, Request["ts_uid"], tweb, username);
                                            }
                                        });

                                        if (EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSDisableApprovals").ToLower() == "true")
                                        {
                                            approve(Request["ts_uid"], SPContext.Current.Web, Request["Period"]);
                                        }
                                        else
                                        {
                                            string actualWork = "";
                                            //SPSecurity.RunWithElevatedPrivileges(delegate()
                                            //{
                                            //    actualWork = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSActualWork");
                                            //});
                                            //if (actualWork != "")
                                            //{
                                            if (!liveHours)
                                                data = SharedFunctions.processActualWork(cn, Request["ts_uid"], site, false, true);
                                            //}
                                        }

                                        if (data == "")
                                            data = "Success";

                                        cmd = new SqlCommand("select ts_item_uid,web_uid,list_uid,item_id,project from TSITEM where TS_UID=@ts_uid", cn);
                                        cmd.Parameters.AddWithValue("@ts_uid", Request["ts_uid"]);
                                        DataSet ds = new DataSet();
                                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                                        da.Fill(ds);

                                        SPList pList = null;
                                        SPWeb iWeb = null;
                                        SPList iList = null;
                                        Guid webGuid = Guid.Empty;
                                        Guid listGuid = Guid.Empty;

                                        foreach (DataRow dataRow in ds.Tables[0].Rows)
                                        {
                                            try
                                            {
                                                Guid wGuid = new Guid(dataRow["WEB_UID"].ToString());
                                                Guid lGuid = new Guid(dataRow["LIST_UID"].ToString());

                                                if (webGuid != wGuid)
                                                {
                                                    if (iWeb != null)
                                                    {
                                                        iWeb.Close();
                                                        iWeb = site.OpenWeb(wGuid);
                                                    }
                                                    else
                                                        iWeb = site.OpenWeb(wGuid);
                                                    webGuid = iWeb.ID;
                                                }
                                                if (listGuid != lGuid)
                                                {
                                                    iList = iWeb.Lists[lGuid];
                                                    try
                                                    {
                                                        pList = SharedFunctions.getProjectCenterList(iList);
                                                    }
                                                    catch { }
                                                    listGuid = iList.ID;
                                                }
                                                SPListItem li = iList.GetItemById(int.Parse(dataRow["ITEM_ID"].ToString()));
                                                SharedFunctions.processMeta(iWeb, iList, li, new Guid(dataRow["ts_item_uid"].ToString()), dataRow["project"].ToString(), cn, pList);
                                            }
                                            catch { }
                                        }
                                        break;
                                    case "unsubmitTime":
                                        cmd = new SqlCommand("update TSTIMESHEET set submitted=0,approval_status=0,lastmodifiedbyu=@u,lastmodifiedbyn=@n where ts_uid=@ts_uid", cn);
                                        cmd.Parameters.AddWithValue("@ts_uid", Request["ts_uid"]);
                                        cmd.Parameters.AddWithValue("@u", SPContext.Current.Web.CurrentUser.LoginName);
                                        cmd.Parameters.AddWithValue("@n", SPContext.Current.Web.CurrentUser.Name);
                                        cmd.ExecuteNonQuery();
                                        if (EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSDisableApprovals").ToLower() == "true" && !liveHours)
                                        {
                                            data = SharedFunctions.processActualWork(cn, Request["ts_uid"], site, true, true);
                                        } 
                                        if (data == "")
                                            data = "Success";
                                        break;
                                    case "deletePeriod":
                                        cmd = new SqlCommand("delete from tsperiod where period_id=@periodid and site_id=@siteid", cn);
                                        cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                        cmd.Parameters.AddWithValue("@periodid", period);
                                        cmd.ExecuteNonQuery();
                                        data = "Success";
                                        break;
                                    case "addPeriod":
                                        cmd = new SqlCommand("select top 1 period_id from tsperiod where site_id=@siteid order by period_id desc", cn);
                                        cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                        dr = cmd.ExecuteReader();
                                        iperiod = 1;
                                        if (dr.Read())
                                            iperiod = dr.GetInt32(0) + 1;
                                        dr.Close();

                                        cmd = new SqlCommand("insert into tsperiod (period_start,period_end,period_id,site_id) values (@periodstart,@periodend,@period_id,@siteid)", cn);
                                        cmd.Parameters.AddWithValue("@periodstart", Request["start"]);
                                        cmd.Parameters.AddWithValue("@periodend", Request["end"]);
                                        cmd.Parameters.AddWithValue("@period_id", iperiod);
                                        cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                        cmd.ExecuteNonQuery();
                                        data = "Success";
                                        break;
                                    case "addType":
                                        cmd = new SqlCommand("select top 1 tstype_id from tstype where site_uid=@siteid order by tstype_id desc", cn);
                                        cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                        dr = cmd.ExecuteReader();
                                        iperiod = 1;
                                        if (dr.Read())
                                            iperiod = dr.GetInt32(0) + 1;
                                        dr.Close();

                                        cmd = new SqlCommand("insert into tstype (tstype_id,tstype_name,site_uid) values (@tstype_id,@tstype_name,@siteid)", cn);
                                        cmd.Parameters.AddWithValue("@tstype_name", Request["typename"]);
                                        cmd.Parameters.AddWithValue("@tstype_id", iperiod);
                                        cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                        cmd.ExecuteNonQuery();
                                        data = "Success";
                                        break;
                                    case "editType":
                                        cmd = new SqlCommand("update tstype set tstype_name = @tstype_name where tstype_id=@tstype_id and site_uid=@siteid", cn);
                                        cmd.Parameters.AddWithValue("@tstype_name", Request["typename"]);
                                        cmd.Parameters.AddWithValue("@tstype_id", Request["typeid"]);
                                        cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                        cmd.ExecuteNonQuery();
                                        data = "Success";
                                        break;
                                    case "approveTS":
                                        {
                                            approve(Request["ts_uids"].ToString(), SPContext.Current.Web, Request["Period"]);

                                            if (data == "")
                                                data = "Success";
                                        }
                                        break;
                                    case "rejectTS":
                                        {
                                            string[] tsuids = Request["ts_uids"].Split(',');
                                            foreach (string tsuidData in tsuids)
                                            {
                                                string[] tsuid = tsuidData.Split('|');
                                                cmd = new SqlCommand("update TSTIMESHEET set approval_status=2,approval_notes=@notes where ts_uid=@ts_uid", cn);
                                                cmd.Parameters.AddWithValue("@ts_uid", tsuid[0]);
                                                cmd.Parameters.AddWithValue("@notes", tsuid[1]);
                                                cmd.ExecuteNonQuery();

                                                data += SharedFunctions.processActualWork(cn, tsuid[0], site, true, true);
                                            }
                                            
                                            if (data == "")
                                                data = "Success";
                                        }
                                        break;
                                    case "unlockTS":
                                        {
                                            string[] tsuids = Request["ts_uids"].Split(',');
                                            foreach (string tsuidData in tsuids)
                                            {
                                                string[] tsuid = tsuidData.Split('|');
                                                cmd = new SqlCommand("update TSTIMESHEET set approval_status=0 where ts_uid=@ts_uid", cn);
                                                cmd.Parameters.AddWithValue("@ts_uid", tsuid[0]);
                                                cmd.ExecuteNonQuery();
                                            }
                                            data = "Success";
                                        }
                                        break;
                                    case "rejectEmail":
                                        {
                                            string[] tsuids = Request["ts_uids"].Split(',');
                                            foreach (string tsuid in tsuids)
                                            {
                                                cmd = new SqlCommand("select username,approval_notes,period_start,period_end from vwTSApprovalNotes where ts_uid=@ts_uid", cn);
                                                cmd.Parameters.AddWithValue("@ts_uid", tsuid);
                                                dr = cmd.ExecuteReader();
                                                if (dr.Read())
                                                {
                                                    string username = dr.GetString(0);
                                                    string notes = dr.GetString(1);
                                                    try
                                                    {
                                                        SPUser user = web.AllUsers[username];
                                                        if (user.Email != "")
                                                        {
                                                            System.Net.Mail.MailMessage mailMsg = new MailMessage();
                                                            mailMsg.From = new MailAddress(fEmail);
                                                            mailMsg.To.Add(new MailAddress(user.Email));
                                                            mailMsg.Subject = web.Title + " Timesheet approval notice";
                                                            mailMsg.Body = "Your timesheet for period (" + dr.GetDateTime(2).ToShortDateString() + " - " + dr.GetDateTime(3).ToShortDateString() + ") has been rejected:<br>" + notes;
                                                            mailMsg.IsBodyHtml = true;
                                                            mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
                                                            mailMsg.Priority = MailPriority.Normal;

                                                            // Configure the mail server
                                                            SmtpClient smtpClient = new SmtpClient();
                                                            SPAdministrationWebApplication spWebAdmin = Microsoft.SharePoint.Administration.SPAdministrationWebApplication.Local;
                                                            string sMailSvr = spWebAdmin.OutboundMailServiceInstance.Server.Name;
                                                            smtpClient.Host = sMailSvr;
                                                            smtpClient.Send(mailMsg);
                                                        }
                                                    }
                                                    catch { }
                                                }
                                                dr.Close();
                                            }
                                        }
                                        data = "Success";
                                        break;
                                    case "autoadd":
                                        //string flagfield = "";
                                        string lists = "";
                                        SPSecurity.RunWithElevatedPrivileges(delegate()
                                        {
                                            using (SPSite uSite = SPContext.Current.Site)
                                            {
                                                //flagfield = EPMLiveCore.CoreFunctions.getConfigSetting(uSite.RootWeb, "EPMLiveTSFlag");
                                                lists = EPMLiveCore.CoreFunctions.getConfigSetting(uSite.RootWeb, "EPMLiveTSLists");
                                            }
                                        });
                                        autoAdd(cn, Request["ts_uid"], web, lists);
                                        data = "Success";
                                        break;
                                    case "approvePM":
                                        {
                                            string[] tsitemuids = Request["tsitemuids"].Split(',');

                                            foreach (string tsitemuid in tsitemuids)
                                            {
                                                //string[] tsuid = tsuidData.Split('|');
                                                cmd = new SqlCommand("update tsitem set approval_status=1 where ts_item_uid=@tsitemuid", cn);
                                                cmd.Parameters.AddWithValue("@tsitemuid", tsitemuid);
                                                cmd.ExecuteNonQuery();
                                            }
                                            data = "Success";
                                        }
                                        break;
                                    case "rejectPM":
                                        {
                                            string[] tsitemuids = Request["tsitemuids"].Split(',');

                                            foreach (string tsitemuid in tsitemuids)
                                            {
                                                //string[] tsuid = tsuidData.Split('|');
                                                cmd = new SqlCommand("update tsitem set approval_status=2 where ts_item_uid=@tsitemuid", cn);
                                                cmd.Parameters.AddWithValue("@tsitemuid", tsitemuid);
                                                cmd.ExecuteNonQuery();
                                            }
                                        }
                                        data = "Success";
                                        break;
                                    default:
                                        data = "Error: Invalid Command";
                                        break;
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        data = "Error: " + ex.Message;
                    }
                }
            }
        }

        private void approve(string sTSUids, SPWeb web, string period)
        {

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Approve><Period>" + period + "</Period><TSIDS>" + sTSUids + "</TSIDS></Approve>");

            XmlDocument docRet = new XmlDocument();
            docRet.LoadXml(TimesheetAPI.ApproveTimesheets(doc.OuterXml, web));

            if(docRet.FirstChild.Attributes["Status"].Value == "1")
            {
                data = "Error: " + docRet.FirstChild.SelectSingleNode("//Error").InnerText;
            }
            else
            {
                data = "Success";
            }

        }

        private void autoAdd(SqlConnection cn, string tsuid, SPWeb web, string rolluplists)
        {
            

            SqlConnection cnwss = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPSite s = SPContext.Current.Site;
                {
                    string dbCon = s.ContentDatabase.DatabaseConnectionString;
                    cnwss = new SqlConnection(dbCon);
                    cnwss.Open();
                }
            });
            if (cnwss.State == ConnectionState.Open)
            {
                
                string period = Request["period"];
                string siteurl = web.ServerRelativeUrl.Substring(1);

                if (tsuid == null || tsuid == "")
                {
                    tsuid = Guid.NewGuid().ToString();
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO TSTIMESHEET (TS_UID,USERNAME,PERIOD_ID,SITE_UID,resourcename) VALUES (@TS_UID,@USERNAME,@PERIOD_ID,@SITE_UID,@resourcename)", cn);
                    cmd1.Parameters.AddWithValue("@TS_UID", tsuid);
                    cmd1.Parameters.AddWithValue("@USERNAME", username);
                    cmd1.Parameters.AddWithValue("@resourcename", resName);
                    cmd1.Parameters.AddWithValue("@PERIOD_ID", period);
                    cmd1.Parameters.AddWithValue("@SITE_UID", web.Site.ID);
                    cmd1.ExecuteNonQuery();
                }

                SharedFunctions.processResources(cn, tsuid, web, username);

                SqlCommand cmd = new SqlCommand("SELECT period_start,period_end from TSPERIOD where site_id=@siteid and period_id=@period_id", cn);
                cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                cmd.Parameters.AddWithValue("@period_id", period);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                DateTime pstart = dr.GetDateTime(0);
                DateTime pend = dr.GetDateTime(1);
                dr.Close();

                foreach (string rlist in rolluplists.Replace("\r\n", "\n").Split('\n'))
                {
                    string lists = "";
                    string query = "";
                    if (siteurl == "")
                        query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     (dbo.Webs.FullUrl LIKE '" + siteurl + "%' OR dbo.Webs.FullUrl = '" + siteurl + "') AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";
                    else
                        query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     (dbo.Webs.FullUrl LIKE '" + siteurl + "/%' OR dbo.Webs.FullUrl = '" + siteurl + "') AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";


                    cmd = new SqlCommand(query, cnwss);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lists += "<List ID='" + dr.GetGuid(0).ToString() + "'/>";
                    }
                    dr.Close();

                    if (lists != "")
                    {
                        SPUser u = web.Site.RootWeb.AllUsers[username];

                        SPSiteDataQuery dq = new SPSiteDataQuery();
                        dq.ViewFields = "<FieldRef Name='Title' Nullable='TRUE'/><FieldRef Name='Project' Nullable='TRUE'/>";
                        dq.Webs = "<Webs Scope='Recursive'/>";
                        dq.Lists = "<Lists>" + lists + "</Lists>";
                        dq.Query = "<Where><And><And><And><Eq><FieldRef Name=\"AssignedTo\"  LookupId='True'/><Value Type=\"User\">" + u.ID.ToString() + "</Value></Eq><Eq><FieldRef Name=\"Timesheet\" /><Value Type=\"Boolean\">1</Value></Eq></And><Geq><FieldRef Name=\"DueDate\" /><Value Type=\"DateTime\">" + pstart.ToString("u") + "</Value></Geq></And><Leq><FieldRef Name=\"StartDate\" /><Value Type=\"DateTime\">" + pend.ToString("u") + "</Value></Leq></And></Where>";

                        DataTable dt = web.GetSiteData(dq);

                        Guid webGuid = new Guid();
                        Guid listGuid = new Guid();
                        SPWeb iWeb = null;
                        SPSite iSite = web.Site;
                        SPList iList = null;
                        SPList pList = null;


                        foreach (DataRow dRow in dt.Rows)
                        {
                            cmd = new SqlCommand("SELECT * FROM TSITEM where WEB_UID=@web_uid and LIST_UID = @list_uid and item_id=@item_id and ts_uid=@ts_uid", cn);
                            cmd.Parameters.AddWithValue("@WEB_UID", dRow["WEBID"]);
                            cmd.Parameters.AddWithValue("@LIST_UID", dRow["LISTID"]);
                            cmd.Parameters.AddWithValue("@ITEM_ID", dRow["ID"]);
                            cmd.Parameters.AddWithValue("@ts_uid", tsuid);
                            dr = cmd.ExecuteReader();
                            bool found = false;
                            if (dr.Read())
                            {
                                found = true;
                            }
                            dr.Close();

                            if (!found)
                            {
                                Guid wGuid = new Guid(dRow["WEBID"].ToString());
                                Guid lGuid = new Guid(dRow["LISTID"].ToString());

                                if (webGuid != wGuid)
                                {
                                    pList = null;
                                    if (iWeb != null)
                                    {
                                        iWeb.Close();
                                        iWeb = iSite.OpenWeb(wGuid);
                                    }
                                    else
                                        iWeb = iSite.OpenWeb(wGuid);
                                    webGuid = iWeb.ID;
                                }
                                if (listGuid != lGuid)
                                {
                                    iList = iWeb.Lists[lGuid];
                                    pList = pList = SharedFunctions.getProjectCenterList(iList);
                                    listGuid = iList.ID;
                                }

                                SPListItem li = iList.GetItemById(int.Parse(dRow["ID"].ToString()));
                                string project = "";
                                string project_id = "";
                                try
                                {
                                    //project = iList.Fields["Project"].GetFieldValueAsText(dRow["Project"].ToString());

                                    try
                                    {
                                        SPFieldLookupValue lv = new SPFieldLookupValue(li["Project"].ToString());
                                        project = lv.LookupValue;
                                        project_id = lv.LookupId.ToString();
                                        if(project == null)
                                        {
                                            project = "";
                                            project_id = "0";
                                        }
                                    }
                                    catch { }
                                }
                                catch { }
                                Guid newTS = Guid.NewGuid();

                                cmd = new SqlCommand("INSERT INTO TSITEM (TS_UID,TS_ITEM_UID,WEB_UID,LIST_UID,ITEM_TYPE,ITEM_ID,TITLE,PROJECT,LIST,PROJECT_ID,PROJECT_LIST_UID) VALUES (@TS_UID,@TS_ITEM_UID,@WEB_UID,@LIST_UID,@ITEM_TYPE,@ITEM_ID,@TITLE,@PROJECT,@LIST,@PROJECT_ID,@projectlistuid)", cn);
                                cmd.Parameters.AddWithValue("@TS_UID", tsuid);
                                cmd.Parameters.AddWithValue("@TS_ITEM_UID", newTS);
                                cmd.Parameters.AddWithValue("@WEB_UID", dRow["WEBID"].ToString());
                                cmd.Parameters.AddWithValue("@LIST_UID", dRow["LISTID"].ToString());
                                cmd.Parameters.AddWithValue("@ITEM_TYPE", 1);
                                cmd.Parameters.AddWithValue("@ITEM_ID", dRow["ID"].ToString());
                                cmd.Parameters.AddWithValue("@TITLE", dRow["Title"].ToString());
                                cmd.Parameters.AddWithValue("@PROJECT", project);
                                cmd.Parameters.AddWithValue("@PROJECT_ID", project_id);
                                cmd.Parameters.AddWithValue("@LIST", rlist);
                                if(pList != null)
                                    cmd.Parameters.AddWithValue("@projectlistuid", pList.ID);
                                else
                                    cmd.Parameters.AddWithValue("@projectlistuid", DBNull.Value);
                                cmd.ExecuteNonQuery();

                                SharedFunctions.processMeta(iWeb, iList, li, newTS, project, cn, pList);

                                //processMeta(cn, iWeb, iList, li, newTS, project, pList);
                            }
                        }
                    }
                }
                SqlCommand cmd2 = new SqlCommand("UPDATE TSTIMESHEET set lastmodifiedbyu=@u,lastmodifiedbyn=@n where ts_uid=@TS_UID", cn);
                cmd2.Parameters.AddWithValue("@TS_UID", tsuid);
                cmd2.Parameters.AddWithValue("@u", SPContext.Current.Web.CurrentUser.LoginName);
                cmd2.Parameters.AddWithValue("@n", SPContext.Current.Web.CurrentUser.Name);
                cmd2.ExecuteNonQuery();
                cnwss.Close();
            }
        }


        public static byte[] StrToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }

    }
}