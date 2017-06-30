using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Data.SqlClient;

namespace EPMLiveCore.Jobs.SSRS
{
    public class QueueAgent
    {
        public static void QueueJob(SPWebApplication webapp)
        {
            using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(webapp.Id)))
            {
                sqlConnection.Open();
                foreach (SPSite site in webapp.Sites)
                {
                    QueueJob(sqlConnection, site);
                }
            }
        }

        public static void QueueJob(SPWebApplication webapp, SPSite site)
        {
            using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(webapp.Id)))
            {
                sqlConnection.Open();
                QueueJob(sqlConnection, site);
            }
        }

        private static void QueueJob(SqlConnection sqlConnection, SPSite site)
        {
            using (var web = site.OpenWeb())
            {
                var jobGuid = Guid.NewGuid();
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
                CoreFunctions.enqueue(jobGuid, 0, site);
            }
        }
    }
}