using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private void InstallFeatures()
        {
            var ndFeatures = appDef.ApplicationXml.FirstChild.SelectSingleNode("Features");
            if (ndFeatures != null)
            {
                var ParentMessageId = 0;
                if (bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking Features", string.Empty, 0);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Installing Features", string.Empty, 0);
                }

                float percent = 0;

                var ListNdFeatures = ndFeatures.SelectNodes("Feature");
                float max = ListNdFeatures.Count;
                float counter = 0;

                var ArrInstalledSiteFeatures14 = new Dictionary<Guid, SPFeatureDefinition>();
                var ArrInstalledFarmFeatures14 = new Dictionary<Guid, SPFeatureDefinition>();
                var ArrInstalledSiteFeatures15 = new Dictionary<Guid, SPFeatureDefinition>();
                var ArrInstalledFarmFeatures15 = new Dictionary<Guid, SPFeatureDefinition>();

                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (var site = new SPSite(oWeb.Site.ID))
                    {
                        foreach (var def in site.WebApplication.Farm.FeatureDefinitions)
                        {
                            if (def.CompatibilityLevel == 14)
                            {
                                ArrInstalledFarmFeatures14.Add(def.Id, def);
                            }
                            else
                            {
                                ArrInstalledFarmFeatures15.Add(def.Id, def);
                            }
                        }

                        foreach (var def in site.FeatureDefinitions)
                        {
                            if (def.CompatibilityLevel == 14)
                            {
                                ArrInstalledSiteFeatures14.Add(def.Id, def);
                            }
                            else
                            {
                                ArrInstalledSiteFeatures15.Add(def.Id, def);
                            }
                        }
                    }
                });

                foreach (XmlNode ndFeature in ListNdFeatures)
                {
                    var FeatureId = ApplicationInstallerHelpers.getAttribute(ndFeature, "ID");
                    var sFeatureName = ApplicationInstallerHelpers.getAttribute(ndFeature, "Name");
                    if (FeatureId != string.Empty)
                    {
                        try
                        {
                            InstallFeatures(ParentMessageId, ArrInstalledSiteFeatures14, ArrInstalledFarmFeatures14, ArrInstalledSiteFeatures15, ArrInstalledFarmFeatures15, ndFeature, FeatureId, sFeatureName);
                        }
                        catch (Exception ex)
                        {
                            addMessage(ErrorLevels.Error, sFeatureName == string.Empty ? FeatureId : sFeatureName, "Error: " + ex.Message, ParentMessageId);
                        }
                    }

                    counter++;
                    percent = counter / max;
                    updateLIPercent(percent);
                }
            }
        }

        private void InstallFeatures(
            int ParentMessageId, 
            IDictionary<Guid, SPFeatureDefinition> ArrInstalledSiteFeatures14, 
            IDictionary<Guid, SPFeatureDefinition> ArrInstalledFarmFeatures14, 
            IDictionary<Guid, SPFeatureDefinition> ArrInstalledSiteFeatures15, 
            IDictionary<Guid, SPFeatureDefinition> ArrInstalledFarmFeatures15, 
            XmlNode ndFeature, 
            string FeatureId, 
            string sFeatureName)
        {
            var included = false;
            bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndFeature, "IncludedInSolutions"), out included);

            var featureId = new Guid(FeatureId);
            if (ArrInstalledFarmFeatures15.ContainsKey(featureId))
            {
                var def = ArrInstalledFarmFeatures15[featureId];

                iInstallFeature(featureId, def, SPFeatureDefinitionScope.Farm, ParentMessageId);
            }
            else if (ArrInstalledFarmFeatures14.ContainsKey(featureId))
            {
                var def = ArrInstalledFarmFeatures14[featureId];

                iInstallFeature(featureId, def, SPFeatureDefinitionScope.Farm, ParentMessageId);
            }
            else if (ArrInstalledSiteFeatures15.ContainsKey(featureId))
            {
                var def = ArrInstalledSiteFeatures15[featureId];

                iInstallFeature(featureId, def, SPFeatureDefinitionScope.Site, ParentMessageId);
            }
            else if (ArrInstalledSiteFeatures14.ContainsKey(featureId))
            {
                var def = ArrInstalledSiteFeatures14[featureId];

                iInstallFeature(featureId, def, SPFeatureDefinitionScope.Site, ParentMessageId);
            }
            else
            {
                if (included && bVerifyOnly)
                {
                    addMessage(ErrorLevels.NoError, sFeatureName == string.Empty ? FeatureId : sFeatureName, string.Empty, ParentMessageId);
                }
                else
                {
                    addMessage(ErrorLevels.Error, sFeatureName == string.Empty ? FeatureId : sFeatureName, "Feature Not Installed on Farm", ParentMessageId);
                }
            }
        }
    }
}