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
using System.ComponentModel;
using System.Threading;
using System.Data.SqlClient;
using System.Text;

namespace EPMLiveEnterprise
{
    public partial class runenterprisesynch : System.Web.UI.Page
    {
        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = SPContext.Current.Web.CurrentUser.LoginName;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    

                    //string[] sParams = new string[2] { , Request["siteid"] };

                    Thread timerThread = new Thread(RunThread);
                    timerThread.Name = "Timer Thread";
                    timerThread.Priority = ThreadPriority.Normal;
                    timerThread.IsBackground = true;
                    timerThread.Start(SPContext.Current.Site.ID.ToString() + "|" + SPContext.Current.Site.WebApplication.Id.ToString() + "|" + SPContext.Current.Web.ID.ToString() + "|" + username); 

                    data = "Success";
                }
                catch (Exception ex)
                {
                    data = "Error: " + ex.Message;
                }
            });
        }

        void RunThread(object o)
        {
            //string[] sParam = (string[])o;

            string sFullParam = (string)o;

            string sSite = sFullParam.Split('|')[0];
            string sWebApp = sFullParam.Split('|')[1];
            string sWeb = sFullParam.Split('|')[2];
            string username = sFullParam.Split('|')[3];

            string sCon = EPMLiveCore.CoreFunctions.getConnectionString(new Guid(sWebApp));

            SqlConnection cn = new SqlConnection(sCon);
            cn.Open();

            SqlCommand cmd = new SqlCommand("select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=9", cn);
            cmd.Parameters.AddWithValue("@siteguid", sSite);
            SqlDataReader dr = cmd.ExecuteReader();

            Guid tjGuid = Guid.Empty;
            bool processing = false;
            if (dr.Read())
            {
                tjGuid = dr.GetGuid(0);
                if (!dr.IsDBNull(3))
                    if (dr.GetInt32(3) != 2)
                        processing = true;
                dr.Close();
            }
            else
            {
                dr.Close();

                tjGuid = Guid.NewGuid();

                cmd = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, scheduletype, webguid) VALUES (@timerjobuid, @siteguid, 9, 'Project Server Field Synch', 5, @webguid)", cn);
                cmd.Parameters.AddWithValue("@siteguid", sSite);
                cmd.Parameters.AddWithValue("@webguid", sWeb);
                cmd.Parameters.AddWithValue("@timerjobuid", tjGuid);
                cmd.ExecuteNonQuery();
            }

            if (processing)
            {
                cn.Close();
                return;
            }

            cmd = new SqlCommand("delete from epmlive_log where timerjobuid=@timerjobuid", cn);
            cmd.Parameters.AddWithValue("@timerjobuid", tjGuid);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("select status from queue where timerjobuid=@timerjobuid", cn);
            cmd.Parameters.AddWithValue("@timerjobuid", tjGuid);
            dr = cmd.ExecuteReader();

            int status = 2;

            if (dr.Read())
            {
                status = dr.GetInt32(0);
            }

            dr.Close();

            if (status == 2)
            {
                cmd = new SqlCommand("DELETE FROM QUEUE where timerjobuid = @timerjobuid ", cn);
                cmd.Parameters.AddWithValue("@timerjobuid", tjGuid);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO QUEUE (timerjobuid, status, percentcomplete, dtstarted) VALUES (@timerjobuid, @status, 0, getdate()) ", cn);
                cmd.Parameters.AddWithValue("@timerjobuid", tjGuid);
                cmd.Parameters.AddWithValue("@status", 1);
                cmd.ExecuteNonQuery();
            }


            //SqlCommand cmd = new SqlCommand("select * from epmlive_log where source='" + sSite + "' and action='esynch'", cn);
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (!dr.Read())
            //{
            //    dr.Close();
            //    cmd = new SqlCommand("INSERT INTO epmlive_log (source,action,percentComplete,result, dtlogged) VALUES ('" + sSite + "','esynch',0,'Processing',GETDATE())", cn);
            //    cmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    dr.Close();
            //    cmd = new SqlCommand("UPDATE epmlive_log set percentComplete=0, result='Processing' where source='" + sSite + "' and action = 'esynch'", cn);
            //    cmd.ExecuteNonQuery();
            //}

            ////////////////////////////////////////////////////////////////////
            StringBuilder sbOut = new StringBuilder();

            try
            {
                cmd = new SqlCommand("select config_value from econfig where config_name='ConnectedURLs'", cn);
                dr = cmd.ExecuteReader();

                string sSites = "";
                int siteCount = 1;
                string[] strSites = null;

                if (dr.Read())
                {
                    sSites = dr.GetString(0);
                }
                dr.Close();

                if (sSites != "")
                {
                    strSites = sSites.Replace("\r\n", "\n").Split('\n');
                    siteCount += strSites.Length;
                }
                ////////////////////////////////////////////////////////////////////



                using (SPSite site = new SPSite(new Guid(sSite)))
                {
                    sbOut.Append("Site: " + site.RootWeb.Title + " (" + site.Url + ")<br>");
                    SPWebCollection webc = site.AllWebs;
                    double counter = 0;
                    double percent = 0;
                    double totalWebs = webc.Count;

                    foreach (SPWeb w in webc)
                    {
                        sbOut.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Web: " + w.Title + " (" + w.Url + ")<br>");
                        ProjectWorkspaceSynch pws = new ProjectWorkspaceSynch(new Guid(sSite), w.Url, new Guid(), username);
                        pws.processProjectCenter();
                        pws.processTaskCenter();
                        counter++;

                        double newPercent = counter / totalWebs / siteCount * 100;
                        if (newPercent >= percent + 5)
                        {
                            percent = newPercent;
                            cmd = new SqlCommand("UPDATE queue set percentComplete=" + newPercent + " where timerjobuid='" + tjGuid + "'", cn);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                double siteCounter = 1;

                if (strSites != null)
                {
                    foreach (string strSite in strSites)
                    {
                        using (SPSite site = new SPSite(strSite))
                        {
                            sbOut.Append("Site: " + site.RootWeb.Title + " (" + site.Url + ")<br>");
                            SPWebCollection webc = site.AllWebs;
                            double counter = 0;
                            double percent = 0;
                            double totalWebs = webc.Count;

                            foreach (SPWeb w in webc)
                            {
                                sbOut.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Web: " + w.Title + " (" + w.Url + ")<br>");
                                ProjectWorkspaceSynch pws = new ProjectWorkspaceSynch(new Guid(sSite), w.Url, new Guid(), username);
                                pws.processProjectCenter();
                                pws.processTaskCenter();
                                counter++;

                                double newPercent = (counter / totalWebs / siteCount + siteCounter / siteCount) * 100;
                                if (newPercent >= percent + 5)
                                {
                                    percent = newPercent;
                                    cmd = new SqlCommand("UPDATE queue set percentComplete=" + newPercent + " where timerjobuid='" + tjGuid + "'", cn);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        siteCounter++;
                    }
                }

                cmd = new SqlCommand("insert into epmlive_log (timerjobuid,result,resulttext) VALUES (@timerjobuid,'No Errors',@resulttext)", cn);
                cmd.Parameters.AddWithValue("@timerjobuid", tjGuid);
                cmd.Parameters.AddWithValue("@resulttext", sbOut.ToString());
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                cmd = new SqlCommand("insert into epmlive_log (timerjobuid,result,resulttext) VALUES (@timerjobuid,'Errors',@resulttext)", cn);
                cmd.Parameters.AddWithValue("@timerjobuid", tjGuid);
                cmd.Parameters.AddWithValue("@resulttext", sbOut + "<br><br>Error: " + ex.Message);
                cmd.ExecuteNonQuery();
            }
            
            cmd = new SqlCommand("UPDATE queue set percentComplete=0,status=2,dtfinished=GETDATE() where timerjobuid=@timerjobuid", cn);
            cmd.Parameters.AddWithValue("@timerjobuid", tjGuid);
            cmd.ExecuteNonQuery();

            cn.Close();
        }

    }
}