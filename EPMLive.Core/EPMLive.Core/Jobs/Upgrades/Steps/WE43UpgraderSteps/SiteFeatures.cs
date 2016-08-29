using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 20)]
    public class SiteFeatures : Step
    {
        public SiteFeatures(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        public override string Description
        {
            get { return "Activating Features and Events"; }
        }

        public override bool Perform()
        {
            LogMessage("Activating Site Core Feature");

            SPSite.Features.Add(new Guid("e97da3cd-4c42-44cd-ba51-2bfbb2c397cb"), true);

            if(bIsPfe)
            {
                using (var workEngineAPI = new WorkEngineAPI())
                {
                    LogMessage("Installing PfE Data Synch Events");

                    //workEngineAPI.Execute("AddRemoveFeatureEvents", @"<AddRemoveFeatureEvents><Data><Feature Name=""PFEDataSync"" Operation=""ADD""/></Data></AddRemoveFeatureEvents>");
                    WorkEngineAPI.AddRemoveFeatureEvents(@"<AddRemoveFeatureEvents><Data><Feature Name=""PFEDataSync"" Operation=""ADD""/></Data></AddRemoveFeatureEvents>", SPWeb);
                    //LogMessage("Installing PfE Resource Events");

                    //workEngineAPI.Execute("AddRemoveFeatureEvents", @"<AddRemoveFeatureEvents><Data><Feature Name=""PFEResourceManagement"" Operation=""ADD""/></Data></AddRemoveFeatureEvents>");
                }
            }

            return true;
        }
    }
}
