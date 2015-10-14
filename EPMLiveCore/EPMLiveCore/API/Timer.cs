using System;
using Microsoft.SharePoint;
using System.Data.SqlClient;
using System.Xml;
using EPMLiveCore.Jobs;
using System.Web.Script.Serialization;

namespace EPMLiveCore.API
{
    public class Timer
    {
        public static XmlNode GetTimerJobStatus(Guid siteid, Guid webid, int jobtype, bool getResultText)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<TimerJobStatus ID=\"\" Status=\"-1\" PercentComplete=\"0\" Finished=\"\"></TimerJobStatus>");
            XmlNode ndStatus = doc.FirstChild;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(siteid))
                {
                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT status,timerjobuid,percentcomplete,dtfinished,resulttext from vwQueueTimerLog where siteguid=@siteuid and webguid=@webuid and jobtype=@jobtype", cn);
                    cmd.Parameters.AddWithValue("@siteuid", siteid);
                    cmd.Parameters.AddWithValue("@webuid", webid);
                    cmd.Parameters.AddWithValue("@jobtype", jobtype);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        ndStatus.Attributes["Status"].Value = dr.GetInt32(0).ToString();
                        ndStatus.Attributes["ID"].Value = dr.GetGuid(1).ToString();
                        ndStatus.Attributes["PercentComplete"].Value = dr.GetInt32(2).ToString();
                        if(!dr.IsDBNull(3))
                            ndStatus.Attributes["Finished"].Value = dr.GetDateTime(3).ToUniversalTime().ToString();
                        if(getResultText)
                            if(!dr.IsDBNull(4))
                                ndStatus.InnerText = "<![CDATA[" + System.Web.HttpUtility.HtmlEncode(dr.GetString(4)) + "]]>";

                    }
                    dr.Close();
                    cn.Close();
                }
            });

            return ndStatus;

        }
        public static XmlNode GetTimerJobStatus(Guid siteid, Guid? webid, Guid? listid, int? itemid, int jobtype)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<TimerJobStatus ID=\"\" Status=\"-1\" PercentComplete=\"0\" Finished=\"\"></TimerJobStatus>");
            XmlNode ndStatus = doc.FirstChild;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(siteid))
                {
                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT status,timerjobuid,percentcomplete,dtfinished,resulttext from vwQueueTimerLog where siteguid=@siteuid and webguid=@webuid and listguid=@listuid and itemid=@itemid and jobtype=@jobtype", cn);
                    cmd.Parameters.AddWithValue("@siteuid", siteid);
                    
                    if(webid.HasValue)
                        cmd.Parameters.AddWithValue("@webuid", webid);
                    else
                        cmd.Parameters.AddWithValue("@webuid", DBNull.Value);

                    if(listid.HasValue)
                        cmd.Parameters.AddWithValue("@listuid", listid);
                    else
                        cmd.Parameters.AddWithValue("@listuid", DBNull.Value);

                    if(itemid.HasValue)
                        cmd.Parameters.AddWithValue("@itemid", itemid);
                    else
                        cmd.Parameters.AddWithValue("@itemid", DBNull.Value);

                    cmd.Parameters.AddWithValue("@jobtype", jobtype);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        ndStatus.Attributes["Status"].Value = dr.GetInt32(0).ToString();
                        ndStatus.Attributes["ID"].Value = dr.GetGuid(1).ToString();
                        ndStatus.Attributes["PercentComplete"].Value = dr.GetInt32(2).ToString();
                        if(!dr.IsDBNull(3))
                            ndStatus.Attributes["Finished"].Value = dr.GetDateTime(3).ToUniversalTime().ToString();
                        ndStatus.InnerText = "<![CDATA[" + System.Web.HttpUtility.HtmlEncode(dr.GetString(4)) + "]]>";

                    }
                    dr.Close();
                    cn.Close();
                }
            });

            return ndStatus;
        }

        public static XmlNode GetTimerJobStatus(SPWeb web, Guid timerjobuid)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<TimerJobStatus ID=\"\" Status=\"-1\" PercentComplete=\"0\" Finished=\"\" Result=\"\"></TimerJobStatus>");
            XmlNode ndStatus = doc.FirstChild;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(web.Site.ID))
                {
                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT status,timerjobuid,percentcomplete,dtfinished,resulttext,result from vwQueueTimerLog where timerjobuid=@timerjobuid", cn);
                    cmd.Parameters.AddWithValue("@timerjobuid", timerjobuid);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        ndStatus.Attributes["Status"].Value = dr.GetInt32(0).ToString();
                        ndStatus.Attributes["ID"].Value = dr.GetGuid(1).ToString();
                        ndStatus.Attributes["PercentComplete"].Value = dr.GetInt32(2).ToString();
                        if(!dr.IsDBNull(3))
                            ndStatus.Attributes["Finished"].Value = dr.GetDateTime(3).ToUniversalTime().ToString();
                        if(!dr.IsDBNull(4))
                            ndStatus.InnerXml = "<![CDATA[" + System.Web.HttpUtility.HtmlEncode(dr.GetString(4)) + "]]>";

                        if(!dr.IsDBNull(5))
                            ndStatus.Attributes["Result"].Value = dr.GetString(5);
                    }
                    dr.Close();
                    cn.Close();
                }
            });

            return ndStatus;
        }

        public static void Enqueue(Guid timerjobuid, int defaultstatus, SPSite site)
        {
            //SPSite site = SPContext.Current.Site;
            {
                EPMLiveCore.CoreFunctions.enqueue(timerjobuid, defaultstatus, site);
            }
        }

        public static Guid AddTimerJob(Guid siteid, Guid webid, Guid listid, int itemid, string jobname, int jobtype, string data, string key, int runtime, int scheduletype, string days)
        {
            Guid jobuid = Guid.Empty;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(siteid))
                {
                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT status,timerjobuid from vwQueueTimer where siteguid=@siteuid and webguid=@webuid and listguid=@listuid and itemid=@itemid and jobtype=@jobtype", cn);
                    cmd.Parameters.AddWithValue("@siteuid", siteid);
                    cmd.Parameters.AddWithValue("@webuid", webid);
                    cmd.Parameters.AddWithValue("@listuid", listid);
                    cmd.Parameters.AddWithValue("@itemid", itemid);
                    cmd.Parameters.AddWithValue("@jobtype", jobtype);

                    SqlDataReader dr = cmd.ExecuteReader();

                    bool bExists = false;
                    int status = 0;

                    if(dr.Read())
                    {
                        bExists = true;
                        status = dr.GetInt32(0);
                        jobuid = dr.GetGuid(1);
                    }
                    dr.Close();

                    if(!bExists)
                    {
                        jobuid = AddTimerJob(cn, siteid, webid, listid, itemid, jobname, jobtype, data, key, runtime, scheduletype, days);
                    }
                    else
                    {
                        if(status == 2)
                        {
                            UpdateTimerJob(cn, jobuid, data, key, runtime, scheduletype, days);
                        }
                    }

                    cn.Close();
                }
            });

            return jobuid;
        }

        private static void UpdateTimerJob(SqlConnection cn, Guid timerjobuid, string data, string key, int runtime, int scheduletype, string days)
        {
            SqlCommand cmd = new SqlCommand("update timerjobs set jobdata=@jobdata, [key]=@key, runtime=@runtime, scheduletype=@scheduletype,days=@days where timerjobuid=@timerjobuid", cn);
            cmd.Parameters.AddWithValue("@jobdata", data);
            cmd.Parameters.AddWithValue("@key", key);
            cmd.Parameters.AddWithValue("@runtime", runtime);
            cmd.Parameters.AddWithValue("@scheduletype", scheduletype);
            cmd.Parameters.AddWithValue("@timerjobuid", timerjobuid);
            cmd.Parameters.AddWithValue("@days", days);

            cmd.ExecuteNonQuery();

        }

        private static Guid AddTimerJob(SqlConnection cn, Guid siteid, Guid? webid, Guid? listid, int? itemid, string jobname, int jobtype, string data, string key, int? runtime, int scheduletype, string days)
        {
            Guid job = Guid.NewGuid();

            SqlCommand cmd = new SqlCommand("INSERT INTO timerjobs (timerjobuid, jobname, siteguid, webguid, listguid, itemid, jobtype, runtime, scheduletype, days, jobdata, [key]) VALUES  (@timerjobuid, @jobname, @siteguid, @webguid, @listguid, @itemid, @jobtype, @runtime, @scheduletype, @days, @jobdata, @key)", cn);
            cmd.Parameters.AddWithValue("@timerjobuid", job);
            cmd.Parameters.AddWithValue("@jobname", jobname);
            cmd.Parameters.AddWithValue("@siteguid", siteid);

            if(webid.HasValue)
                cmd.Parameters.AddWithValue("@webguid", webid.Value);
            else
                cmd.Parameters.AddWithValue("@webguid", DBNull.Value);

            if(listid.HasValue)
                cmd.Parameters.AddWithValue("@listguid", listid.Value);
            else
                cmd.Parameters.AddWithValue("@listguid", DBNull.Value);

            if(itemid.HasValue)
                cmd.Parameters.AddWithValue("@itemid", itemid.Value);
            else
                cmd.Parameters.AddWithValue("@itemid", DBNull.Value);

            cmd.Parameters.AddWithValue("@jobtype", jobtype);

            if(runtime.HasValue)
                cmd.Parameters.AddWithValue("@runtime", runtime.Value);
            else
                cmd.Parameters.AddWithValue("@runtime", DBNull.Value);

            cmd.Parameters.AddWithValue("@scheduletype", scheduletype);
            cmd.Parameters.AddWithValue("@days", days);
            cmd.Parameters.AddWithValue("@jobdata", data);
            cmd.Parameters.AddWithValue("@key", key);

            cmd.ExecuteNonQuery();

            return job;
        }

        public static Guid AddTimerJob(Guid siteid, Guid webid, Guid listid, string jobname, int jobtype, string data, string key, int runtime, int scheduletype, string days)
        {

            Guid jobuid = Guid.Empty;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(siteid))
                {
                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT status,timerjobuid from vwQueueTimer where siteguid=@siteuid and webguid=@webuid and listguid=@listuid and jobtype=@jobtype", cn);
                    cmd.Parameters.AddWithValue("@siteuid", siteid);
                    cmd.Parameters.AddWithValue("@webuid", webid);
                    cmd.Parameters.AddWithValue("@listuid", listid);
                    cmd.Parameters.AddWithValue("@jobtype", jobtype);

                    SqlDataReader dr = cmd.ExecuteReader();

                    bool bExists = false;
                    int status = 0;

                    if(dr.Read())
                    {
                        bExists = true;
                        status = dr.GetInt32(0);
                        jobuid = dr.GetGuid(1);
                    }
                    dr.Close();

                    if(!bExists)
                    {
                        jobuid = AddTimerJob(cn, siteid, webid, listid, null, jobname, jobtype, data, key, runtime, scheduletype, days);
                    }
                    else
                    {
                        if(status == 2)
                        {
                            UpdateTimerJob(cn, jobuid, data, key, runtime, scheduletype, days);
                        }
                    }

                    cn.Close();
                }
            });

            return jobuid;

        }

        public static Guid AddTimerJob(Guid siteid, Guid webid, string jobname, int jobtype, string data, string key, int runtime, int scheduletype, string days)
        {

            Guid jobuid = Guid.Empty;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(siteid))
                {
                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();
                    
                    bool bExists = false;
                    int status = 0;

                    if(scheduletype != 99)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT status,timerjobuid from vwQueueTimer where siteguid=@siteuid and webguid=@webuid and jobtype=@jobtype", cn);
                        cmd.Parameters.AddWithValue("@siteuid", siteid);
                        cmd.Parameters.AddWithValue("@webuid", webid);
                        cmd.Parameters.AddWithValue("@jobtype", jobtype);

                        SqlDataReader dr = cmd.ExecuteReader();

                        

                        if(dr.Read())
                        {
                            bExists = true;
                            status = dr.GetInt32(0);
                            jobuid = dr.GetGuid(1);
                        }
                        dr.Close();
                    }

                    if(!bExists)
                    {
                        jobuid = AddTimerJob(cn, siteid, webid, null, null, jobname, jobtype, data, key, runtime, scheduletype, days);
                    }
                    else
                    {
                        if(status == 2)
                        {
                            UpdateTimerJob(cn, jobuid, data, key, runtime, scheduletype, days);
                        }
                    }

                    cn.Close();
                }
            });

            return jobuid;

        }

        public static void CancelTimerJob(SPWeb web, Guid timerjobuid)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE [QUEUE] SET status = 2, percentComplete = 100 WHERE timerjobuid = @timerjobuid", cn);
                    cmd.Parameters.AddWithValue("@timerjobuid", timerjobuid);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            });
        }

        public static string IsImportResourceAlreadyRunning(SPWeb web)
        {
            bool isRunning = false;
            Guid jobId = Guid.Empty;
            int percentComplete = 0;
            string query = "SELECT status, view_log.timerjobuid, epml_log.resulttext from vwQueueTimerLog view_log inner join EPMLIVE_LOG as epml_log on view_log.timerjobuid = epml_log.timerjobuid where siteguid='" + web.Site.ID + "' and webguid='" + web.ID + "' and jobtype=60";

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            // Status 0 = Not started, Status 1 = Running, Status 2 = Completed
                            if (dr.GetInt32(0) != 2)
                            {
                                isRunning = true;
                            }
                            jobId = dr.GetGuid(1);
                            string jsonText = dr.GetString(2);

                            try
                            {
                                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                                ResourceImportResult resourceImport = jsSerializer.Deserialize<ResourceImportResult>(jsonText);
                                percentComplete = resourceImport.PercentComplete;
                            }
                            catch
                            {}
                        }
                        dr.Close();
                    }
                    cn.Close();
                }
            });

            return string.Format(@"<ResourceImporter Success=""{0}"" JobUid=""{1}"" PercentComplete=""{2}"" />", isRunning,
                    jobId, percentComplete);
        }

        public static string IsSecurityJobAlreadyRunning(SPWeb web, Guid listId, int itemId)
        {
            bool isRunning = false;
            //string query = "Select * from ITEMSEC where SITE_ID='" + web.Site.ID + "' and WEB_ID='" + web.ID + "' and LIST_ID='" + listId + "' and ITEM_ID='" + itemId + "'";
            string query = "Select * from ITEMSEC where SITE_ID='" + web.Site.ID + "' and WEB_ID='" + web.ID + "' and LIST_ID='" + listId + "' and ITEM_ID='" + itemId + "' and status <> 2";

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                            isRunning = true;
                        else
                            isRunning = false;
                        dr.Close();
                    }
                    cn.Close();
                }
            });

            return string.Format(@"<SecurityJob Success=""{0}"" />", isRunning);            
        }
    }
}
