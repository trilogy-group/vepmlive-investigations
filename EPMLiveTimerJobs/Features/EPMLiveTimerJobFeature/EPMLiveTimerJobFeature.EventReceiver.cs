using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Runtime.InteropServices;

namespace EPMLiveTimerJobs.Features.EPMLiveTimerJobFeature
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("4018fcdf-b530-4383-8bb1-09ef6c09a139")]
    public class EPMLiveTimerJobFeatureEventReceiver : SPFeatureReceiver
    {
        const string JobName = "SSRS Sync Job";

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                var parentWebApp = (SPWebApplication)properties.Feature.Parent;
                DeleteExistingJob(JobName, parentWebApp);
                CreateJob(parentWebApp);
            });
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            lock (this)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    SPWebApplication parentWebApp = (SPWebApplication)properties.Feature.Parent;
                    DeleteExistingJob(JobName, parentWebApp);
                });
            }
        }

        private void CreateJob(SPWebApplication site)
        {
            DateTime start = DateTime.Now.AddMinutes(-10);
            DateTime end = start.AddMinutes(5);
            var job = new SSRSSyncTimerJob(JobName, site)
            {
                Schedule = new SPYearlySchedule()
                {
                    BeginMonth = start.Month,
                    BeginDay = start.Day,
                    BeginHour = start.Hour,
                    BeginMinute = start.Minute,   
                    BeginSecond = 0,
                    EndMonth = end.Month,
                    EndDay = end.Day,
                    EndHour = end.Hour,
                    EndMinute = end.Minute,
                    EndSecond = end.Second
                }
                
            };
            job.Update();
        }


        public void DeleteExistingJob(string jobName, SPWebApplication site)
        {
            try
            {
                foreach (SPJobDefinition job in site.JobDefinitions)
                {
                    if (job.Name == jobName)
                    {
                        job.Delete();
                    }
                }
            }
            catch
            {
            }
        }
    }
}