using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.UI.WebControls;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    internal class WebSettingsHelper
    {
        private SPWeb Web { get; set; }
        private string EPMLiveConnection { get; set; }

        internal WebSettingsHelper(SPWeb spWeb)
        {
            Web = spWeb;
            EPMLiveConnection = string.Empty;
        }

        internal void SetPFEDatabase(Label lblPFEDB, Label lblPFEDBServer)
        {
            var basePath = GetBasePath();
            const string errMsg = "Cannot get PFE database information.";
            if (!string.IsNullOrWhiteSpace(basePath))
            {
                var pfeConnection = Utilities.GetPFEDBConnectionString(basePath);
                if (!string.IsNullOrWhiteSpace(pfeConnection))
                {
                    try
                    {
                        if (pfeConnection.StartsWith("provider", StringComparison.InvariantCultureIgnoreCase))
                        {
                            // Removing "Provider" part from connection string
                            pfeConnection = pfeConnection.Substring(pfeConnection.IndexOf(';') + 1);
                        }

                        Guard.ArgumentIsNotNull(lblPFEDB, nameof(lblPFEDB));
                        Guard.ArgumentIsNotNull(lblPFEDBServer, nameof(lblPFEDBServer));

                        using (SqlConnection pfeConn = new SqlConnection(pfeConnection))
                        {
                            lblPFEDB.Text = string.Format("Name: {0}", pfeConn.Database);
                            lblPFEDBServer.Text = string.Format("Server: {0}", pfeConn.DataSource);
                        }
                    }
                    catch
                    {
                        lblPFEDB.Text = errMsg;
                    }
                }
                else
                {
                    lblPFEDB.Text = errMsg;
                }
            }
            else
            {
                lblPFEDB.Text = errMsg;
            }
        }

        internal void SetReportingDatabase(Label lblReportingDB, Label lblReportingDBServer)
        {
            const string errMsg = "Cannot get Reporting database information.";
            if (!string.IsNullOrWhiteSpace(EPMLiveConnection))
            {
                var reportingDbConnectionString = Utilities.GetReportingDbConnectionString(
                    EPMLiveConnection, 
                    Web.Site.ID, 
                    Web.Site.WebApplication.Id);
                if (!string.IsNullOrWhiteSpace(reportingDbConnectionString))
                {
                    try
                    {
                        Guard.ArgumentIsNotNull(lblReportingDB, nameof(lblReportingDB));
                        Guard.ArgumentIsNotNull(lblReportingDBServer, nameof(lblReportingDBServer));

                        using (var reportingConnection = new SqlConnection(reportingDbConnectionString))
                        {
                            lblReportingDB.Text = string.Format("Name: {0}", reportingConnection.Database);
                            lblReportingDBServer.Text = string.Format("Server: {0}", reportingConnection.DataSource);
                        }
                    }
                    catch
                    {
                        lblReportingDB.Text = errMsg;
                    }
                }
                else
                {
                    lblReportingDB.Text = errMsg;
                }
            }
            else
            {
                lblReportingDB.Text = errMsg;
            }
        }

        internal void SetEPMLiveDatabase(Label lblEPMLDB, Label lblEPMLDBServer)
        {
            var errMsg = "Cannot get EPMLive database information.";
            try
            {
                EPMLiveConnection = CoreFunctions.getConnectionString(Web.Site.WebApplication.Id);
                if (!string.IsNullOrWhiteSpace(EPMLiveConnection))
                {
                    Guard.ArgumentIsNotNull(lblEPMLDB, nameof(lblEPMLDB));
                    Guard.ArgumentIsNotNull(lblEPMLDBServer, nameof(lblEPMLDBServer));

                    using (var connection = new SqlConnection(EPMLiveConnection))
                    {
                        lblEPMLDB.Text = string.Format("Name: {0}", connection.Database);
                        lblEPMLDBServer.Text = string.Format("Server: {0}", connection.DataSource);
                    }
                }
                else
                {
                    lblEPMLDB.Text = errMsg;
                }
            }
            catch
            {
                lblEPMLDB.Text = errMsg;
            }
        }

        internal void SetSharePointVersion(Label lblSPVersion)
        {
            try
            {
                Guard.ArgumentIsNotNull(lblSPVersion, nameof(lblSPVersion));
                lblSPVersion.Text = Convert.ToString(Web.Site.WebApplication.Farm.BuildVersion);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        internal void SetEPMLiveVersion(Label lblEPMLVersion)
        {
            Guard.ArgumentIsNotNull(lblEPMLVersion, nameof(lblEPMLVersion));
            lblEPMLVersion.Text = CoreFunctions.GetFullAssemblyVersion();
        }

        private string GetBasePath()
        {
            try
            {
                return CoreFunctions
                    .getConfigSetting(SPContext.Current.Web.Site.RootWeb, "EPKBasepath")
                    .Replace("/", string.Empty)
                    .Replace("\\", string.Empty);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
