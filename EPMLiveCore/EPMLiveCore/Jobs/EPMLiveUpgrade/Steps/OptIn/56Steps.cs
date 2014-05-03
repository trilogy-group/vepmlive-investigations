using System;
using System.Collections.Generic;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps.OptIn
{
    [UpgradeStep(Version = EPMLiveVersion.V56, Order = 1.0, Description = "Resetting features", IsOptIn = true)]
    internal class ResetFeatures56 : UpgradeStep
    {
        #region Constructors (1) 

        public ResetFeatures56(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                using (var spSite = new SPSite(Web.Site.ID))
                {
                    LogTitle(GetWebInfo(spSite.RootWeb), 1);

                    foreach (var feature in new Dictionary<Guid, string>
                    {
                        {WEFeatures.SocialStream.Id, WEFeatures.SocialStream.Title},
                        {WEFeatures.WEWebParts.Id, WEFeatures.WEWebParts.Title}
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

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V56, Order = 2.0, Description = "Configuring Lists", IsOptIn = true)]
    internal class ListChanges56 : UpgradeStep
    {
        #region Constructors (1) 

        public ListChanges56(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                using (var spSite = new SPSite(Web.Site.ID))
                {
                    foreach (SPWeb spWeb in spSite.AllWebs)
                    {
                        using (SPWeb web = spSite.OpenWeb(spWeb.ID))
                        {
                            LogTitle(GetWebInfo(web), 1);

                            for (int i = 0; i < web.Lists.Count; i++)
                            {
                                SPList list = web.Lists[i];
                                if (list.Hidden) continue;

                                LogTitle(GetListInfo(list), 2);

                                var settings = new GridGanttSettings(list);

                                try
                                {
                                    LogMessage("Enabling fancy forms", 3);

                                    ListCommands.EnableFancyForms(list);

                                    settings.EnableFancyForms = true;
                                    settings.SaveSettings(list);
                                }
                                catch (Exception e)
                                {
                                    LogMessage(e.Message, MessageKind.FAILURE, 4);
                                }

                                try
                                {
                                    LogMessage("Configuring ribbon", 3);

                                    settings.RibbonBehavior = list.Title.Equals("Resources") ? "2" : "1";
                                    settings.SaveSettings(list);
                                }
                                catch (Exception e)
                                {
                                    LogMessage(e.Message, MessageKind.FAILURE, 4);
                                }

                                try
                                {
                                    LogMessage("Enabling reporting", 3);

                                    if (!SocialEngine.Core.Utilities.IsIgnoredList(list.Title, list.ParentWeb))
                                        ListCommands.MapListToReporting(list);
                                }
                                catch (Exception e)
                                {
                                    LogMessage(e.Message, MessageKind.FAILURE, 4);
                                }
                            }
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

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V56, Order = 3.0, Description = "Scheduling Reporting Refresh", IsOptIn = true
        )]
    internal class RunRefresh56 : UpgradeStep
    {
        #region Constructors (1) 

        public RunRefresh56(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                UpgradeUtilities.ScheduleReportingRefresh(Web);
                LogMessage(null, MessageKind.SUCCESS, 1);
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 1);
            }

            return true;
        }

        #endregion
    }
}