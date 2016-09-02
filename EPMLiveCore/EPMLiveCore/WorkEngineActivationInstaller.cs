using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore
{
    public class WorkEngineActivationInstaller : SPFeatureReceiver
    {

        const string TASK_LOGGER_JOB_NAME = "WorkEngineActivation";
        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
        }

        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
        }

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            //try
            //{
            //    SPWebApplication webapp = properties.Feature.Parent as SPWebApplication;

            //    // make sure the job isn't already registered
            //    foreach(SPJobDefinition job in webapp.JobDefinitions)
            //    {
            //        if(job.Name == TASK_LOGGER_JOB_NAME)
            //            job.Delete();
            //    }

            //    // install the job
            //    WorkEngineActivation weActivation = new WorkEngineActivation(TASK_LOGGER_JOB_NAME, webapp);

            //    SPMinuteSchedule schedule = new SPMinuteSchedule();
            //    schedule.BeginSecond = 0;
            //    schedule.EndSecond = 59;
            //    schedule.Interval = 5;
            //    weActivation.Schedule = schedule;

            //    weActivation.Update();

            //}
            //catch { }
            

        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPWebApplication webapp = properties.Feature.Parent as SPWebApplication;

            // delete the job
            foreach (SPJobDefinition job in webapp.JobDefinitions)
            {
                if (job.Name == TASK_LOGGER_JOB_NAME)
                    job.Delete();
            }
        }


    }
}
