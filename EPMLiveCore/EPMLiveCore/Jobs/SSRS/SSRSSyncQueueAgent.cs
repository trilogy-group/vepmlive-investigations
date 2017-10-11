using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Data.SqlClient;
using System.Threading;

namespace EPMLiveCore.Jobs.SSRS
{
    public class SSRSSyncQueueAgent
    {
        public static void EnequeuPFEJobAllSiteCollections(SPWebApplication webapp)
        {
            Guid fieldsFeature = new Guid("acdb86be-bfa5-41c7-91a8-7682d7edffa5");
            Guid receiversFeature = new Guid("a8ebe311-83e1-48a4-ab31-50f237398f44");
            foreach (SPSite site in webapp.Sites)
            {
                try
                {
                    if (site.RootWeb.Features[fieldsFeature] == null)
                        site.RootWeb.Features.Add(fieldsFeature);
                    if (site.RootWeb.Features[receiversFeature] == null)
                        site.RootWeb.Features.Add(receiversFeature);
                    EnequePFEJobSingleSiteCollection(webapp, site);
                }
                catch (Exception e)
                {
                    SPDiagnosticsService.Local.WriteEvent(0,
                        new SPDiagnosticsCategory("SSRs Sync",
                            TraceSeverity.Unexpected,
                            EventSeverity.ErrorCritical),
                        EventSeverity.ErrorCritical,
                        "Failed to eneque PFEQ SSRS Sync Job for " + site.Url,
                        e);
                }
                //Slowing down queue jobs creation, 1 every 30 seconds
                Thread.Sleep(30 * 1000);
            }

        }

        public static void EnequePFEJobSingleSiteCollection(SPWebApplication webapp, SPSite site)
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