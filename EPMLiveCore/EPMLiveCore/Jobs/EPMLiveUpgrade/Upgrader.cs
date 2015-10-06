using System;
using System.Collections.Generic;
using EPMLiveCore.API;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade
{
    public class Upgrader : BaseJob
    {
        #region Methods (1)

        // Public Methods (1) 

        public void execute(SPSite site, SPWeb web, string data)
        {
            List<Type> upgradeSteps = null;
            try
            {

                bool isPfeSite = site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null;

                upgradeSteps = UpgradeUtilities.GetUpgradeSteps(data);
                totalCount = upgradeSteps.Count;

                int progressCounter = 1;
                foreach (Type upgradeStep in upgradeSteps)
                {
                    var step = Activator.CreateInstance(upgradeStep, new object[] { web, isPfeSite }) as IUpgradeStep;

                    if (step == null) continue;

                    bool success = step.Perform();
                    sErrors += step.Log;

                    updateProgress(progressCounter++);

                    if (success) continue;

                    bErrors = true;
                    break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
                upgradeSteps = null;
            }
        }

        #endregion Methods
    }
}