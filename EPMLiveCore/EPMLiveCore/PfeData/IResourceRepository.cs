using System;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace EPMLiveCore.PfeData
{
    public interface IResourceRepository
    {
        /// <summary>
        /// Find resource id by username (for regular accounts) or resource name (for generic accounts).
        /// </summary>
        int FindResourceId(SPWeb web, string resourceUsername, string resourceName);
    }
}