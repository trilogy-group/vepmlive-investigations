using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Data.SqlClient;
using System.Threading;

namespace EPMLiveCore.Jobs.SSRS
{
    public class QueueAgent
    {
        public static void QueueJob(SPWebApplication webapp)
        {
            foreach (SPSite site in webapp.Sites)
            {
                QueueJob(webapp, site);
                //Slowing down queue jobs creation, 1 every 30 seconds
                Thread.Sleep(30 * 1000);
            }

        }

        public static void QueueJob(SPWebApplication webapp, SPSite site)
        {
            var jobGuid = Guid.NewGuid();
            using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(webapp.Id)))
            {
                sqlConnection.Open();
                using (var web = site.OpenWeb())
                {
                    var sqlCommand = new SqlCommand
                    {
                        CommandText =
                            "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, scheduletype, webguid, listguid, itemid, jobdata, [key]) VALUES (@timerjobuid, @siteguid, 14, 'Sync SSRS', 0, @webguid, @listguid, @itemid, @jobdata, @key)",
                        Connection = sqlConnection
                    };
                    sqlCommand.Parameters.Add(new SqlParameter("@timerjobuid", jobGuid));
                    sqlCommand.Parameters.Add(new SqlParameter("@siteguid", site.ID.ToString()));
                    sqlCommand.Parameters.Add(new SqlParameter("@webguid", web.ID.ToString()));
                    sqlCommand.Parameters.Add(new SqlParameter("@listguid", DBNull.Value));
                    sqlCommand.Parameters.Add(new SqlParameter("@itemid", DBNull.Value));
                    sqlCommand.Parameters.Add(new SqlParameter("@jobdata", ""));
                    sqlCommand.Parameters.Add(new SqlParameter("@key", ""));
                    sqlCommand.ExecuteNonQuery();
                }
            }
            //Moved outside the connection scope to reduce deadlocks opportunity
            CoreFunctions.enqueue(jobGuid, 0, site);
        }

    }
}