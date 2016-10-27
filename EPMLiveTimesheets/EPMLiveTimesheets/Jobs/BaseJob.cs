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
        public string strConn = string.Empty;
        public int userid;

        public bool initJob(SPSite site)
        {
            strConn = EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id);
            SqlConnection cn = new SqlConnection(strConn);
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    cn.Open();
                });

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
                            cn.Close();
                            return false;
                        }
                        dr.Close();
                    }
                }
            }
            finally
            {
                cn.Close();
            }
          
            return true;
        }


        public void finishJob()
        {
            
            SqlConnection cn = new SqlConnection(strConn);
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
                    using (SqlCommand cmd = new SqlCommand("update TSQUEUE set status =  3, PERCENTCOMPLETE = 100, dtfinished=GETDATE(),result=@result,resulttext=@resulttext where TSQUEUE_ID=@queueuid", cn))
                    {
                        cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                        if (bErrors)
                            cmd.Parameters.AddWithValue("@result", "Errors");
                        else
                            cmd.Parameters.AddWithValue("@result", "No Errors");
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
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                }
            }


           
        }
    }
}
