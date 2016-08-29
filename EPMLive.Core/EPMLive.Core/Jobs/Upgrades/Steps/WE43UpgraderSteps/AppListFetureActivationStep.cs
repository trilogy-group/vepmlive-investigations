using System;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    //[JobStep("WE43Upgrader", 20)]
    //public class AppListFetureActivationStep : Step
    //{
    //    #region Constructors (1) 

    //    public AppListFetureActivationStep(SPWeb spWeb, string data, int stepNumber) : base(spWeb, data, stepNumber)
    //    {
    //    }

    //    #endregion Constructors 

    //    #region Overrides of Step

    //    public override string Description
    //    {
    //        get { return "Activating WorkEngine Apps List feature"; }
    //    }

    //    public override bool Perform()
    //    {
    //        return true;
    //        foreach (SPWeb spWeb in SPSite.AllWebs)
    //        {
    //            LogMessage("Analyzing feature status.", spWeb);

    //            if (spWeb.Features[new Guid("21c3b2a2-f0c6-4abf-8671-a07c9f50d00d")] == null)
    //            {
    //                LogMessage("Feature is already activated.", false);
    //                continue;
    //            }

    //            spWeb.Features.Add(new Guid("21c3b2a2-f0c6-4abf-8671-a07c9f50d00d"));
    //            LogMessage("Feature is active.", true);
    //        }

    //        return true;
    //    }

    //    #endregion
    //}
}