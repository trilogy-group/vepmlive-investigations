using System;
using Microsoft.SharePoint.Administration;
using System.Diagnostics;
using Microsoft.SharePoint;
using EPMLiveCore;
using System.Data.SqlClient;

namespace EPMLiveTimerJobs
{
    public class SSRSSyncTimerJob : SPJobDefinition
    {
        private readonly string JobTitle = "SSRS Sync Job";

        public SSRSSyncTimerJob() : base()
        {
            Title = JobTitle;
        }

        public SSRSSyncTimerJob(string jobName, SPWebApplication webapp)
            : base(jobName, webapp, null, SPJobLockType.ContentDatabase)
        {
            Title = JobTitle;
        }

        public SSRSSyncTimerJob(string jobName, SPService service)
            : base(jobName, service, null, SPJobLockType.None)
        {
            Title = JobTitle;
        }

        public override void Execute(Guid targetInstanceId)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                var webapp = Parent as SPWebApplication;
                using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(webapp.Id)))
                {
                    sqlConnection.Open();
                    foreach (SPSite site in webapp.Sites)
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
            });
        }
    }
}