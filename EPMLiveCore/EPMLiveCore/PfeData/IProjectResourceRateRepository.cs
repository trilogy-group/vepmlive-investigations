using System;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace EPMLiveCore.PfeData
{
    public interface IProjectResourceRateRepository
    {
        /// <summary>
        /// Deletes rates by project and the resource id.
        /// </summary>
        bool DeleteRates(SPWeb web, int projectId, int resourceId);

        /// <summary>
        /// Deletes rates by project, exclude users provided in exceptResourceIds list.
        /// </summary>
        bool DeleteAllRates(SPWeb web, int projectId, int[] exceptResourceIds);

        /// <summary>
        /// Gets the project resource rate on specified date.
        /// </summary>
        ProjectResourceRate GetRate(SPWeb web, DateTime date, int projectId, int resourceId);

        /// <summary>
        /// Gets rates list for project / resource.
        /// </summary>
        List<ProjectResourceRate> GetRates(SPWeb web, int projectId, int resourceId);

        /// <summary>
        /// Saves the project resource rate.
        /// </summary>
        bool SaveRate(SPWeb web, int projectId, int resourceId, decimal rateValue);
    }
}