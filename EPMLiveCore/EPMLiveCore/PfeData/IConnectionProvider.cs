using System;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace EPMLiveCore.PfeData
{
    public interface IConnectionProvider
    {
        /// <summary>
        /// Creates connection from config settings stored in SPWeb.
        /// </summary>
        /// <returns>The new SqlConnection instance.</returns>
        SqlConnection CreateConnection(SPWeb web);
    }
}