using System;
using System.Collections.Generic;

using EPMLiveCore.API.ProjectArchiver;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;

using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V640, Order = 3, Description = "Adding archive / restore project feature to SharePoint")]
    internal class ProjectArchiveRestoreSharePointInstall64 : UpgradeStep
    {
        private readonly IProjectArchiverSetupService _setupService;

        public ProjectArchiveRestoreSharePointInstall64(SPWeb web, bool isPfeSite)
            : base(web, isPfeSite)
        {
            _setupService = new ProjectArchiverSetupService(2);
            _setupService.LogEvent += SetupServiceLogEvent;
        }
        
        public override bool Perform()
        {
            try
            {
                LogTitle(GetWebInfo(Web), 1);
                SPSecurity.RunWithElevatedPrivileges(UpgradeSharePoint);
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 1);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Upgrades the SharePoint lists and views.
        /// Perform following updates: 
        ///  * Uses archiver setup service to upgrade web
        ///  * Uses archiver setup service to upgrade site child webs
        /// </summary>
        private void UpgradeSharePoint()
        {
            var siteId = Web.Site.ID;
            var rootWebId = Web.ID;
            
            // ensure feature is installed in web
            _setupService.EnsureFeatureIsInstalledForWeb(siteId, rootWebId);

            if (!Web.IsRootWeb)
            {
                // if not a root web do not try update child webs
                // all sub-sites can only be updated when calling upgrade to root site
                return;
            }

            var childWebIds = GetChildWebIds(siteId, rootWebId);

            foreach (var web in childWebIds)
            {
                LogMessage($"Processing child web {web.Value}", 1);
                _setupService.EnsureFeatureIsInstalledForWeb(siteId, web.Key);
            }

            LogMessage($"Web {Web.Title} is ready to use archive restore project feature", MessageKind.SUCCESS, 1);
        }

        private Dictionary<Guid, string> GetChildWebIds(Guid siteId, Guid rootWebId)
        {
            // ensure feature is enabled in all child sites
            var childWebIds = new Dictionary<Guid, string>();
            using (var site = new SPSite(siteId))
            {
                foreach (SPWeb web in site.AllWebs)
                {
                    if (web.ID != rootWebId)
                    {
                        childWebIds.Add(web.ID, web.Url);
                    }
                }
            }

            return childWebIds;
        }

        private void SetupServiceLogEvent(object sender, ProjectArchiverSetupServiceLogEventArgs e)
        {
            switch (e.LogLevel)
            {
                case ProjectArchiverSetupServiceLogEventArgs.Error:
                    LogMessage(e.Message, MessageKind.FAILURE, e.LogScope);
                    break;
                case ProjectArchiverSetupServiceLogEventArgs.Skipped:
                    LogMessage(e.Message, MessageKind.SKIPPED, e.LogScope);
                    break;
                case ProjectArchiverSetupServiceLogEventArgs.Success:
                    LogMessage(e.Message, MessageKind.SUCCESS, e.LogScope);
                    break;
                default:
                    LogMessage(e.Message, e.LogScope);
                    break;
            }
        }
    }
}