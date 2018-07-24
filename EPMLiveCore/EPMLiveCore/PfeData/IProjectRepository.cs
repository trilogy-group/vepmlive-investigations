using System;
using Microsoft.SharePoint;

namespace EPMLiveCore.PfeData
{
    public interface IProjectRepository
    {
        /// <summary>
        /// Gets unique portfolio engine project id by SharePoint list item id.
        /// </summary>
        /// <param name="web">The web site.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="id">The list item id.</param>
        /// <returns>Id or 0 when item not found.</returns>
        int FindProjectId(SPWeb web, Guid listId, int id);
    }
}