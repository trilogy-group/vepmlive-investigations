using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using System.Xml;

namespace EPMLiveCore.API
{
    public partial class BaseJob
    {
        public string sErrors = "";
        public bool bErrors = false;
        private const int MAXFAILEDCOUNT = 1;
        private const int FINISHJOBSTATUS = 2;
        private const int RESTARTJOBSTATUS = 0;

        private static Dictionary<Guid, int> failedjobs = new Dictionary<Guid, int>();

        public int queuetype;

        protected float totalCount = 0;
        private float lastPercent = 0;

        protected float percentInterval = 10;

        public Guid JobUid;
        public Guid QueueUid;
        public int userid;
        public Guid WebAppId = Guid.Empty;
        public Guid ListUid;
        public int ItemID;
        public string key;
        public XmlDocument DocData;

        protected SqlConnection CreateConnection()
        {
            string strConn = EPMLiveCore.CoreFunctions.getConnectionString(WebAppId);
            return new SqlConnection(strConn);
        }

        public void finishJob()
        {
            using (SqlConnection cn = CreateConnection())
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {

                        cn.Open();
                    });

                    //SqlCommand cmd = new SqlCommand("select scheduletype from timerjobs where timerjobuid=@timerjobuid", cn);
                    //cmd.Parameters.AddWithValue("@timerjobuid", JobUid);
                    //SqlDataReader dr = cmd.ExecuteReader();
                    //bool tempJob = false;
                    //if (dr.Read())
                    //{
                    //    tempJob = (dr.GetInt32(0) == 0);
                    //}
                    //dr.Close();

                    //if (!tempJob)
                    {
                        using (SqlCommand cmd = new SqlCommand("update queue set status = @status, percentcomplete=100, dtstarted=ISNULL(dtstarted, GETDATE()), dtfinished=GETDATE() where queueuid=@queueuid", cn))
                        {
                            var paramValue = getStatusParam();
                            cmd.Parameters.AddWithValue("@status", paramValue);
                            cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd1 = new SqlCommand("DELETE FROM EPMLIVE_LOG where timerjobuid=@timerjobuid", cn))
                        {
                            cmd1.Parameters.AddWithValue("@timerjobuid", JobUid);
                            cmd1.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd2 = new SqlCommand("INSERT INTO EPMLIVE_LOG (timerjobuid,result,resulttext) VALUES (@timerjobuid,@result,@resulttext)", cn))
                        {
                            if (bErrors)
                                cmd2.Parameters.AddWithValue("@result", "Errors");
                            else
                                cmd2.Parameters.AddWithValue("@result", "No Errors");
                            cmd2.Parameters.AddWithValue("@resulttext", sErrors);
                            cmd2.Parameters.AddWithValue("@timerjobuid", JobUid);
                            cmd2.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd3 = new SqlCommand("DELETE FROM TIMERJOBS where timerjobuid=@timerjobuid and scheduletype = 99", cn))
                        {
                            cmd3.Parameters.AddWithValue("@timerjobuid", JobUid);
                            cmd3.ExecuteNonQuery();
                        }
                    }
                    //else
                    //{
                    //    cmd = new SqlCommand("DELETE FROM timerjobs where timerjobuid=@timerjobuid", cn);
                    //    cmd.Parameters.AddWithValue("@timerjobuid", JobUid);
                    //    cmd.ExecuteNonQuery();
                    //}
                }
                catch { }
            }
        }

        private Object LockFailedIds = new Object();
        private int getStatusParam()
        {
            lock (LockFailedIds)
            {
                if (bErrors)
                {
                    if (failedjobs.ContainsKey(QueueUid))
                    {
                        if (failedjobs[QueueUid] <= MAXFAILEDCOUNT)
                        {
                            failedjobs.Remove(QueueUid);
                            return FINISHJOBSTATUS;
                        }
                        failedjobs[QueueUid] += 1;
                        return RESTARTJOBSTATUS;
                    }
                    else
                    {
                        failedjobs.Add(QueueUid, 1);
                        return RESTARTJOBSTATUS;
                    }
                }
                else
                {
                    if (failedjobs.ContainsKey(QueueUid))
                    {
                        failedjobs.Remove(QueueUid);
                    }
                    return FINISHJOBSTATUS;
                }
            }
        }
        protected void updateProgress(float newCount)
        {
            float percent = (newCount + 1) / totalCount * 100;
            if (percent + percentInterval >= lastPercent)
            {
                using (SqlConnection cn = CreateConnection())
                {
                    try
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate ()
                        {
                            cn.Open();
                        });

                        using (SqlCommand cmd = new SqlCommand("update queue set percentcomplete=@percent where queueuid=@queueuid", cn))
                        {
                            cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                            cmd.Parameters.AddWithValue("@percent", percent);
                            cmd.ExecuteNonQuery();
                        }

                        lastPercent = percent;
                    }
                    catch
                    {
                        lastPercent = percent;
                    }
                }
            }
        }

        public bool initJob(SPSite site)
        {
            WebAppId = site.WebApplication.Id;
            using (SqlConnection cn = CreateConnection())
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        cn.Open();
                    });
                    using (SqlCommand cmd = new SqlCommand("select status from queue where queueuid=@queueuid", cn))
                    {
                        cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            if (dr.Read())
                            {
                                if (dr.GetInt32(0) != 1)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    using (SqlCommand cmd1 = new SqlCommand("delete from epmlive_log where timerjobuid=@timerjobuid", cn))
                    {
                        cmd1.Parameters.AddWithValue("@timerjobuid", JobUid);
                        cmd1.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sErrors = ex.ToString();
                    return false;
                }
            }
        }
    }
}
