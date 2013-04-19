using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V44, Order = 1.0, Description = "Mapping PFE fields")]
    internal class MapPfeFields44 : UpgradeStep
    {
        #region Fields (1) 

        private const string EPK_LIST_PROPERTY = "epklists";

        #endregion Fields 

        #region Constructors (1) 

        public MapPfeFields44(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
        }

        #endregion Constructors 

        #region Methods (2) 

        // Public Methods (1) 

        public override bool Perform()
        {
            try
            {
                using (var spSite = new SPSite(Web.Site.ID))
                {
                    foreach (SPWeb spWeb in spSite.AllWebs)
                    {
                        try
                        {
                            using (SPWeb web = spSite.OpenWeb(spWeb.ID))
                            {
                                LogTitle(GetWebInfo(web), 1);

                                var configSetting = CoreFunctions.getConfigSetting(web, EPK_LIST_PROPERTY);
                                if (string.IsNullOrEmpty(configSetting))
                                {
                                    LogMessage("No PFE list was found.", MessageKind.SKIPPED, 2);
                                    continue;
                                }

                                foreach (string listName in configSetting.Split(',').Distinct())
                                {
                                    var list = listName.Trim();

                                    SPList spList = spWeb.Lists.TryGetList(list);
                                    if (spList == null)
                                    {
                                        LogMessage(@"List " + list + " does not exist.", MessageKind.SKIPPED, 2);
                                        continue;
                                    }

                                    LogTitle(GetListInfo(spList), 2);

                                    MapField(spList, web, "Selected", "Selected", SPFieldType.Boolean,
                                             "21000,Selected,1");
                                    MapField(spList, web, "ResourcePlanHours", "Resource Plan Hours", SPFieldType.Number,
                                             "21001,ResourcePlanHours,1");
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            LogMessage(e.Message, MessageKind.FAILURE, 2);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 2);
            }

            return true;
        }

        // Private Methods (1) 

        private void MapField(SPList spList, SPWeb web, string internalName, string displayName, SPFieldType spFieldType,
                              string propertyValue)
        {
            string message;
            MessageKind messageKind;

            LogMessage("Adding field: " + displayName, 3);

            SPField spField = UpgradeUtilities.TryAddField(internalName, displayName, spFieldType, spList, out message,
                                                           out messageKind);

            if (spField != null)
            {
                spField.ShowInNewForm = false;
                spField.ShowInEditForm = false;
                spField.ShowInDisplayForm = true;

                spField.Update();

                if (internalName.Equals("Selected"))
                {
                    var spFieldBoolean = (SPFieldBoolean) spList.Fields.GetFieldByInternalName(internalName);
                    spFieldBoolean.DefaultValue = "0";
                    spFieldBoolean.Update();
                }
                else
                {
                    var spFieldNumber = (SPFieldNumber) spList.Fields.GetFieldByInternalName(internalName);
                    spFieldNumber.DisplayFormat = SPNumberFormatTypes.NoDecimal;
                    spFieldNumber.Update();
                }
            }

            LogMessage(message, messageKind, 4);

            var listName = spList.Title.Replace(" ", string.Empty).ToLower();

            SetProperty(web, propertyValue, "epk" + listName + "_fields");
        }

        private void SetProperty(SPWeb web, string propertyValue, string property)
        {
            LogMessage(string.Format("Setting web property. {0}: {1}", property, propertyValue), 3);

            string setting = CoreFunctions.getConfigSetting(web, property);

            if (!setting.Contains(propertyValue))
            {
                if (!setting.EndsWith("|")) setting += "|";
                setting += propertyValue;

                CoreFunctions.setConfigSetting(web, property, setting);
                LogMessage(string.Empty, MessageKind.SUCCESS, 4);
            }
            else
            {
                LogMessage(string.Format("Property already contains: {0}", propertyValue), MessageKind.SKIPPED, 4);
            }
        }

        #endregion Methods 
    }

    [UpgradeStep(Version = EPMLiveVersion.V44, Order = 2.0, Description = "Resetting features")]
    internal class ResetFeatures44 : UpgradeStep
    {
        #region Fields (2) 

        private const string TIMESHEETS_FEATURE_ID = "358f8779-4487-4193-b681-cff6b84d2841";
        private const string WEBPARTS_FEATURE_ID = "b0af9b25-76d3-419d-9cfb-12e3b33fac2a";

        #endregion Fields 

        #region Constructors (1) 

        public ResetFeatures44(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
        }

        #endregion Constructors 

        #region Methods (2) 

        // Public Methods (1) 

        public override bool Perform()
        {
            try
            {
                using (var spSite = new SPSite(Web.Site.ID))
                {
                    LogTitle(GetWebInfo(spSite.RootWeb), 1);

                    foreach (var feature in new Dictionary<Guid, string>
                        {
                            {new Guid(WEBPARTS_FEATURE_ID), "Work Engine Web Parts"},
                            {new Guid(TIMESHEETS_FEATURE_ID), "WorkEngine Timesheets"}
                        })
                    {
                        ResetFeature(feature, spSite);
                    }
                }
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 2);
            }

            return true;
        }

        // Private Methods (1) 

        private void ResetFeature(KeyValuePair<Guid, string> feature, SPSite spSite)
        {
            LogTitle("Feature: " + feature.Value, 2);

            SPFeature spFeature = spSite.Features.FirstOrDefault(f => f.DefinitionId == feature.Key);

            if (spFeature != null)
            {
                LogTitle("Deactivating . . ", 4);
                spSite.Features.Remove(spFeature.DefinitionId);
            }

            LogTitle("Activating . . ", 4);
            spSite.Features.Add(feature.Key);

            LogMessage(string.Empty, MessageKind.SUCCESS, 3);
        }

        #endregion Methods 
    }
}