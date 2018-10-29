using System;

namespace EPMLiveCore.API.ProjectArchiver
{
    public interface IProjectArchiverSetupService
    {
        /// <summary>
        /// Occurs on log event.
        /// </summary>
        event EventHandler<ProjectArchiverSetupServiceLogEventArgs> LogEvent;

        /// <summary>
        /// Upgrades the SharePoint lists and views.
        /// Perform following updates: 
        ///  * Determines project lists to proceed
        ///  * Adds archived column to each project list
        ///  * For each project list updates existing views to filter data by Archived column
        ///  * For each project list adds new view to show Archived items
        ///  * For each project list process all associated lists
        /// </summary>
        void EnsureFeatureIsInstalledForWeb(Guid siteId, Guid webId);
    }
}