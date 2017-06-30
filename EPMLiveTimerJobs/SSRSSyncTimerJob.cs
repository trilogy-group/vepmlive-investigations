using EPMLiveCore.Jobs.SSRS;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;

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
                QueueAgent.QueueJob(Parent as SPWebApplication);
            });
        }
    }
}