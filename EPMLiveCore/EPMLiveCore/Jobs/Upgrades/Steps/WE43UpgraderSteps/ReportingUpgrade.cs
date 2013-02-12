using System;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 70)]
    public class ReportingUpgrade : Step
    {
        #region Constructors (1) 

        public ReportingUpgrade(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        #endregion Constructors 

        #region Methods (1) 

        // Private Methods (1) 

        private void RunRefreshAll()
        {
            LogMessage("Running Refresh All");

            try
            {
                var workEngineApi = new WorkEngineAPI();
                workEngineApi.Execute("Reporting_RefreshAll", string.Empty);
            }
            catch (Exception e)
            {
                LogMessage("\t", e.Message, 3);
            }
        }

        #endregion Methods 

        #region Overrides of Step

        public override string Description
        {
            get { return "Updating Reporting"; }
        }

        public override bool Perform()
        {
            RunRefreshAll();

            return true;
        }

        #endregion
    }
}