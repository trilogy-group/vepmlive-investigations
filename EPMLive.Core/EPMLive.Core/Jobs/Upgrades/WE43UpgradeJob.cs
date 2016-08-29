using System;
using System.Linq;
using EPMLiveCore.API;
using EPMLiveCore.Jobs.Upgrades.Steps;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades
{
    public class WE43UpgradeJob : BaseJob
    {
        #region Methods (1) 

        // Public Methods (1) 

        /// <summary>
        /// Executes the 4.3 Upgrade Job.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <param name="web">The web.</param>
        /// <param name="data">The data.</param>
        public void execute(SPSite site, SPWeb web, string data)
        {
            IOrderedEnumerable<JobStep> jobSteps = Steps.Utilities.GetJobSteps(data);

            totalCount = jobSteps.Count();

            int counter = 1;

            bool bIsPfe = false;

            if(site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null)
                bIsPfe = true;

            foreach (JobStep jobStep in jobSteps)
            {
                

                var step = Activator.CreateInstance(jobStep.Step, new object[] {web, data, counter++, bIsPfe}) as IStep;

                if (step == null) continue;

                bool success = step.Perform();
                sErrors += step.Log;

                updateProgress(counter - 1);

                if (success) continue;
                bErrors = true;
                break;

                
            }
        }

        #endregion Methods 
    }
}