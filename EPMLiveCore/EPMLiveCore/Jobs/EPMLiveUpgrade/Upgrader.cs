using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore.API;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade
{
    public class Upgrader : BaseJob
    {
        #region Methods (2) 

        // Public Methods (2) 

        public void execute(SPSite site, SPWeb web, string data)
        {
            bool isPfeSite = site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null;

            List<Type> upgradeSteps = UpgradeUtilities.GetUpgradeSteps(data);

            IEnumerable<IUpgradeStep> steps =
                upgradeSteps.Select(s => Activator.CreateInstance(s, new object[] {web, isPfeSite}))
                    .OfType<IUpgradeStep>();

            execute(site, web, data, steps);
        }

        public void execute(SPSite site, SPWeb web, string data, IEnumerable<IUpgradeStep> upgradeSteps)
        {
            IUpgradeStep[] steps = upgradeSteps as IUpgradeStep[] ?? upgradeSteps.ToArray();
            totalCount = steps.Count();

            int progressCounter = 1;
            foreach (IUpgradeStep step in steps)
            {
                bool success = step.Perform();
                sErrors += step.Log;

                updateProgress(progressCounter++);

                if (success) continue;

                bErrors = true;
                break;
            }
        }

        #endregion Methods 
    }
}