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
                if(cn.State == System.Data.ConnectionState.Closed)
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
                SqlCommand cmd = new SqlCommand("update queue set status = 2, percentcomplete=100, dtfinished=GETDATE() where queueuid=@queueuid", cn);
                cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("DELETE FROM EPMLIVE_LOG where timerjobuid=@timerjobuid", cn);
                cmd.Parameters.AddWithValue("@timerjobuid", JobUid);
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("INSERT INTO EPMLIVE_LOG (timerjobuid,result,resulttext) VALUES (@timerjobuid,@result,@resulttext)", cn);
                if (bErrors)
                    cmd.Parameters.AddWithValue("@result", "Errors");
                else
                    cmd.Parameters.AddWithValue("@result", "No Errors");
                cmd.Parameters.AddWithValue("@resulttext", sErrors);
                cmd.Parameters.AddWithValue("@timerjobuid", JobUid);
                cmd.ExecuteNonQuery();
            }
            //else
            //{
            //    cmd = new SqlCommand("DELETE FROM timerjobs where timerjobuid=@timerjobuid", cn);
            //    cmd.Parameters.AddWithValue("@timerjobuid", JobUid);
            //    cmd.ExecuteNonQuery();
            //}

            cn.Close();
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

                SqlCommand cmd = new SqlCommand("update queue set percentcomplete=@percent where queueuid=@queueuid", cn);
                cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                cmd.Parameters.AddWithValue("@percent", percent);
                cmd.ExecuteNonQuery();

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

            SqlCommand cmd = new SqlCommand("select status from queue where queueuid=@queueuid", cn);
            cmd.Parameters.AddWithValue("@queueuid", QueueUid);
            SqlDataReader dr = cmd.ExecuteReader();

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

            cmd = new SqlCommand("delete from epmlive_log where timerjobuid=@timerjobuid", cn);
            cmd.Parameters.AddWithValue("@timerjobuid", JobUid);
            cmd.ExecuteNonQuery();

            cn.Close();
            return true;
        }
    }
}
