using System;

using Microsoft.SharePoint;

namespace EPMLiveCore.API.ProjectArchiver
{
    public interface IProjectArchiverService
    {
        /// <summary>
        /// Archives the project.
        /// </summary>
        /// <param name="listItem">The list item.</param>
        void ArchiveProject(SPListItem listItem);

        /// <summary>
        /// Restores the project.
        /// </summary>
        /// <param name="listItem">The list item.</param>
        void RestoreProject(SPListItem listItem);

        /// <summary>
        /// Determines whether the specified project is archived.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <param name="webId">The web identifier.</param>
        /// <param name="listId">The list identifier.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>
        ///   <c>true</c> if the specified project is archived; otherwise, <c>false</c>.
        /// </returns>
        bool IsArchived(Guid siteId, Guid webId, Guid listId, int itemId);
    }
}