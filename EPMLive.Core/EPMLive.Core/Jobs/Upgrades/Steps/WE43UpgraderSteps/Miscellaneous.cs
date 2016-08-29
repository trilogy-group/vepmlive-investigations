using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 80)]
    public class Miscellaneous : Step
    {
        #region Constructors (1) 

        public Miscellaneous(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        #endregion Constructors 

        #region Methods (3) 

        // Private Methods (3) 

        private void ConfigurePlanner()
        {
            try
            {
                LogMessage("Configuring Planner.");

                foreach (SPWeb spWeb in SPWeb.Site.AllWebs)
                {
                    bool isLocked;
                    bool.TryParse(CoreFunctions.getConfigSetting(spWeb, "EPMLiveLockConfig"), out isLocked);

                    if (!isLocked) continue;

                    LogMessage("\tWeb: " + spWeb.ServerRelativeUrl);

                    LogMessage("\tAdding the Planner Templates library...");

                    SPList spList = spWeb.Lists.TryGetList("Planner Templates");

                    if (spList == null)
                    {
                        try
                        {
                            Guid libId = spWeb.Lists.Add("Planner Templates",
                                                         "Use this library to manage planner templates.",
                                                         SPListTemplateType.DocumentLibrary);

                            SPList list = spWeb.Lists.GetList(libId, true);
                            list.Fields.Add("Description", SPFieldType.Note, false);
                            list.Update();

                            LogMessage("\t", "Added.", 1);
                        }
                        catch (Exception e)
                        {
                            LogMessage("\t", e.Message, 3);
                        }
                    }
                    else
                    {
                        LogMessage("\t", "Library already exists.", 2);
                    }

                    SetProperty("UseOldEditInProject", true.ToString(), new[] {spWeb}, false);
                }
            }
            catch (Exception e)
            {
                LogMessage("", e.Message, 3);
            }
        }

        private void ResetFeatures()
        {
            try
            {
                using (var spSite = new SPSite(SPWeb.Site.ID))
                {
                    LogMessage("Resetting WE WebParts feature.");

                    Guid featureId = WEFeatures.WEWebParts.Id;

                    SPFeature spFeature = spSite.Features.FirstOrDefault(f => f.DefinitionId == featureId);

                    LogMessage("\tDeactivating the feature...");

                    if (spFeature == null)
                    {
                        LogMessage("\t", "Already deactive.", 2);
                    }
                    else
                    {
                        spSite.Features.Remove(featureId);
                        LogMessage("\t", "Feature deactivated.", 1);
                    }

                    LogMessage("\tActivating the feature...");

                    spSite.Features.Add(featureId);
                    LogMessage("\t", "Feature activated.", 1);
                }
            }
            catch (Exception e)
            {
                LogMessage("", e.Message, 3);
            }
        }

        private void SetProperty(string name, string value, IEnumerable<SPWeb> spWebCollection, bool printMessage)
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
                                                     {
                                                         using (var spSite = new SPSite(SPWeb.Site.ID))
                                                         {
                                                             LogMessage((!printMessage ? "\t" : "") + "Setting the " + name + " property");

                                                             foreach (SPWeb spWeb in spWebCollection)
                                                             {
                                                                 using (SPWeb web = spSite.OpenWeb(spWeb.ID))
                                                                 {
                                                                     CoreFunctions.setConfigSetting(web, name.ToLower(), value);

                                                                     if (printMessage)
                                                                     {
                                                                         LogMessage("", "Web: " + web.ServerRelativeUrl, 1);
                                                                     }
                                                                 }
                                                             }
                                                         }
                                                     });
        }

        #endregion Methods 

        #region Overrides of Step

        public override string Description
        {
            get { return "Miscellaneous"; }
        }

        public override bool Perform()
        {
            ResetFeatures();

            SetProperty("DefaultCommunityNavs", "<Navs><QuickLaunch></QuickLaunch></Navs>", SPWeb.Site.AllWebs, true);

            ConfigurePlanner();

            return true;
        }

        #endregion
    }
}