using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace TimeSheets
{
    public partial class BaseJob
    {
        public Guid QueueUid;
        public Guid TSUID;

        public int jobtype;

        public string sErrors = "";
        public bool bErrors = false;

		private static int? maxFailedCount = null;
        private static int MaxFailedCount
		{
			get
			{
				if (!maxFailedCount.HasValue)
				{
					try
					{
						maxFailedCount = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("Timesheet.MaxFailedCount"));
						maxFailedCount = Math.Max(maxFailedCount.Value, 1);
					}
					catch
					{
						maxFailedCount = 2;
					}
				}
				return maxFailedCount.Value;
			}
		}
        private const int FINISHJOBSTATUS = 3;
        private const int RESTARTJOBSTATUS = 0;
        private static Dictionary<Guid, int> failedjobs = new Dictionary<Guid, int>();

        public int userid;
        public Guid WebAppId = Guid.Empty;
        protected SqlConnection CreateConnection()
        {
            string strConn = string.Empty;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                strConn = EPMLiveCore.CoreFunctions.getConnectionString(WebAppId);
            });
            return new SqlConnection(strConn);
        }
        public bool initJob(SPSite site)
        {
            WebAppId = site.WebApplication.Id;
            using (SqlConnection cn = CreateConnection())
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("select status from TSQUEUE where TSQUEUE_ID=@QueueUid", cn))
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

                                return false;
                            }
                            dr.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sErrors = "Error: " + ex.ToString();
                }
            }
            return true;
        }


        public void finishJob()
        {

            using (SqlConnection cn = CreateConnection())
            {
                try
                {
                    cn.Open();
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
                        using (SqlCommand cmd = new SqlCommand("update TSQUEUE set status =  @status, PERCENTCOMPLETE = 100, dtfinished=GETDATE(),result=@result,resulttext=@resulttext where TSQUEUE_ID=@queueuid", cn))
                        {
                            var param = getStatusParam(QueueUid, bErrors);
                            cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                            if (bErrors)
                                cmd.Parameters.AddWithValue("@result", "Errors");
                            else
                                cmd.Parameters.AddWithValue("@result", "No Errors");

                            cmd.Parameters.AddWithValue("@status", param);
                            cmd.Parameters.AddWithValue("@resulttext", sErrors);
                            cmd.ExecuteNonQuery();
                        }

                    }
                    //else
                    //{
                    //    cmd = new SqlCommand("DELETE FROM timerjobs where timerjobuid=@timerjobuid", cn);
                    //    cmd.Parameters.AddWithValue("@timerjobuid", JobUid);
                    //    cmd.ExecuteNonQuery();
                    //}
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sErrors = "Error: " + ex.ToString();
                }

            }

        }

        private static Object LockFailedIds = new Object();
        private static int getStatusParam(Guid QueueUid, bool bErrors)
        {
            lock (LockFailedIds)
            {
                if (bErrors)
                {
                    if (failedjobs.ContainsKey(QueueUid))
                    {
                        if (failedjobs[QueueUid] <= MaxFailedCount)
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
    }
}
