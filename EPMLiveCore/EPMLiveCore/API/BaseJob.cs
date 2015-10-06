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

        protected SqlConnection cn;

        public int queuetype;

        protected float totalCount = 0;
        private float lastPercent = 0;

        protected float percentInterval = 10;

        public Guid JobUid;
        public Guid QueueUid;
        public int userid;

        public Guid ListUid;
        public int ItemID;
        public string key;

        public XmlDocument DocData;



        public void finishJob()
        {

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                if (cn.State == System.Data.ConnectionState.Closed)
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
                using (SqlCommand cmd = new SqlCommand("update queue set status = 2, percentcomplete=100, dtfinished=GETDATE() where queueuid=@queueuid", cn))
                {
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

            cn.Close();

            if (cn != null)
                cn.Dispose();
        }

        protected void updateProgress(float newCount)
        {
            float percent = (newCount + 1) / totalCount * 100;
            if (percent + percentInterval >= lastPercent)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
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
                cn.Close();
            }
        }

        public bool initJob(SPSite site)
        {
            string strConn = EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id);
            cn = new SqlConnection(strConn);

            SPSecurity.RunWithElevatedPrivileges(delegate()
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
                            cn.Close();
                            return false;
                        }
                    }
                    else
                    {
                        cn.Close();
                        return false;
                    }
                    dr.Close();
                }
            }

            using (SqlCommand cmd1 = new SqlCommand("delete from epmlive_log where timerjobuid=@timerjobuid", cn))
            {
                cmd1.Parameters.AddWithValue("@timerjobuid", JobUid);
                cmd1.ExecuteNonQuery();
            }

            cn.Close();
            return true;
        }
    }
}
