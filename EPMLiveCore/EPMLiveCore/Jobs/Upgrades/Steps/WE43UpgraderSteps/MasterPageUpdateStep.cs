using System;
using System.IO;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    //[JobStep("WE43Upgrader", 10)]
    //public class MasterPageUpdateStep : Step
    //{
    //    #region Constructors (1) 

    //    public MasterPageUpdateStep(SPWeb spWeb, string data, int stepNumber) : base(spWeb, data, stepNumber)
    //    {
    //    }

    //    #endregion Constructors 

    //    #region Overrides of Step

    //    public override string Description
    //    {
    //        get { return "Updating MasterPage"; }
    //    }


    //    public override bool Perform()
    //    {
    //        try
    //        {
    //            SPSecurity.RunWithElevatedPrivileges(() =>
    //                                                     {
    //                                                         using (var spSite = new SPSite(SPSite.ID))
    //                                                         {
    //                                                             foreach (SPWeb spWeb in spSite.AllWebs)
    //                                                             {
    //                                                                 LogMessage("Analyzing current MasterPage.", spWeb);

    //                                                                 using (SPWeb web = spSite.OpenWeb(spWeb.ID))
    //                                                                 {
    //                                                                     SPUtility.ValidateFormDigest();
    //                                                                     PerformStep(web);
    //                                                                 }
    //                                                             }
    //                                                         }
    //                                                     });

    //            return true;
    //        }
    //        catch (Exception exception)
    //        {
    //            LogMessage(exception.Message, false);
    //            return false;
    //        }
    //    }

    //    private void PerformStep(SPWeb spWeb)
    //    {
    //        string masterUrl = spWeb.MasterUrl;

    //        if (masterUrl.ToLower().Equals("/_catalog/masterpage/wetoplevel.master"))
    //        {
    //            LogMessage("Current MasterPage is: WETopLevel.master");
    //            ActivateFeature("MasterV43LightBlueTop", spWeb);
    //            ChangeMasterPage("MasterV43LightBlueTop", spWeb);
    //        }
    //        else if (masterUrl.ToLower().Equals("/_catalog/masterpage/weworkspacetopnav.master"))
    //        {
    //            LogMessage("Current MasterPage is: WEWorkspaceTopNav.master");
    //            ActivateFeature("MasterV43LightBlueWS", spWeb);
    //            ChangeMasterPage("MasterV43LightBlueWS", spWeb);
    //        }
    //        else
    //        {
    //            if (spWeb.IsRootWeb)
    //            {
    //                LogMessage(string.Format("Current MasterPage: {0}. Root Web: TRUE.", Path.GetFileName(masterUrl)));
    //                ActivateFeature("MasterV43LightBlueTop", spWeb);
    //                ChangeMasterPage("MasterV43LightBlueTop", spWeb);
    //            }
    //            else
    //            {
    //                LogMessage(string.Format("Current MasterPage: {0}. Root Web: FALSE.", Path.GetFileName(masterUrl)));
    //                ActivateFeature("MasterV43LightBlueWS", spWeb);
    //                ChangeMasterPage("MasterV43LightBlueWS", spWeb);
    //            }
    //        }
    //    }

    //    private void ChangeMasterPage(string masterPage, SPWeb spWeb)
    //    {
    //        LogMessage(string.Format("Changing MasterPage to: {0}", masterPage), true);

    //        spWeb.MasterUrl = string.Format("/_catalog/masterpage/{0}.master", masterPage);
    //        spWeb.CustomMasterUrl = string.Format("/_catalog/masterpage/{0}.master", masterPage);
    //        spWeb.Update();
    //    }

    //    private void ActivateFeature(string masterPage, SPWeb spWeb)
    //    {
    //        LogMessage(string.Format("Activating feature: {0}", masterPage), true);

    //        spWeb.Features.Add(masterPage.Equals("MasterV43LightBlueTop")
    //                               ? new Guid("12c595be-1b08-4eda-b45a-b4703650234f")
    //                               : new Guid("7d08f889-c324-460b-95e2-c26ee42657ad"));
    //    }

    //    #endregion
    //}
}